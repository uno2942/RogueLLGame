using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusCheck : MonoBehaviour
{
    public enum StatusEnum
    {
        Mental, Hunger, Starve, Burn, Poison, Bleed, Awaken, Relieve
    };
    const int numberOfStatus = 8;
    private Unit unit;
    Dictionary<StatusEnum, Status> statusDic;
    public void Initialize(Unit _unit)
    {
        unit = _unit;

        statusDic = new Dictionary<StatusEnum, Status> ();

        statusDic [StatusEnum.Mental] = new Mental ();
        statusDic [StatusEnum.Hunger] = new Hunger ();
        statusDic [StatusEnum.Starve] = new Starve ();
        statusDic [StatusEnum.Burn] = new Burn ();
        statusDic [StatusEnum.Poison] = new Poison ();
        statusDic [StatusEnum.Bleed] = new Bleed ();
        statusDic [StatusEnum.Awaken] = new Awaken ();
        statusDic [StatusEnum.Relieve] = new Relieve ();

        foreach ( StatusEnum se in Enum.GetValues (typeof (StatusEnum)) )
        {
            statusDic [se].Unit = unit;
        }
    }

    public void AddStatus(StatusEnum se)
    {
        statusDic [se].Activate ();
    }
    public void DeleteStatus(StatusEnum se)
    {
        statusDic [se].Inactivate ();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateStatus()
    {
        foreach(StatusEnum se in Enum.GetValues(typeof(StatusEnum)))
        {
            statusDic [se].DoAction ();
        }
    }
    public void debugStatus()
    {
        string s="";
        foreach ( StatusEnum se in Enum.GetValues (typeof (StatusEnum)) )
        {
            if ( statusDic [se].IsActive ) s += se.ToString ()+ " ";
        }
        Debug.Log ("상태이상 : " + s);
    }

    public bool isAwaken()
    {
        return statusDic [StatusEnum.Awaken].IsActive;
    }
    public bool isRelieve()
    {
        return statusDic [StatusEnum.Relieve].IsActive;
    }

}
