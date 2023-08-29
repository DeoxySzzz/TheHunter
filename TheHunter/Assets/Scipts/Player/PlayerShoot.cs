using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private WeaponSwitch weaponSwitch;
    private Gun gun;
    private int gunID = 0;

    // Start is called before the first frame update
    void Start()
    {
        weaponSwitch = GetComponent<WeaponSwitch>();
        gun = weaponSwitch.SelectGun(gunID);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gunID++;
            if(gunID >= weaponSwitch.gunList.Count)
            {
                gunID = 0;
            }
            gun = weaponSwitch.SelectGun(gunID);
        }
    }
    /*void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hit, shootRange, mask))
        {
            enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (inputManager.onFoot.Shoot.triggered)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }*/

    public void ProcessShoot()
    {
        gun.Shooting();
        /*if (ammo.CurrentAmmoAmount() <= 0) { return; }
        else { ammo.ReduceAmmo(); }
        ProcessVFX();
        RaycastHit hitInfo;
        if(Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hitInfo, shootRange))
        {
            GameObject impact = Instantiate(inShoot, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impact, 0.5f);
            if (Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hitInfo, shootRange, mask))
            {
                enemyHealth = hitInfo.transform.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
        }*/
    }
}
