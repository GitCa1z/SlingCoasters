using UnityEngine;

public class Target : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
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
