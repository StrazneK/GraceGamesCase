using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Boosts
{
    public abstract class BoostClick : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            StartBoost();
        }
        public abstract void StartBoost();
    }
}