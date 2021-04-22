using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public void Quit()
    {
     Debug.Log("Quit pressed!");  
     //Application.Quit();  //works when app is build not in editor
     UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Options()
    {
     Debug.Log("Options pressed!");  
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Play()
    {
     Debug.Log("Play pressed!");  
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }
   
    
}
