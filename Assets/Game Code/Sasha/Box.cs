using UnityEngine;

namespace Game_Code.Sasha
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider collider;
        [SerializeField] private Renderer renderer;
        [SerializeField] private Color selectedColor, unselectedColor;

        public void PickUp(Transform picker)
        {
            rb.isKinematic = true;
            collider.enabled = false;
            transform.position = picker.position;
            transform.rotation = picker.rotation;
            transform.parent = picker;
        }

        public void Throw(Vector3 throwForce)
        {
            rb.isKinematic = false;
            rb.AddForce(throwForce, ForceMode.Impulse);
            collider.enabled = true;
        }
        
        public void Select()
        {
            renderer.material.color = selectedColor;
        }

        public void Unselect()
        {
            renderer.material.color = unselectedColor;
        }
    }
}