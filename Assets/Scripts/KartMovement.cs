using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class KartMovement : MonoBehaviour
{
    private SplineAnimate splineAnimate;
    public float KartSpeed; // Initial speed set in the inspector
    public float transitionSpeed = 2f; // Speed of the smooth transition

    private float currentSpeed;
    private float targetSpeed;
    private bool hasStarted;


    private void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();
        splineAnimate.MaxSpeed = 500;
        currentSpeed = KartSpeed * Time.deltaTime;
        targetSpeed = currentSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !hasStarted)
        {
            hasStarted = true;
            splineAnimate.Play();
        }

        // Smoothly move currentSpeed toward targetSpeed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * transitionSpeed);
        splineAnimate.MaxSpeed = currentSpeed;
    }

    public void updateSpeed(float speed)
    {
        // Increase target speed gradually
        targetSpeed += speed * Time.deltaTime;
    }
}