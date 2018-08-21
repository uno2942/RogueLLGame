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

    public virtual void talk(Player player)
    {

    }
   
}
