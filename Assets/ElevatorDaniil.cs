using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class ElevatorDaniil : MonoBehaviour
    {
        [SerializeField] private Rigidbody elevatorRb;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private float moveSpeed, lerpCoef;

        private Vector3 _oldPos;

        private void FixedUpdate()
        {
            var position = elevatorRb.position;
            var direction = (targetPos - position).normalized;

            var distance = Mathf.Min(
                Vector3.Distance(_oldPos, position),
                Vector3.Distance(targetPos, position)
            );
            var boostDistance = moveSpeed * lerpCoef;
            var speedCoef = 1.0f;
            if (distance < boostDistance)
                speedCoef = Mathf.Pow(distance, 0.8f) / Mathf.Pow(boostDistance, 0.8f);
            speedCoef = speedCoef < 0.05f ? 0.05f : speedCoef;

            //Debug.Log(speedCoef);

            if (Vector3.Distance(targetPos, position) > 0.05f)
                elevatorRb.MovePosition(position + direction * (speedCoef * moveSpeed) * Time.deltaTime);
        }

        public void SetTargetPos(Vector3 pos)
        {
            _oldPos = targetPos;
            targetPos = pos;
        }
    }
}