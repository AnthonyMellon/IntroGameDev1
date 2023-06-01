using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    [SerializeField] private GameObject sheepPrefab;
    [SerializeField] private List<Transform> sheepSpawnPositions;
    private float timeElapsed;
    private List<GameObject> sheepList = new List<GameObject>();

    [Header("Time Between Spawns")]
    [Tooltip("The minimum time between sheep spawns in seconds")]
    [SerializeField] private float minTimeBetweenSpawns;

    [Tooltip("The maximum time between sheep spawns in seconds")]
    [SerializeField] private float maxTimeBetweenSpawns;

    [Tooltip("The time it takes to go from maxTimeBetweenSpawns to minTimeBetweenSpawns in seconds")]
    [SerializeField] private float timeBetweenSpawnsChangeTime;

    [Header("Sheep Speed")]
    [Tooltip("The minimum speed for a sheep")]
    [SerializeField] private float minSheepSpeed;

    [Tooltip("The maximum speed for a sheep")]
    [SerializeField] private float maxSheepSpeed;

    [Tooltip("The time it takes to go from minSheepSpeed to maxSheepSpeed")]
    [SerializeField] private float sheepSpeedChangeTime;


    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);   
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
        sheep.GetComponent<Sheep>().runSpeed = Mathf.Lerp(minSheepSpeed, maxSheepSpeed, timeElapsed / sheepSpeedChangeTime);
    }

    private IEnumerator SpawnRoutine()
    {
        while(canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(Mathf.Lerp(maxTimeBetweenSpawns, minTimeBetweenSpawns, timeElapsed / timeBetweenSpawnsChangeTime));
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }

        sheepList.Clear();
    }
}
