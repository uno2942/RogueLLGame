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
    public StatList[] stats;
    public int[] deltas;
    public bool isUsed;
}

