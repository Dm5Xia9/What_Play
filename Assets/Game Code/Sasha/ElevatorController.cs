using System;
using QFSW.QC;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] private ElevatorSasha elevatorSasha;
        [SerializeField] private int currentFloorIndex;

        private Transform[] _floors;

        public void SetFloors(GameObject[] floors)
        {
            _floors = new Transform[floors.Length];
            for (int f = 0; f < floors.Length; f++)
                _floors[f] = floors[f].transform;
            elevatorSasha.SetTargetPos(_floors[currentFloorIndex].position);
        }

        public void SetFloors(Transform[] floors)
        {
            _floors = floors;
            elevatorSasha.SetTargetPos(_floors[currentFloorIndex].position);
        }

        [Command("elevator.goUp")]
        public void MoveElevatorUp()
        {
            if (currentFloorIndex < _floors.Length - 1)
            {
                currentFloorIndex++;
                elevatorSasha.SetTargetPos(_floors[currentFloorIndex].position);
                Debug.Log($"Elevator moving to {_floors[currentFloorIndex].name}");
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
            elevatorSasha.SetTargetPos(_floors[index].position);

        }

        [Command("elevator.goDown")]
        public void MoveElevatorDown()
        {
            if (currentFloorIndex > 0)
            {
                currentFloorIndex--;
                elevatorSasha.SetTargetPos(_floors[currentFloorIndex].position);
                Debug.Log($"Elevator moving to {_floors[currentFloorIndex].name}");
            }
            else
            {
                Debug.LogWarning("Elevator can't go down");
            }
        }
    }
}