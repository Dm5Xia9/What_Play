using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Code.Sasha
{
    public class DeliveryTrigger : MonoBehaviour
    {
        public int ID { get; set; }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.name == "Box Collider")
                if (collider.gameObject.GetComponentInParent<Box>().ID == ID)
                    Debug.Log($"Delivery {ID}");
        }
    }
}
