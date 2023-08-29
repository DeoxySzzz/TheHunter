using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammos : MonoBehaviour
{
    [SerializeField] AmmoSlot[] slots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    public int CurrentAmmoAmount(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in slots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot.ammoAmount;
            }
        }
        return 0;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in slots)
        {
            if (slot.ammoType == ammoType)
            {
                slot.ammoAmount--;
            }
        }
    }

    public void IncreaseAmmo(AmmoType ammoType,int numberOfAmmo)
    {
        foreach (AmmoSlot slot in slots)
        {
            if (slot.ammoType == ammoType)
            {
                slot.ammoAmount += numberOfAmmo;
            }
        }
    }
}
