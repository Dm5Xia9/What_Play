using UnityEngine;

namespace Game_Code.Sasha
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider collider;
        [SerializeField] private Renderer renderer;
        [SerializeField] private Color selectedColor, unselectedColor;

        public void PickUp()
        {
            rb.isKinematic = true;
            collider.enabled = false;
        }

        public void Throw(Vector3 throwForce)
        {
            rb.isKinematic = false;
            rb.AddForce(throwForce, ForceMode.Impulse);
            collider.enabled = true;
        }
        
        public void SelectBox()
        {
            renderer.material.color = selectedColor;
        }

        public void UnSelectColor()
        {
            renderer.material.color = unselectedColor;
        }
    }
}