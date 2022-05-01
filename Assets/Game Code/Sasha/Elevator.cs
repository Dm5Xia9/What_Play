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
        private Vector3 _middlePoint;

        private void FixedUpdate()
        {
            var position = elevatorRb.position;
            var direction = (targetPos - position).normalized;
            var distance = Vector3.Distance(position, targetPos);

            var speedCoef = Mathf.Abs(position.y) / Mathf.Abs(_middlePoint.y);
            speedCoef = speedCoef > 1 ? 2 - speedCoef : speedCoef;
            if (print)
            {
                Debug.Log(speedCoef);
            }

            var moveVector = direction * moveSpeed * speedCoef * Time.deltaTime;

            if (moveVector.magnitude > 0.05f)
                elevatorRb.MovePosition(position + moveVector);
        }

        public void SetTargetPos(Vector3 pos)
        {
            targetPos = pos;
            _middlePoint = (elevatorRb.position - targetPos);
        }
    }
}