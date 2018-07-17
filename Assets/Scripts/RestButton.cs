using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * \brief 플레이어의 휴식 버튼에 붙는 클래스
 */
public class RestButton : MonoBehaviour {

	/**
     * 이 함수가 클릭 되었을 때 플레이어의 턴을 종료한다.
     * \see gameManager.EndPlayerTurn
     */
	void Start () {
        GameManager gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener( gameManager.EndPlayerTurn );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
