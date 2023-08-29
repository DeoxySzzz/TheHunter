using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float hitPoint = 100f;
    [SerializeField] Image hpBar;
    [SerializeField] Camera main;

    private float maxHP;
    private void Start()
    {
        maxHP = hitPoint;
    }

    private void Update()
    {
        if (hitPoint <= 0)
        {
            Destroy(hpBar);
            return;
        }
        hpBar.fillAmount = hitPoint/maxHP;
        hpBar.transform.LookAt(main.transform);
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoint -= damage;
    }
}
