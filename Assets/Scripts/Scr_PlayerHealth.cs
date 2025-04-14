using Unity.VisualScripting;
using UnityEngine;

public class Scr_PlayerHealth : MonoBehaviour
{
    public GameObject player;
    private int health;
    private int maxHealth = 3;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (health == maxHealth)
        {
            Destroy(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) {
            health++;
            print("Health:" +health);
            Destroy(other.gameObject);
        }
    }
}
