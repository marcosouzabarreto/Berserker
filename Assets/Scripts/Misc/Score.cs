using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //Parâmetros de pontos
    public TextMeshProUGUI scoreui;
    private int scorenum;
    public BoxCollider2D fruit;
    public Animator fruitAnim;
    //Inicializando o sistema de ponto
    void Start(){
        scorenum = 0;
        scoreui.text = scorenum.ToString();
    }
    // Definindo colisão com coletável e sistema de ponto
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Player"){
        fruitAnim.SetTrigger("FruitCollect");
        scorenum++;
        Destroy(this.gameObject);
      } 
    }

    
}
