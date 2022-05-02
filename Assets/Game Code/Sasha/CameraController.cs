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

        private Transform _target;
        private Vector3 _targetOffset;
        private float _targetFOV;

        private void Awake()
        {
            camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, _target.position + _targetOffset, moveSpeed * Time.deltaTime);
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, _targetFOV, scopeSpeed * Time.deltaTime);
        }

        public void Move(Transform target, Vector3 offset, float fov)
        {
            _target = target;
            _targetOffset = offset;
            _targetFOV = fov;
        }
    }
}