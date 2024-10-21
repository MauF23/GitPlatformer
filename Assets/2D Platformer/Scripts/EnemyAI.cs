using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        public float moveSpeed = 1f; 
        public LayerMask ground;
        public Transform flipSensorOrigin;
        public float rayWallLenght, rayGroundLenght;
        private Rigidbody2D rigidbody; 

        
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }

        void FixedUpdate()
        {
            FlipSensor();
		}
        
        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }

        private void FlipSensor()
        {
            // Si el sensor no registra el piso
            if (!Physics2D.Raycast(flipSensorOrigin.position, Vector2.down, rayGroundLenght, ground))
            {
                Flip();
            }


            // Si el sensor registra una pared
			if (Physics2D.Raycast(flipSensorOrigin.position, Vector2.right, rayWallLenght, ground))
			{
				Flip();
			}

            Debug.DrawRay(flipSensorOrigin.position, Vector2.down * rayGroundLenght, Color.green);
            Debug.DrawRay(flipSensorOrigin.position, Vector2.right * rayWallLenght, Color.red);
		}
    }
}
