using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public TextMeshProUGUI txtLevel;
        public TextMeshProUGUI txtTime;
        public GameObject winPanel;
        public GameObject losePanel;
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnGameWin, OpenWinPanel);
            EventManager.AddHandler(GameEvent.OnGameLose, OpenLosePanel);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnGameWin, OpenWinPanel);
            EventManager.RemoveHandler(GameEvent.OnGameLose, OpenLosePanel);
        }
        public void OpenWinPanel()
        {
            winPanel.SetActive(true);
        }
        public void OpenLosePanel()
        {
            losePanel.SetActive(true);
        }
    }
}