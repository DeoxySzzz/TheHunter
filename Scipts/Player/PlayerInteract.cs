using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] float distance = 3f;
    [SerializeField] LayerMask mask;
    [SerializeField] private Image loadAmmo;
    [SerializeField] private Image loadAmmo2;
    private PLayerUI pLayerUI;
    private InputManager inputManager;
    private float timeLoad = 2f;
    private float timeRemain = 0f;
    private bool canPickAmmo = true;
    private float delayTime = 0;

    void Start()
    {
        pLayerUI = GetComponent<PLayerUI>();
        cam = GetComponent<PlayerLook>().cam;
        inputManager = GetComponent<InputManager>();
        loadAmmo.enabled = false;
        loadAmmo2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPickAmmo && delayTime == 0)
        {
            StartCoroutine(TimeBetweenPickAmmo());
        }
        pLayerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                pLayerUI.UpdateText(interactable.promptMessage);
                if(interactable.promptMessage == "AmmoBox")
                {
                    TakingAmmoBox(interactable);
                }
                else if(interactable.promptMessage == "KeyPad")
                {
                    OpenDoor(interactable);
                }
            }
        }
    }

    private IEnumerator TimingProcess()
    {
        timeRemain += 0.01f;
        yield return new WaitForSecondsRealtime(0.1f);
    }

    private IEnumerator TimeBetweenPickAmmo()
    {
        delayTime = 1;
        yield return new WaitForSecondsRealtime(5f);
        canPickAmmo = true;
        delayTime = 0;

    }

    private void TakingAmmoBox(Interactable interactable)
    {
        if (inputManager.onFoot.Interact.inProgress && canPickAmmo)
        {
            loadAmmo.enabled = true;
            loadAmmo2.enabled = true;
            StartCoroutine(TimingProcess());
            loadAmmo.fillAmount = Mathf.InverseLerp(0, timeLoad, timeRemain);
            if (loadAmmo.fillAmount == 1)
            {
                interactable.BaseInteract();
                timeRemain = 0;
                loadAmmo.enabled = false;
                loadAmmo2.enabled = false;
                canPickAmmo = false;
            }
        }
        else
        {
            loadAmmo.enabled = false;
            loadAmmo2.enabled = false;
            timeRemain = 0;
            return;
        }
    }

    private void OpenDoor(Interactable interactable)
    {
        if (inputManager.onFoot.Interact.triggered)
        {
            interactable.BaseInteract();
        }
    }
}
