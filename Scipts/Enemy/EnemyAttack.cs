using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 45f;
    private PlayerHealth playerHealth;
    void Start()
    {

    }

    public void EnemyHitAttack()
    {
        if (target == null) return;
        playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.ProcessHealth(damage);
    }
}
