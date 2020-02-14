using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    public float overlaySpeed;
    public Sprite howTo;
    public Sprite credit;
    GameObject overlay;
    public void Start() {
        overlay = GameObject.Find( "Overlay" );
        overlay.transform.localScale = new Vector3( 0, 0, 0 );
    }

    public void StartButton() {
        Debug.Log("씬 수:" + SceneManager.sceneCount);
        SceneManager.LoadScene("intro");
        Debug.Log("씬 수:" + SceneManager.sceneCount);
        StartCoroutine(frameDelay());
    }

    public void HowToButton() {
        overlay.GetComponent<Image>().sprite = howTo;
        StartCoroutine( OpenOverlayCoroutine() );
    }

    public void CreditButton() {
        overlay.GetComponent<Image>().sprite = credit;
        StartCoroutine( OpenOverlayCoroutine() );
    }

    public void CloseOverlay() {
        StartCoroutine( CloseOverlayCoroutine() );
    }

    IEnumerator CloseOverlayCoroutine() {
        var delta = new Vector3( overlaySpeed, overlaySpeed, overlaySpeed );
        float now = 1.0f;
        while((now -= overlaySpeed) > 0 ) {
            overlay.transform.localScale -= delta;
            yield return null;
        }
        overlay.transform.localScale = new Vector3( 0, 0, 0 );
    }
    
    IEnumerator OpenOverlayCoroutine() {
        var delta = new Vector3( overlaySpeed, overlaySpeed, overlaySpeed );
        float now = 0f;
        while((now += overlaySpeed) < 1 ) {
            overlay.transform.localScale += delta;
            yield return null;
        }
        overlay.transform.localScale = new Vector3( 1, 1, 1 );
    }

    private IEnumerator frameDelay()
    {
        yield return null;
    }
}
