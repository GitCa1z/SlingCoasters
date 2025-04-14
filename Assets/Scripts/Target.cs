using UnityEngine;

public class Target : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, 0.1f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PointManager.instance.IncrementCounter();
            Destroy(gameObject);
            print("Hit!");
        }
    }
}
