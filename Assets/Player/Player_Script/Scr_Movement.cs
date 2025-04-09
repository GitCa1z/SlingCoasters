using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(CharacterController))]

public class Scr_Movement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController characterController;
    private Vector2 _movementInput;

    private Vector3 _playerDirection;
    private Vector3 jumpPower;
    [SerializeField] float playerSpeed = 10f;
    public GameObject cart;
    public bool inSeat;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cart = GameObject.FindGameObjectWithTag("KartSeat");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inSeat) {
        characterController.Move(_playerDirection);

        }
    }

    public void MovementController(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        _playerDirection = new Vector3(-_movementInput.x * playerSpeed,0,-_movementInput.y * playerSpeed) * Time.deltaTime;
    }

    public void JumpController(InputAction.CallbackContext context) {

        if (!context.started) return;

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !inSeat)
        {
            inSeat = true;
            gameObject.transform.parent = cart.transform;
            gameObject.transform.localPosition = new Vector2(0,0);
            rb.isKinematic = true;

            


        }
    }
}
