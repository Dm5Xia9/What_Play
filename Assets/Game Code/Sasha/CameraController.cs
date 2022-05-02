using System;
using System.Collections.Generic;
using System.Linq;
using QFSW.QC;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float moveSpeed, scopeSpeed;

        private Vector3 _targetPosition;
        private float _targetFOV;

        private void Awake()
        {
            camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, _targetPosition, moveSpeed * Time.deltaTime);
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, _targetFOV, scopeSpeed * Time.deltaTime);
        }

        public void Move(Vector3 position, float fov)
        {
            Debug.Log(position);
            _targetPosition = position;
            _targetFOV = fov;
        }
    }
}