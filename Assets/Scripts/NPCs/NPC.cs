using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour{
    
    public Player player;
    public GameObject[] dialogBox;
    public GameObject gObject;
    protected string npcName;
    public float usuability;

    public string Name
    {
        get
        {
            return name;
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public virtual void OnMouseUpAsButton()
    {

    }

    public virtual void talk(Player player) //아이템과 상호작용 없는 npc와의 대화
    {

    }

    public virtual void talk( Player player, ItemManager.Label label) { //아이템 집어넣은 npc와의 대화

    }

}
