using System;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                character.InteractionWithBox();
            character.SetDirection(Input.GetAxis("Horizontal") * character.transform.right);
        }

    }
}