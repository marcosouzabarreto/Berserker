using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public void NewGame()
   {
        SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
     Debug.Log("This line only exists because my laptop's weak");
        Application.Quit();
   }
}
