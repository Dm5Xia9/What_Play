using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class YSync : MonoBehaviour
    {
        [SerializeField] private Transform parent, child;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            var pos = child.position;
            child.position = new Vector3(pos.x, parent.position.y + offset.y, pos.z);
        }
    }
}