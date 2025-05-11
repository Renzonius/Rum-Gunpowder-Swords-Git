using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/Create")]
public class Wave : ScriptableObject
{
    [Header("WAVE CONFIGURATION")]
    [SerializeField] private int countEnemies;
    [SerializeField] private GameObject[] typeOfEnemies;

    public int CountEnemies { get => countEnemies; }
    public GameObject[] TypeOfEnemies { get => typeOfEnemies; }
}

