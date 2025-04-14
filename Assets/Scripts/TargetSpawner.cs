using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    
    public GameObject objectToSpawn;

    
    public Transform[] spawnPoints;

    void Start()
    {
        SpawnAtRandomLocation();
    }

    public void SpawnAtRandomLocation()
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null)
        {
            Debug.LogWarning("Missing spawn points or object to spawn.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
