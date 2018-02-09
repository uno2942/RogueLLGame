using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    protected int attack;
    protected int defense;
    protected int hp;
    protected GameManager gameManager; 
    protected StatusCheck statusList;

    private void Awake()
    {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        statusList = new StatusCheck ();
        statusList.Initialize (this);
    }
    public int Attack
    {
        get
        {
            return attack;
        }
    }
    public int Defense
    {
        get
        {
            return defense;
        }
        
    }
    public int Hp
    {
        get
        {
            return hp;
        }
    }
    
    public void ChangeAttack(int delta)
    {
        attack += delta;
    }
    public virtual void ChangeHp(int delta)
    {
        hp += delta;
    }
    public void ChangeDefense(int delta)
    {
        defense += delta;
    }

    public void AddStatus(StatusCheck.StatusEnum se)
    {
        statusList.AddStatus (se);
    }
    public void DeleteStatus(StatusCheck.StatusEnum se)
    {
        statusList.DeleteStatus (se);
    }


    public void debugStatus()
    {
        statusList.debugStatus ();
    }

    public void UpdateStatus()
    {
        statusList.UpdateStatus ();
    }
}



