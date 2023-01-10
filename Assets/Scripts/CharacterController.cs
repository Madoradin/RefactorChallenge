using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LongMethod
{
    public class CharacterController : MonoBehaviour
    {
        //Declare movement modifiers and boundaries and make them editable so changing values does not require 
        //digging into and changing functions
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpSpeed = 10f;

        //Declare min and max boundaries for the camera rotation and make them editable as well
        [SerializeField] private float minRotate = 10f;
        [SerializeField] private float maxRotate = 35f;
        [SerializeField] private float offsetAngle = 45f;

        //Declare frequently used Game Objects and initialize them on awake once so they aren't repeatedly done on every update
        private Transform cameraTransform;
        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cameraTransform = transform.Find("Main Camera").transform;
        }

        void Update()
        {
            // Keeps cursor locked in game window
            Cursor.lockState = CursorLockMode.Locked;

            //Split character movement into separate methods
            MoveCharacter();
            JumpCharacter();
            RotateCharacter();

            //Extract a method from the camera rotation code
            RotateCamera();

        }

        //Handles character walking
        void MoveCharacter()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var moveDirection = new Vector3(horizontal, 0, vertical);

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        //Handles character jumping
        void JumpCharacter()
        {
            if (Input.GetButtonDown("Jump"))
                rb.velocity = Vector3.up * jumpSpeed;
        }

        //handles character rotation
        void RotateCharacter()
        {
            var rotationDirection = Input.GetAxis("Mouse X");
            var rotatevalue = transform.rotation.eulerAngles.y + offsetAngle * rotationDirection * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0,rotatevalue,0);
        }


        //handles camera rotation
        void RotateCamera()
        {
            var rotationDirection = cameraTransform.localRotation.eulerAngles.x - offsetAngle * Input.GetAxis("Mouse Y") * Time.deltaTime;
            var xRotation = Mathf.Clamp(rotationDirection, minRotate, maxRotate);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }



        void Start() {}
    }
}
