using System;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

namespace Game_Code.Sasha
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Transform characterModel;
        [SerializeField] private float rotateSpeed;

        private Direction _direction = Direction.Right;

        public void SetDirection(Direction direction)
        {
            _direction = direction;
            characterModel.DORotate(new Vector3(0, 90 - 90 * (int)_direction, 0), rotateSpeed);
        }
    }
}