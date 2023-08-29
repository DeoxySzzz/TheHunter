using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range = 5f;
    [SerializeField] float turnSpeed = 5f;

    private NavMeshAgent navMeshAgent;
    private float distanToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private Animation ani;
    private EnemyAttack enemyAttack;
    private float hitPoint;
    private bool isAttack = false;
    private float a = 0.9f;
    private CapsuleCollider col;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animation>();
        enemyAttack = GetComponent<EnemyAttack>();
        ani.Play("Idle");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Update()
    {
        hitPoint = GetComponent<EnemyHealth>().hitPoint;
        distanToTarget = Vector3.Distance(target.position, transform.position);
        if(distanToTarget <= range)
        {
            isProvoked = true;
        }
        if (isProvoked && hitPoint > 0)
        {
            EngagedTarget();
        }else if(hitPoint <= 0)
        {
            col.enabled = false;
            navMeshAgent.enabled = false;
            StartCoroutine(Death());
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngagedTarget()
    {
        if(distanToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(distanToTarget < navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        ani.Play("Run");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        RotateToTarget();
        ani.Play("Attack1");
        if (!isAttack) { StartCoroutine(HitPlayer()); }
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotate = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotate, Time.deltaTime * turnSpeed);
    }

    private IEnumerator HitPlayer()
    {
        isAttack = true;
        yield return new WaitForSecondsRealtime(a);
        if (distanToTarget < navMeshAgent.stoppingDistance)
        {
            enemyAttack.EnemyHitAttack();
        }
        //enemyAttack.EnemyHitAttack();
        isAttack = false;
    }

    private IEnumerator Death()
    {
        ani.Play("Death", PlayMode.StopAll);
        yield return new WaitForSecondsRealtime(1f);
        enabled = false;
        ani.Stop();
    }
}
