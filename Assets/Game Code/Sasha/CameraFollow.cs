using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform cameraRoot, target;
        [SerializeField] private Vector3 targetOffset;
        [SerializeField] private float moveSpeed;

        private void LateUpdate()
        {
            cameraRoot.position = target.position + targetOffset;
            /*cameraRoot.position = Vector3.MoveTowards(cameraRoot.position, target.position + targetOffset,
                moveSpeed * Time.deltaTime);*/
        }
    }
}