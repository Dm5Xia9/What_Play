using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float moveSpeed;
        
        private Vector3 _direction;

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal") * rb.transform.right;
            _direction = horizontal;
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