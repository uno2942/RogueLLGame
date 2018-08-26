using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * \brief 플레이어의 휴식 버튼에 붙는 클래스
 */
public class NextStageButton : MonoBehaviour {

	/**
     * 이 함수가 클릭 되었을 때 플레이어의 턴을 종료한다.
     * \see gameManager.EndPlayerTurn
     */
	void Start () {
        
    }
	
    void OnClick() {
        GameObject.Find( "BoardManager" ).GetComponent<BoardManager>().MoveNextFloor();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
