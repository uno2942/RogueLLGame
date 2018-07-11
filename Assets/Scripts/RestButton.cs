using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener( gameManager.EndPlayerTurn );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
