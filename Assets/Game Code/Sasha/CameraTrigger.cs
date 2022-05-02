using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CameraTrigger : MonoBehaviour
    {
        //[SerializeField] private int cameraId;
        [SerializeField] private Transform trigerPosition;
        [SerializeField] private Vector3 relativeCameraPosition;
        [SerializeField] private float cameraFOV;

        private CameraController _cameraController;

        private void Awake()
        {
            _cameraController = FindObjectOfType<CameraController>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == 7)
            {
                Debug.Log($"Collision at {gameObject.name}");
                _cameraController.Move(trigerPosition, relativeCameraPosition, cameraFOV);
            }
        }
    }
}