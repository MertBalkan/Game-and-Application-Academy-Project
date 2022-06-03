using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomize : MonoBehaviour
{
    public GameObject[] enemies;
    public float InvokeRate = 1f;

    private void Start()
    {
        InvokeRepeating("PickEnemies", 1f, InvokeRate);
    }

    void PickEnemies()
    {
        int indexNumber = Random.Range(0, enemies.Length);
        Debug.Log(enemies[indexNumber].name);

    }
}
