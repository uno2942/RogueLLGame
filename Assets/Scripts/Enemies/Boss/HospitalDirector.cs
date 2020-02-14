using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HospitalDirector : Boss {

    protected override void Start()
    {
        Debug.Log("최종보스 정신병원 원장 등장");
        base.Start ();
        //player.PlayerAction.bossCommuni = true;
        level = 1;
        defaultA = attack = 6; //shld be decided by level and setting file
        defaultD = defense = 6;
        maxhp = 300;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new HospitalDirectorAction( this );
        debuff = null;
        delA = 5;
        delD = 5;
    }
    

    private void OnMouseUpAsButton()
    {
        player.PlayerAction.Attack (this);
        Debug.Log ("플레이어 공격");
    }


    protected override void OnDestroy()
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
        SceneManager.LoadScene ("Clear");
        Debug.Log ("씬 수:" + SceneManager.sceneCount);
    }
}
