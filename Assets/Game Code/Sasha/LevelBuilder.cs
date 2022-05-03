using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class LevelBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject basementSample;
        [SerializeField] private GameObject floorSample;
        [SerializeField] private float floorHeight;
        [SerializeField] private int floorCount;

        [SerializeField] private GameObject box;
        [SerializeField] private float boxSize;
        [SerializeField] private int boxCount;


        private void Awake()
        {
            var elevatorController = FindObjectOfType<ElevatorController>();
            var floors = BuildFloors();
            elevatorController.SetFloors(floors);

            var boxes = BuildBoxes();

            foreach (var box in boxes)
            {
                var rFloor = Random.Range(1, floors.Length);
                var floor = floors[rFloor];
                var triggers = floor.GetComponentsInChildren<DeliveryTrigger>();
                var rDoor = Random.Range(0, triggers.Length);
                box.GetComponent<Box>().ID = triggers[rDoor].ID;
                box.GetComponentInChildren<TMPro.TextMeshPro>().text = $"{triggers[rDoor].ID}";
                Debug.Log($"Floor {rFloor}, door {rDoor}");
            }
        }

        private GameObject[] BuildFloors()
        {
            var floors = new GameObject[floorCount + 1];
            var floorSpawn = floorSample.transform.position;
            floors[0] = basementSample;
            floors[1] = floorSample;
            for (int i = 1; i < floorCount; i++)
            {
                floorSpawn.y += floorHeight;
                var floor = Instantiate(floorSample, floorSpawn, Quaternion.identity);
                var triggers = floor.GetComponentsInChildren<DeliveryTrigger>();
                var tablets = floor.GetComponentsInChildren<TMPro.TextMeshPro>();
                for (int door = 0; door < triggers.Length; door++)
                {
                    triggers[door].ID = Random.Range(1, 1000);
                    tablets[door].text = $"{triggers[door].ID}";
                }
                floors[i + 1] = floor;
            }
            return floors;
        }

        private GameObject[] BuildBoxes()
        {
            var boxes = new GameObject[boxCount];
            boxes[0] = box;
            for (int i = 1; i < boxCount; i++)
            {
                var boxSpawn = new Vector3(box.transform.position.x - i * boxSize / 2f, box.transform.position.y + i % 2 == 1 ? boxSize : 0, box.transform.position.z);
                boxes[i] = Instantiate(box, boxSpawn, Quaternion.identity);
            }
            return boxes;
        }

    }
}
