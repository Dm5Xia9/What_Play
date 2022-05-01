using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class ElevatorSasha : MonoBehaviour
    {
        [SerializeField] private Rigidbody elevatorRb;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private float moveSpeed, lerpCoef;
        [SerializeField] private bool print;
        private Vector3 _middlePoint;
        private bool _movingUp;

        private void FixedUpdate()
        {
            var position = elevatorRb.position;
            var direction = (targetPos - position).normalized;
            var distance = Vector3.Distance(position, targetPos);

            var speedCoef = Mathf.Abs(position.y) / Mathf.Abs(_middlePoint.y);
            speedCoef = _movingUp && position.y > targetPos.y ? speedCoef / 2 : speedCoef;
            speedCoef = speedCoef > 1 ? 2f - speedCoef : speedCoef;
            speedCoef = Mathf.Approximately(speedCoef, 0f) ? 0.05f : speedCoef;
            speedCoef *= lerpCoef;

            if (print)
            {
                Debug.Log(speedCoef);
            }

            var moveVector = direction * moveSpeed * speedCoef * Time.deltaTime;
            var newPosition = position + moveVector;

            if (distance < 0.2f)
            {
                newPosition = targetPos;
                elevatorRb.MovePosition(newPosition);
            }

            if (!Mathf.Approximately(moveVector.magnitude,0f))
                elevatorRb.MovePosition(newPosition);
        }

        public void SetTargetPos(Vector3 pos)
        {
            targetPos = pos;
            _middlePoint = (elevatorRb.position + targetPos) / 2;
            _movingUp = elevatorRb.position.y < targetPos.y;
        }
    }
}