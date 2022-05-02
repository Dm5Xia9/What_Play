using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class YSync : MonoBehaviour
    {
        [SerializeField] private Transform parent, child;
        [SerializeField] private Vector3 offset;
        
        
        private void LateUpdate()
        {
            var pos = child.position;
            pos.y = parent.position.y + offset.y;
            child.position = pos;
        }
    }
}