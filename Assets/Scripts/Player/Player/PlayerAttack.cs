using System;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    //Código responsável por propriedades físicas do personagem
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.8f;
    public int attackDamage = 30;
    public float attacksPerSecond = 2f;
    //Componente responsável pela animação de desaparecer
    public Animator anim;
    private float nextAttackTime;

    private void Start()
    {
        
    }
    //Processo principal da terceira ação
    private void Update()
    {
        if (CanAttack() && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
            SetAttackOnCooldown();
        }
        
    }
    //Método da terceira ação
    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        anim.SetTrigger("Click");
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    //Definição do alcance do ataque
    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    //Condição para definir o período de ataque
    bool CanAttack()
    {
        bool attackCooldownIsOver = Time.time >= nextAttackTime;

        return Input.GetKeyDown(KeyCode.Mouse0) && attackCooldownIsOver;
    }
    //Cooldown do ataque
    void SetAttackOnCooldown()
    {
        float attackCooldown = 1f / attacksPerSecond;
        nextAttackTime = Time.time + attackCooldown;
    }
}
