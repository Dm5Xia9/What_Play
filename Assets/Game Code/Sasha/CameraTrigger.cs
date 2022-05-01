using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CameraTrigger: MonoBehaviour
    {
        [SerializeField] private int cameraId;
        private CameraController _cameraController;
        private void Awake()
        {
            _cameraController = FindObjectOfType<CameraController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Collision at {gameObject.name}");
            _cameraController.SetViewPoint(cameraId);
        }
    }
}