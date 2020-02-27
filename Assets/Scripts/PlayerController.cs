using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    //#region Jump System
    public bool isGrounded
    {
        get {
            float rayDistance = 0.01f;
            return Physics.Raycast(transform.position + (Vector3.up * rayDistance), Vector3.down, rayDistance);
        }
    }
    public float jumpForce = 1f;    // force to add to the rigidbody to make it jump
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
    //#endregion


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
