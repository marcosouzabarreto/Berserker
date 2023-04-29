using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private const float TimeBeforeDying = 1f;
    public Animator animator;

    private bool isFacingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        Debug.Log(isFacingRight); // exibe no console se o inimigo está virado para a direita
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000*(isFacingRight ? -1 : 1), 1400), ForceMode2D.Force);

        animator.SetTrigger("WasHit");


        // Verifica se a saúde do inimigo é igual ou menor que 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    

    void Die()
    {
        
        //Destroy(gameObject, TimeBeforeDying);
    }
}
