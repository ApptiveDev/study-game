using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KJS
{
    public class PlayerControllerBasic : MonoBehaviour
    {
        private Rigidbody playerRigidBody;
        public float speed = 7f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(xInput, yInput, 0);

            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
