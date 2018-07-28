using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC:MonoBehaviour {
    
    private Player player;
    public GameObject[] dialogBox;
    GameObject gObject;
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

    // Update is called once per frame
    void Update()
    {

    }



    public virtual void OnMouseUpAsButton()
    {

    }

    public virtual void UseCommand()
    {

    }


	public virtual void talk (Player player, ItemManager.Label label)
    {

    }
}
