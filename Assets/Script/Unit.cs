using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    protected int attack;
    protected int defense;
    protected int hp;
    public GameObject gameManagerObject;
    protected GameManager gameManager; 
    private List<Status> statusList;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
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
    
    public void changeAttack(int delta)
    {
        attack += delta;
    }
    public void changeHp(int delta)
    {
        hp += delta;
    }
    public void changeDefense(int delta)
    {
        defense += delta;
    }
}



