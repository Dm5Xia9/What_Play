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
        private Vector3 _direction;

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;

            switch (_direction.x)
            {
                case > 0:
                    characterModel.DORotate(new Vector3(0, 0, 0), rotateSpeed);
                    break;
                case < 0:
                    characterModel.DORotate(new Vector3(0, 180, 0), rotateSpeed);
                    break;
            }
        }
    }
}