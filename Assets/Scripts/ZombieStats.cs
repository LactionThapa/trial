using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] private float damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] protected bool isDead;
    [SerializeField] private bool canAttack;

    void Start()
    {
        InitVariables();
    }
    public void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            Dead();
        }
    }
    public void Dead()
    {
        isDead = true;
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }
    public void DealDamage()
    {

    }
    public void InitVariables()
    {
        health = 50;
        isDead = false;
        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }
    void Update()
    {
        
    }
}
