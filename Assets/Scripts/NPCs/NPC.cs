using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC:MonoBehaviour {
    
    public Player player;
    public GameObject[] dialogBox;
    public GameObject gObject;
    protected string name;
    public float usuability;

    public string Name
    {
        get
        {
            return name;
        }
    }

    // Use this for initialization
    void Start()
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
