using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Buttons
{
    public class PauseButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            GameManager.Instance.ChangeGameState(!GameManager.Instance.IsGamePlaying());
        }
    }
}