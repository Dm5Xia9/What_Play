using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CharacterPickup : MonoBehaviour
    {
        [SerializeField] private Transform searchStart;
        [SerializeField] private Transform pickUpPlace;
        [SerializeField] private Vector3 handVector;
        [SerializeField] private Vector3 throwVector;
        [SerializeField] private LayerMask searchLayers;

        private Direction _direction;
        private Box _selectedBox;

        public Box carryingBox;

        private Box SearchPossibleBox()
        {
            var searchSize = new Vector3(handVector.magnitude, handVector.magnitude, 0);
            var hits = Physics.OverlapBox(searchStart.position + (int)_direction * handVector, searchSize, Quaternion.identity, searchLayers);
            if (hits.Length == 0)
                return null;
            return hits[0].transform.parent.GetComponent<Box>();
        }

        private void Update()
        {
            if (_selectedBox)
                _selectedBox.Unselect();
            _selectedBox = SearchPossibleBox();
            if (_selectedBox)
                _selectedBox.Select();
        }

        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }

        public void PickUpBox()
        {
            if (!_selectedBox)
                return;
            _selectedBox.PickUp(pickUpPlace);
            carryingBox = _selectedBox;
            _selectedBox = null;
        }

        public void ThrowBox(Vector3 characterSpeed)
        {
            carryingBox.transform.parent = null;
            var moveVector = 2 * characterSpeed + new Vector3((int)_direction * throwVector.x, throwVector.y, throwVector.z);
            carryingBox.Throw(moveVector);
            carryingBox = null;
        }

        private void OnDrawGizmos()
        {
            var searchSize = new Vector3(handVector.magnitude, handVector.magnitude, 0);
            Gizmos.DrawCube(searchStart.position + handVector, searchSize);
        }
    }
}