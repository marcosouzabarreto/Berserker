using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    //Definir variáveis para vida e dano
    [SerializeField] int maxHealth = 100;
    [SerializeField] int curHealth;
    public BoxCollider2D box;
    public Animator anim;
    //Conectando barra de vida com script de dano
    public HealthBar hb;

    void Start() {
        curHealth = maxHealth;
        hb.SetMaxHealth(maxHealth);
    }
    //Definindo Colisão
    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy"){
            Damage(10);
            other.gameObject.GetComponent<Enemy>().TakeDamage(12);
        }
        
    }
    //Tomando dano
    public void Damage(int dmg){
        anim.SetTrigger("Hit");
        curHealth-=dmg;
        hb.SetHealth(curHealth);
    }
}
