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
        public Transform winPanel;
        public Transform losePanel;

    }
}