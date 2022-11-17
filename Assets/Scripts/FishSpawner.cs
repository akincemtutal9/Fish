using System;
using Lean.Pool;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishSpawner : MonoBehaviour
{
    //Fish Spawn Area
    [SerializeField] private GameObject SpawnArea;

    private float timer;
    
    [SerializeField] private float spawnAfterSeconds = 2f;
    [SerializeField] private GameObject spawnFishObjectPrefab;
    private float horizontalSpawnBoundries;
    private float verticalSpawnBoundries;
    private float xPosition;
    private float zPosition;
    
    private int fishCount = 0;
   
    private void Start()
    {
        horizontalSpawnBoundries = SpawnArea.transform.localScale.x;
        verticalSpawnBoundries = SpawnArea.transform.localScale.z;
        xPosition = SpawnArea.transform.position.x;
        zPosition = SpawnArea.transform.position.z;
        //SpawnArea.transform.localScale = new Vector3(horizontalSpawnBoundries,1,verticalSpawnBoundries);
    }
    
    
    private void Update()
    {
        RandomFishSpawner();
    }

    private void RandomFishSpawner()
    {
        timer += Time.deltaTime;
        if (timer > spawnAfterSeconds)
        {
            timer = 0;
            var randomSpawnPosition = new Vector3(Random.Range(-horizontalSpawnBoundries/2 + xPosition, horizontalSpawnBoundries/2 + xPosition), 0.5f, Random.Range(-verticalSpawnBoundries/2 + zPosition, verticalSpawnBoundries/2 + zPosition));
            //Instantiate(fishObject, randomSpawnPosition, Quaternion.identity);
            var spawnFishObject = LeanPool.Spawn(spawnFishObjectPrefab, randomSpawnPosition, Quaternion.identity);
            fishCount++;
        }
    }
}