using UnityEngine;
using Unity.Entities;

public class StatECS : MonoBehaviour {
    public enum StatList {
        HP,
        MP,
        HUNGER,
        MAXHP,
        ATK,
        DEF
    };
    public StatList stat;
    public int delta;
    public bool isUsed;
}

