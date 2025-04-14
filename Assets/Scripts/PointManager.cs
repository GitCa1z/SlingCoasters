using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    public Text counterText; 

    private int TargetCount = 0;
    


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void IncrementCounter()
    {
        TargetCount++;
        counterText.text = "Target_Counter: " + TargetCount;
    }
}

  
