using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LongMethod
{
    public class CharacterController : MonoBehaviour
    {
        void Update()
        {
            // Keeps cursor locked in game window
            Cursor.lockState = CursorLockMode.Locked;

            var mov = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward) .normalized;
            transform.position += mov * Time.deltaTime * 7;

            if (Input.GetButtonDown("Jump"))
                GetComponent<Rigidbody>().velocity = Vector3.up * 10;



            transform.localRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 45 * Input.GetAxis("Mouse X") * Time.deltaTime, 0);

            var t = transform.Find("Main Camera").transform;
            var xRot = t.localRotation.eulerAngles.x - 45 * Input.GetAxis("Mouse Y") * Time.deltaTime;
            if (xRot > 35) xRot = 35; else if (xRot < 10) xRot = 10;
            t.localRotation = Quaternion.Euler(xRot, 0, 0);


        }

        void Awake()
        {

        }

        void Start() {}
    }
}
