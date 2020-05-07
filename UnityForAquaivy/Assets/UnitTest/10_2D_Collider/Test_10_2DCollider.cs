using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NameSpace_Test_10_2DCollider
{
    public class Test_10_2DCollider : MonoBehaviour
    {
        public Rigidbody2D Rigidbody1;

        [Range(0, 1000)]
        public float Force = 10;
        [Range(0, 3)]
        public float Move = 1;

        [Range(0, 1)]
        public float MoveDrag = 0.02f;

        private void Start()
        {

        }

        float move_x = 0;
        float move_y = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Rigidbody1.transform.position = new Vector3(-15, -5, 0);
            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                move_y = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move_x = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                move_x = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                move_y = -1;
            }

            Rigidbody1.MovePosition(Rigidbody1.position + new Vector2(move_x, move_y) * Move);

            move_x *= (1 - MoveDrag);
            move_y *= (1 - MoveDrag);
        }

        private void Fire()
        {
            Rigidbody1.AddForce(Vector2.right * Force);
        }
    }
}
