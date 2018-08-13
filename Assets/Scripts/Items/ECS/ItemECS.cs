using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;
public class ItemECS : MonoBehaviour {
    public bool isUse;
    public bool isThrow;
    public List<Enemy> enemies;
    public void Start() {
        isUse = false;
        isThrow=false;
    }
}
