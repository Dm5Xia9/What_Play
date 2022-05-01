using System;
using QFSW.QC;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] private ElevatorSasha elevatorSasha;
        [SerializeField] private Transform[] floors;
        [SerializeField] private int currentFloorIndex;

        private void Start()
        {
            elevatorSasha.SetTargetPos(floors[currentFloorIndex].position);
        }

        [Command("elevator.goUp")]
        public void MoveElevatorUp()
        {
            if (currentFloorIndex < floors.Length - 1)
            {
                currentFloorIndex++;
                elevatorSasha.SetTargetPos(floors[currentFloorIndex].position);
                Debug.Log($"Elevator moving to {floors[currentFloorIndex].name}");
            }
            else
            {
                Debug.LogWarning("Elevator can't go up");
            }
        }

        [Command("elevator.goToFloor")]
        public void MoveToIndex(int index)
        {
            currentFloorIndex = index;
            elevatorSasha.SetTargetPos(floors[index].position);

        }

        [Command("elevator.goDown")]
        public void MoveElevatorDown()
        {
            if (currentFloorIndex > 0)
            {
                currentFloorIndex--;
                elevatorSasha.SetTargetPos(floors[currentFloorIndex].position);
                Debug.Log($"Elevator moving to {floors[currentFloorIndex].name}");
            }
            else
            {
                Debug.LogWarning("Elevator can't go down");
            }
        }
    }
}