using System;
using QFSW.QC;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] private Elevator elevator;
        [SerializeField] private Transform[] floors;
        [SerializeField] private int currentFloorIndex;

        private void Start()
        {
            elevator.SetTargetPos(floors[currentFloorIndex].position);
        }

        [Command("elevator.goUp")]
        public void MoveElevatorUp()
        {
            if (currentFloorIndex < floors.Length - 1)
            {
                currentFloorIndex++;
                elevator.SetTargetPos(floors[currentFloorIndex].position);
                Debug.Log($"Elevator moving to {floors[currentFloorIndex].name}");
            }
            else
            {
                Debug.LogWarning("Elevator can't go up");
            }
        }

        [Command("elevator.goDown")]
        public void MoveElevatorDown()
        {
            if (currentFloorIndex > 0)
            {
                currentFloorIndex--;
                elevator.SetTargetPos(floors[currentFloorIndex].position);
                Debug.Log($"Elevator moving to {floors[currentFloorIndex].name}");
            }
            else
            {
                Debug.LogWarning("Elevator can't go down");
            }
        }
    }
}