using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private Rigidbody elevatorRb;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private float moveSpeed, lerpCoef;
        [SerializeField] private bool print;

        private Vector3 _oldPos;

        private void FixedUpdate()
        {
            var position = elevatorRb.position;
            var direction = (targetPos - position).normalized;
            if (print)
                Debug.Log(direction);
            var distance = Mathf.Min(
                Vector3.Distance(_oldPos, position),
                Vector3.Distance(targetPos, position)
            );

            var boostDistance = moveSpeed * lerpCoef;
            var speedCoef = 1.0f;
            if (distance < boostDistance)
                speedCoef = Mathf.Sqrt(Mathf.Pow(boostDistance, 2) - Mathf.Pow(distance, 2)) / boostDistance;
            if (speedCoef < 0.1)
                speedCoef = 0.1f;
            var velocity = (1 - speedCoef) * moveSpeed;

            var moveVector = direction * velocity * Time.deltaTime;
            var newPosition = position + moveVector;

            if (moveVector.magnitude < 0.05f * Time.deltaTime)
            {
                newPosition = targetPos;
            }

            elevatorRb.MovePosition(newPosition);
        }

        public void SetTargetPos(Vector3 pos)
        {
            _oldPos = targetPos;
            targetPos = pos;
        }
    }
}