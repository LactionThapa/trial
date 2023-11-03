using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator animator = null;
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;   
    private ZombieStats stats = null;
    [SerializeField]private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GetReference();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stats = GetComponent<ZombieStats>();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(distanceToTarget <= agent.stoppingDistance)
        {
            animator.SetFloat("Speed", 0f);
            if(!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;

            }
            if(Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;

                Attack();
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }

    }

    private void RotateToTarget()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        //transform.LookAt(targetPosition);
        Vector3 direction = targetPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
