using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CharacterPickup : MonoBehaviour
    {
        [SerializeField] private Transform searchStart;
        [SerializeField] private Transform pickUpPlace;
        [SerializeField] private float searchRadius;
        [SerializeField] private Vector3 throwVector;
        [SerializeField] private LayerMask searchLayers;
        private Vector3 _direction;
        private Box _possibleSelection;

        public Box carryingBox;
        
        private void Update()
        {
            var hits = Physics.OverlapSphere(searchStart.position, searchRadius, searchLayers);

            if (hits.Length > 0)
            {
                if (_possibleSelection)
                {
                    _possibleSelection.UnSelectColor();
                }
                
                var hit = hits[0];
                
                _possibleSelection = hit.transform.parent.GetComponent<Box>();
                _possibleSelection.SelectBox();
            }
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void PickUpBox()
        {
            _possibleSelection.PickUp();
            _possibleSelection.transform.position = pickUpPlace.position;
            _possibleSelection.transform.rotation = pickUpPlace.rotation;
            _possibleSelection.transform.parent = pickUpPlace;
            carryingBox = _possibleSelection;
        }

        public void ThrowBox()
        {
            _possibleSelection.transform.parent = null;
            throwVector.x = Mathf.Sign(_direction.normalized.x) * throwVector.x;
            carryingBox.Throw(throwVector);
            carryingBox = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(searchStart.position, searchRadius);
        }
    }
}