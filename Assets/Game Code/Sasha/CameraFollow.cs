using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Transform cameraRoot, target;
        [SerializeField] private Vector3 targetOffset;
        [SerializeField] private float moveSpeed;

        private float _targetZoom;

        private void Update()
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, _targetZoom, moveSpeed * Time.deltaTime);
        }


        private void LateUpdate()
        {
            //cameraRoot.position = target.position + targetOffset;
            cameraRoot.position = Vector3.MoveTowards(cameraRoot.position, target.position + targetOffset,
                moveSpeed * Time.deltaTime);
        }

        public void SetViewPoint(CameraViewPoint viewPoint)
        {
            target = viewPoint.transform;
            _targetZoom = viewPoint.cameraZoom;
        }
    }
}