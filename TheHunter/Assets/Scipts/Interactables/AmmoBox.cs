using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Interactable
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 10;
    private Ammos ammos;
    protected override void Interact()
    {
        ammos = FindObjectOfType<Ammos>();
        ammos.IncreaseAmmo(ammoType, ammoAmount);
    }
}
