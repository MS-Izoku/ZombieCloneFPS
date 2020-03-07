using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerControllerV2 : MonoBehaviour
{
        private Rigidbody rb;
        private CapsuleCollider collider;
        public Camera cam;

        public List<Gun> guns = new List<Gun>();
        public Gun equippedGun;
        public int maxGuns = 2;

        #region Gernade System
        public List<Gernade> gernades = new List<Gernade>();
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
        Debug.Log("Walk");
            wasdInput = inputValue.Get<Vector2>();
            if (wasdInput == Vector2.zero) return;
            velocity = new Vector3(wasdInput.x , 0 , wasdInput.y).normalized * moveSpeedForward;
        }

        public float sprintMultiplier = 2f;
        public float stamina = 100f;
        public float staminaRecovery = 1f;
        private float maxStamina;
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

        #region Gun Buying
        public void GiveItem(Gun gunPrefab)
        {
            if (guns.Count > maxGuns)
            {

            }
            else
            {
                guns.Add(gunPrefab);
            }

        }

        public void GiveItem(Gernade gernadePrefab)
        {

        }

        public void GiveTemporaryItem(Gun gunPrefab)
        {

        }

        public void GiveTemporaryItem(Gernade gernadePrefab)
        {

        }
        #endregion

        private void OnShoot()
        {
            Debug.Log("Shoot");
        }

        [HideInInspector] public Transform reticleTarget;
        private void OnAimDownSight(InputValue value)
        {
            Debug.Log("Aim Down Sight");
        }

        private void OnSwitchWeapon()
        {
            Debug.Log("Switch Weapon");
        }


        private void Start()
        {
            //#region ADD TO JUMP SYSTEM
            rb = GetComponent<Rigidbody>();
            collider = GetComponent<CapsuleCollider>();
            rayDistance = GetComponent<CapsuleCollider>().height / 2;
            maxStamina = stamina;
            //#endregion
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
            //rb.AddForce(velocity , );
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            CapsuleCollider collider = GetComponent<CapsuleCollider>();
            Gizmos.DrawWireCube(transform.position, new Vector3(collider.radius * 2, collider.height, collider.radius * 2));
        }
    }

