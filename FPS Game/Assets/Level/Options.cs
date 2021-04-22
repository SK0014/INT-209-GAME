using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    
    public void Back()
    {
     Debug.Log("Options pressed!");  
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
   
    
}
