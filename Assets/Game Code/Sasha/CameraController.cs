using System;
using System.Collections.Generic;
using System.Linq;
using QFSW.QC;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraFollow cameraFollow;
        [SerializeField] private CameraViewPoint defaultViewPoint;
        private Dictionary<int, CameraViewPoint> _cameraViewPoints;

        private void Awake()
        {
            _cameraViewPoints = FindObjectsOfType<CameraViewPoint>().ToDictionary(x => x.id, y => y);
        }

        private void Start()
        {
            cameraFollow.SetViewPoint(defaultViewPoint);
        }

        [Command("camera.setViewPoint")]
        public void SetViewPoint(int index)
        {
            cameraFollow.SetViewPoint(_cameraViewPoints[index]);
        }

    }
}