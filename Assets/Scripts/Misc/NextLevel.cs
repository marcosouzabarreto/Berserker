using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public BoxCollider2D nextLevel;
    //Sistema de passagem de fase via SceneManager
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}
