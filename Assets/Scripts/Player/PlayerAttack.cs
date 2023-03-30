using System;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.8f;
    public int attackDamage = 30;
    public float attacksPerSecond = 2f;

    private float nextAttackTime;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (CanAttack())
        {
            Attack();
            SetAttackOnCooldown();
        }
        
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    bool CanAttack()
    {
        bool attackCooldownIsOver = Time.time >= nextAttackTime;

        return Input.GetKeyDown(KeyCode.Mouse0) && attackCooldownIsOver;
    }

    void SetAttackOnCooldown()
    {
        float attackCooldown = 1f / attacksPerSecond;
        nextAttackTime = Time.time + attackCooldown;
    }
}
