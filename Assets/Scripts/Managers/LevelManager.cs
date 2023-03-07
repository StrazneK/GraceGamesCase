using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

namespace Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        public List<LevelSO> levelSOs = new List<LevelSO>();
        int level;
        LevelSO selectedLvlSo;
        private void Start()
        {
            level = PlayerPrefs.GetInt("Level", 1); //Get Saved Level
            SelectLevelSO();
            CreateLevel();
        }
        void SelectLevelSO() //Get required levelSO
        {
            selectedLvlSo = levelSOs[level - 1];
        }
        public void CreateLevel()
        {
            UIManager.Instance.txtLevel.text = "Level " + level.ToString();
            TimeManager.Instance.StartTimer(selectedLvlSo.time);
        }
        public void NextLevel()
        {
            level++;
            PlayerPrefs.SetInt("Level", level);
        }
    }
}