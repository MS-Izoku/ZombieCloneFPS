using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Entities;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public Camera cam;

    //#region Camera Movement System
    public float camMoveSpeed = 1;
    public bool cameraBob = false;

    private void MoveCam()
    {
        // Mouse look with sensitivity based on camMoveSpeed
    }
    //#endregion

    //#region Movement System
    public bool isMoving = false;
    public float moveSpeedForward = 1f;
    public float moveSpeedBackPedal = 1f;
    public float moveSpeedStrafe = 1f;

    private void MovePlayer()
    {
        // move speed based on moveSpeed variable family
    }

    public float moveSpeedSprint = 2f;
    private void Sprint()
    {
        // increase speed to moveSpeedSprint
        IEnumerator speedUp()
        {

            yield return null;
        }
        StartCoroutine(speedUp());
    }
    //#endregion

    //#region Moving Platform Handler
    [HideInInspector] public Transform platform;    // platform the player is currently on
    //#endregion

    //#region Jump System
    public float rayDistance;   // distance to check the ray, should be the size of the collider/2
    public bool isGrounded
    {
        get {
            // cast to the ground and see if it hits
            return Physics.Raycast(transform.position + (Vector3.up * rayDistance), Vector3.down, rayDistance);
        }
    }
    public float jumpForce = 1f;    // force to add to the rigidbody to make it jump
    private void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("JUMP");  // keeping until jumpcheck goes through
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    //#endregion

    //#region Input Control
    float moveHor;
    float moveVert;
    private Vector2 wasdInput;
    private Vector3 velocity;

    public void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void OnWalk(InputValue inputValue)
    {
        wasdInput = inputValue.Get<Vector2>();
        ProcessInput();
        if (wasdInput != Vector2.zero) Debug.Log("NOT ZERO");
    }

    private void ProcessInput()
    {
        Debug.Log("Processing Input");
        if (wasdInput.x > 0) velocity += Vector3.right * moveSpeedStrafe;
        else if (wasdInput.x < 0) velocity += Vector3.left * moveSpeedStrafe;

        if (wasdInput.y > 0) velocity += Vector3.forward * moveSpeedForward;
        else if (wasdInput.y < 0) velocity += Vector3.back * moveSpeedBackPedal;

        if (wasdInput == Vector2.zero) velocity = Vector2.zero;
        rb.velocity = velocity;
    }
    //#endregion

    private void Start()
    {
        //#region ADD TO JUMP SYSTEM
        rb = GetComponent<Rigidbody>();
        rayDistance = GetComponent<CapsuleCollider>().height / 2;

        //#endregion
    }


    private void Update()
    {
        // NOTE: When ECS is implemented, this will need to be broken up into seperate scripts
        GetInputs();
    }
}
