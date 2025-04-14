using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject objectToSpawn;   // The object to spawn and shoot
    public Transform spawnPoint;       // Where to spawn the object 
    public float launchForce = 10f;    // The force to launch the object
    public float despawnTime = 5f;     // Time in seconds before the object despawns
    public int ammo = 5;
    public int ammoEmpty = 0;

    void Update()
    {
        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0))  // 0 is the left mouse button
        {
            if (ammo > ammoEmpty)
            {
                SpawnAndShootObject();
                --ammo;
                print(ammo);
            }

            else print("Out of Ammo!");
            
        }


    }

    void SpawnAndShootObject()
    {
        // Instantiate the object at the spawn point 
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);

        // Get the forward direction of the player 
        Vector3 forwardDirection = spawnPoint.forward;  

        // Launch the object forward
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(forwardDirection * launchForce, ForceMode.VelocityChange);
        }

        // Destroy the object after the set amount of time
        Destroy(spawnedObject, despawnTime);
    }
}
