using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] 
    public List<GameObject> gunList = new List<GameObject>();

    private int currentGunID;

    public Gun SelectGun(int gunID)
    {
        for(int i = 0; i < gunList.Count; i++)
        {
            if(gunID == i)
            {
                gunList[i].SetActive(true);
            }
            else
            {
                gunList[i].SetActive(false);
            }
        }
        currentGunID = gunID;
        return gunList[gunID].GetComponent<Gun>();

    }
}
