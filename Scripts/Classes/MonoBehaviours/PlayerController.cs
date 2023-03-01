using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float movementX;
    private float movementY;
    public float speed = 3;
    public float rotationSpeed = 30;
    CharacterController controller;
    Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        animator.SetBool("isRunning", movementY > 0);
    }

    void Update()
    {
        transform.Rotate(0, movementX * Time.deltaTime * rotationSpeed, 0);
        if (movementY > 0)
            controller.Move(transform.forward * speed * Time.deltaTime * movementY);
    }
}

