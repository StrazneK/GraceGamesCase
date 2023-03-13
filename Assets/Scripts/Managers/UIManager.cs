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