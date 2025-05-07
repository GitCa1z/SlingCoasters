using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float rotationSpeed;
    public float timeBonus = 5f;
    private KartMovement kartMovement;


    private void Awake()
    {
     kartMovement = GameObject.FindGameObjectWithTag("Kart").GetComponent<KartMovement>();
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            PointManager.instance.IncrementCounter();
            kartMovement.updateSpeed(50);
           
            print("Hit!");

            GameTimer timer = FindObjectOfType<GameTimer>();

            if (timer != null)
            {
                timer.AddTime(timeBonus);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
