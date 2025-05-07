using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TargetSpawner : MonoBehaviour
{
    [Header("Normal Targets")]
    public GameObject objectToSpawn;
    public int numberToSpawn = 3;
    public int maxToSpawn = 10;

    [Header("Special Target")]
    public GameObject specialObjectToSpawn;
    public float specialRespawnDelay = 5f;

    [Header("Shared Settings")]
    public Transform[] spawnPoints;
    public float respawnDelay = 2f;
    public Transform player;

    private List<GameObject> activeTargets = new List<GameObject>();
    private GameObject currentSpecialObject;

    private bool isRespawning = false;
    private bool isSpecialRespawning = false;
    private int roundCounter = 0;

    public bool canSpawnTargets = false;



    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    void Update()
    {
        activeTargets.RemoveAll(target => target == null);

        if (canSpawnTargets)
        {
            if (activeTargets.Count == 0 && !isRespawning)
                StartCoroutine(RespawnAfterDelay());

            if (currentSpecialObject == null && !isSpecialRespawning && roundCounter > 1)
                StartCoroutine(RespawnSpecialAfterDelay());
        }
    }

    IEnumerator SpawnTargets()
    {
        yield return new WaitForSeconds(15);
        canSpawnTargets = true;
    }

    IEnumerator RespawnAfterDelay()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);

        // NEW: Randomize number of targets to spawn
        numberToSpawn = Random.Range(maxToSpawn, maxToSpawn);

        SpawnUniqueObjects(numberToSpawn);
        roundCounter++;

        if (roundCounter > 1 && roundCounter % 2 == 0 && currentSpecialObject == null)
        {
            SpawnSpecialObject();
        }

        isRespawning = false;
    }

    IEnumerator RespawnSpecialAfterDelay()
    {
        isSpecialRespawning = true;
        yield return new WaitForSeconds(specialRespawnDelay);

        SpawnSpecialObject();
        isSpecialRespawning = false;
    }

    void SpawnUniqueObjects(int count)
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null || player == null) return;

        if (count > spawnPoints.Length) count = spawnPoints.Length;

        List<Transform> sortedPoints = new List<Transform>(spawnPoints);
        sortedPoints.Sort((a, b) =>
            Vector3.Distance(a.position, player.position).CompareTo(Vector3.Distance(b.position, player.position)));

        for (int i = 0; i < count; i++)
        {
            Transform spawnPoint = sortedPoints[i];
            GameObject target = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            activeTargets.Add(target);
        }
    }

    void SpawnSpecialObject()
    {
        if (specialObjectToSpawn == null || spawnPoints.Length == 0 || player == null) return;

        List<Transform> availablePoints = new List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            bool occupied = false;

            foreach (GameObject target in activeTargets)
            {
                if (target != null && Vector3.Distance(target.transform.position, point.position) < 0.1f)
                {
                    occupied = true;
                    break;
                }
            }

            if (!occupied)
                availablePoints.Add(point);
        }

        if (availablePoints.Count == 0)
        {
            Debug.LogWarning("No available spawn point for special object.");
            return;
        }

        availablePoints.Sort((a, b) =>
            Vector3.Distance(a.position, player.position).CompareTo(Vector3.Distance(b.position, player.position)));

        Transform spawnPoint = availablePoints[0];
        currentSpecialObject = Instantiate(specialObjectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
