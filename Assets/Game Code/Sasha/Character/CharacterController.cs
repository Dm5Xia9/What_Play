using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private CharacterPickup pickup;

        private Vector3 _direction;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(pickup.carryingBox)
                    pickup.ThrowBox();
                else
                    pickup.PickUpBox();
            }
            var horizontal = Input.GetAxis("Horizontal") * character.transform.right;
            _direction = horizontal;
            
            character.SetDirection(_direction);
            characterAnimator.SetDirection(_direction);
            pickup.SetDirection(_direction);
        }

    }
}