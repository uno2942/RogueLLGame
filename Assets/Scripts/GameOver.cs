using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void Start()
    {  }

    public void ReplayButton()
    {
        Destroy (GameObject.Find ("Main Camera"));
        Destroy (GameObject.Find ("EventSystem"));
        Destroy (GameObject.Find ("Player"));
        Destroy (GameObject.Find ("GameManager"));
        Destroy (GameObject.Find ("BoardManager"));
        Destroy (GameObject.Find ("ItemManager"));
        Destroy (GameObject.Find ("PlayerUI"));
        Destroy (GameObject.Find ("InventoryUI"));
        Destroy (GameObject.Find ("MinimapCamera"));
        Destroy (GameObject.Find ("NEIUI"));
        Debug.Log ("씬 수:" + SceneManager.sceneCount);
        SceneManager.LoadScene ("intro");
        Debug.Log ("씬 수:" + SceneManager.sceneCount);
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
