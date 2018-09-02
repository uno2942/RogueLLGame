using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public void Start()
    {
    }

    public void ReplayButton()
    {
        Debug.Log ("씬 수:" + SceneManager.sceneCount);
        SceneManager.LoadScene ("intro");
        Debug.Log ("씬 수:" + SceneManager.sceneCount);
        StartCoroutine (frameDelay ());
    }
    
    public void QuitButton()
    {
        Application.Quit ();
    }
   
    
    private IEnumerator frameDelay()
    {
        yield return null;
    }
}
