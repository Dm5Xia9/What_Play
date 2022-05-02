using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public enum Direction
    {
        Left = -1,
        Right = 1,
    }

    public class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float moveSpeed;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private CharacterPickup pickup;

        private Vector3 _moveVector;
        private Direction _direction;

        private void Start()
        {
            _direction = Direction.Left;
            characterAnimator.SetDirection(_direction);
            pickup.SetDirection(_direction);
        }

        public void SetDirection(Vector3 direction)
        {
            _moveVector = direction * moveSpeed;
            if (direction.x > 0)
                _direction = Direction.Right;
            if (direction.x < 0)
                _direction = Direction.Left;
            characterAnimator.SetDirection(_direction);
            pickup.SetDirection(_direction);
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + _moveVector * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        public void InteractionWithBox()
        {
            if (!pickup || !pickup.carryingBox)
                pickup.PickUpBox();
            else
                pickup.ThrowBox(_moveVector * moveSpeed);
        }
    }
}