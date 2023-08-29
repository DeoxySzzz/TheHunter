using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Canvas deadCanvas;
    [SerializeField] Canvas damaged;
    [SerializeField] float playerHealth = 100f;
    [SerializeField] TextMeshProUGUI playerHP;

    private InputManager inputManager;

    private void Start()
    {
        damaged.enabled = false;
        inputManager = GetComponent<InputManager>();
        deadCanvas.enabled = false;
    }

    private void Update()
    {
        playerHP.text = "HP : " + playerHealth.ToString();
    }
    public void ProcessHealth(float damage)
    {
        playerHealth -= damage;
        damaged.enabled = true;
        if (playerHealth < 0) 
        {
            Cursor.lockState = CursorLockMode.None;
            inputManager.OnDisable();
            deadCanvas.enabled = true;
            return;
        }
        StartCoroutine(DisabledCanvas());
    }

    private IEnumerator DisabledCanvas()
    {
        yield return new WaitForSeconds(0.7f);
        damaged.enabled = false;
    }
}
