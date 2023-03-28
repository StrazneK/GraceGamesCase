using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using Other;
using Level;

namespace Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        int level;

        private void Start()
        {
            level = PlayerPrefs.GetInt("Level", 1); //Get Saved Level
            CreateLevel();
        }
        public void CreateLevel()
        {
            ConfigureLevel.Instance.ConfigLevel(level);
        }
        public void NextLevel()
        {
            level++;
            PlayerPrefs.SetInt("Level", level);
        }
    }
}