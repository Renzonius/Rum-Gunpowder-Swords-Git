using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/Create")]
public class Wave : ScriptableObject
{
    [Header("WAVE CONFIGURATION")]
    [SerializeField] private int countEnemies;
    public int CountEnemies { get => countEnemies; }
}

