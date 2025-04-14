using UnityEngine;

public class Scr_AmmoCreate : MonoBehaviour
{
    private Bullet bullet;
    void Awake()
    {
     bullet = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Bullet>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            bullet.ammo++;
            print(bullet.ammo);
            Destroy(gameObject);
        }
    }
}
