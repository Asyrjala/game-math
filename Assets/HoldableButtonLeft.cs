using UnityEngine;
using UnityEngine.EventSystems;

namespace GameMath.UI
{
    public class HoldableButtonLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool isPointerDown;
        private Transform crane;

        public bool IsHeldDown => isPointerDown;

        public void Awake()
        {
            crane = GameObject.Find("Tower Crane").transform;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            isPointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPointerDown = false;
        }
        public void FixedUpdate()
        {
            if (isPointerDown)
            {
                crane.Rotate(new Vector3(crane.rotation.x, crane.rotation.y - 5f, crane.rotation.z));
            }
        }


    }
}