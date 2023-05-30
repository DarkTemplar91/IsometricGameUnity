using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnEnemies : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private float initialSpawnRate = 0.4f;
    [SerializeField] private float spawnDelta = 0.1f;
    [SerializeField] private int spawnHeight = 10;
    [SerializeField] private int spawnWidth = 15;
    
    private float currentSpawnRate;
    
    private float nextAttackTime;

    private Random randomGenerator;

    private GameObject target;
    private float spawnCircleRadius;
    private void Start()
    {
        currentSpawnRate = initialSpawnRate;
        target = GameObject.Find("Soldier");
        randomGenerator = new Random();
        spawnCircleRadius = Mathf.Sqrt(spawnHeight * spawnHeight + spawnWidth * spawnWidth);
    }
    
    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            float angle = 2 * MathF.PI * (float) randomGenerator.NextDouble();
            Vector3 newPos = new Vector3();
            var position = target.transform.position;
            newPos.x = position.x + spawnCircleRadius * Mathf.Cos(angle);
            newPos.y = position.y + spawnCircleRadius * Mathf.Sin(angle);
            Instantiate(enemy, newPos, Quaternion.identity);
            nextAttackTime = Time.time + 1f / currentSpawnRate;

        }
    }

    public void IncreaseSpawnRate()
    {
        currentSpawnRate += spawnDelta;
    }
}
