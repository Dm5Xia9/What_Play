using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float moveSpeed;

        private Vector3 _moveVector;
        private Vector3 _direction;

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + _direction * moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}