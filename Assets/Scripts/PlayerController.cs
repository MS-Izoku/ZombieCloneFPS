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
    private CapsuleCollider collider;
    public Camera cam;

    public Gun[] guns;

    #region Gernade System
    public Gernade[] gernades;
    public int[] gernadeCount;

    private void OnGernadeThrow()
    {

    }

    #endregion

    #region Camera Movement System
    public float camMoveSpeed = 1;
    public bool cameraBob = false;

    private void MoveCam()
    {
        Debug.Log("Move Camera");
        // Mouse look with sensitivity based on camMoveSpeed
    }
    #endregion

    #region Movement System

    float moveHor;
    float moveVert;
    private Vector2 wasdInput;
    private Vector3 velocity;

    public bool isMoving = false;
    public float moveSpeedForward = 1f;
    public float moveSpeedBackPedal = 1f;
    public float moveSpeedStrafe = 1f;

    private void OnWalk(InputValue inputValue)
    {

        wasdInput = inputValue.Get<Vector2>();

        if (wasdInput.x != 0)
            velocity += new Vector3(wasdInput.x, 0, 0) * moveSpeedStrafe * Time.deltaTime;
        else velocity.x = 0;

        if (wasdInput.y > 0)
        {
            velocity += transform.forward  * moveSpeedForward * Time.deltaTime;
        }
        else if(wasdInput.y < 0)
        {
            velocity += transform.forward * -moveSpeedBackPedal * Time.deltaTime;
        }
        else velocity.z = 0;

       // Debug.Log("Walk " + velocity);
    }

    public float moveSpeedSprint = 2f;
    private void OnSprint()
    {
        
    }
    #endregion

    //#region Moving Platform Handler
    [HideInInspector] public Transform platform;    // platform the player is currently on
    //#endregion

    #region Jump System
    public float rayDistance;   // distance to check the ray, should be the size of the collider/2
    public float jumpForce = 1f;    // force to add to the rigidbody to make it jump
    private void OnJump()
    {
            Debug.Log("JUMP");  // keeping until jumpcheck goes through
            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
    }
    #endregion

    #region Points System
    public int points = 0;

    public void GetPoints(int quantity)
    {
        points += quantity;
    }
    
    public void LosePoints(int quantity)
    {
        points = Mathf.Clamp(points - quantity, 0, 999999999);
    }
    #endregion




    private void Start()
    {
        //#region ADD TO JUMP SYSTEM
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        rayDistance = GetComponent<CapsuleCollider>().height / 2;

        //#endregion
    }

    private void OnShoot()
    {
        Debug.Log("Shoot");
    }

    private void OnAimDownSight()
    {
        Debug.Log("Aim Down Sight");
    }

    private void OnSwitchWeapon()
    {
        Debug.Log("Switch Weapon");
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x , rb.velocity.y , velocity.z);
        //rb.AddForce(velocity , );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        Gizmos.DrawWireCube(transform.position, new Vector3(collider.radius *2 , collider.height, collider.radius * 2));
    }

    public void GiveItem(Gun gunPrefab)
    {

    }

    public void GiveItem(Gernade gernadePrefab)
    {

    }
}
