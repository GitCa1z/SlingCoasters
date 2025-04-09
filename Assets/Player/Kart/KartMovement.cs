using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class KartMovement : MonoBehaviour
{

    SplineAnimate splineAnimate; // gets animate component from spline
    [SerializeField] float KartSpeed; // kartspeed variable
    bool hasStarted;

    private void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !hasStarted)
        {
            hasStarted = true;
            splineAnimate.Play();
            splineAnimate.MaxSpeed = KartSpeed * Time.deltaTime;
        }

    }
}
