using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] AmmoType type;
    [SerializeField] int damage = 10;
    [SerializeField] float shootRange = 100f;
    [SerializeField] float shootDelay = 5;
    [SerializeField] ParticleSystem muzzleVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject cartouche;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip outOfAmmo;
    [SerializeField] GameObject lightShoot;
    [SerializeField] LayerMask mask;
    [SerializeField] TextMeshProUGUI textMeshPro;

    private Camera cam;
    private Ammos ammos;
    private EnemyHealth targetHealth;
    private bool canShoot = true;
    private bool delayWorking = false;


    private void Start()
    {
        cam = GetComponentInParent<PlayerLook>().cam;
        ammos = GetComponentInParent<Ammos>();
    }

    private void Update()
    {
        textMeshPro.text = ammos.CurrentAmmoAmount(type).ToString();
    }

    public void Shooting()
    {
        if (canShoot)
        {
            if(ammos.CurrentAmmoAmount(type) > 0)
            {
                AmmoLeft();
            }
            else
            {
                OutOfAmmo();
            }
        }
        else if(!canShoot && !delayWorking)
        {
            StartCoroutine(ShootDelay());
            canShoot = false;
        }
    }

    private void OutOfAmmo()
    {
        AudioSource.PlayClipAtPoint(outOfAmmo, cam.transform.position);
    }

    private void AmmoLeft()
    {
        ProcessVFX();
        LightShootProcess();
        AudioSource.PlayClipAtPoint(audioClip, cam.transform.position);
        Shoot();
        Cartouche();
        ammos.ReduceAmmo(type);
        canShoot = false;
    }

    private void ProcessVFX()
    {
        muzzleVFX.Play();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, shootRange))
        {
            GameObject impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 0.5f);
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, shootRange, mask))
            {
                targetHealth = hit.transform.GetComponent<EnemyHealth>();
                targetHealth.TakeDamage(damage);
            }

        }
    }

    private void LightShootProcess()
    {
        GameObject lightShootGO = Instantiate(lightShoot, transform.position,Quaternion.LookRotation(muzzleVFX.transform.right));
        Destroy(lightShootGO, 0.15f);
    }

    private void Cartouche()
    {
        GameObject emptyCartouche = Instantiate(cartouche, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z-0.5f), Quaternion.LookRotation(transform.forward));
        Destroy(emptyCartouche, 3f);
    }

    private IEnumerator ShootDelay()
    {
        delayWorking = true;
        yield return new WaitForSecondsRealtime(shootDelay);
        canShoot = true;
        delayWorking = false;
    }
}
