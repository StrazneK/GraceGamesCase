using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using UnityEngine.Events;
using Managers;
using Foodpack;
using System;
using UI.Cards;
using Other;

namespace Level
{
    public class ConfigureLevel : MonoSingleton<ConfigureLevel>
    {
        #region Level
        LevelSO selectedLvlSO;
        int level;
        #endregion
        public List<FoodpackSO> requiredFoodpacks = new List<FoodpackSO>();
        public List<FoodpackSO> otherFoodpacks = new List<FoodpackSO>();
        void SelectLevelSO() => selectedLvlSO = PoolManager.Instance.GetLevel(level - 1);

        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnGameStart, ConfigLabels);
            EventManager.AddHandler(GameEvent.OnGameStart, SpawnObjects);
            EventManager.AddHandler(GameEvent.OnGameStart, FillRequirementCards);

            //  configLevelDelegate += ConfigLabels;
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnGameStart, ConfigLabels);
            EventManager.RemoveHandler(GameEvent.OnGameStart, SpawnObjects);
            EventManager.RemoveHandler(GameEvent.OnGameStart, FillRequirementCards);
        }
        public void ConfigLevel(int _level)
        {
            level = _level;
            SelectLevelSO();
            ConfigSettings();
        }
        void ConfigSettings()
        {
            for (int i = 0; i < selectedLvlSO.requiredFoodpackCount; i++)
            {
                requiredFoodpacks.Add(PoolManager.Instance.GetFoodpack());
            }
            for (int i = 0; i < selectedLvlSO.difficulty; i++)
            {
                otherFoodpacks.Add(PoolManager.Instance.GetFoodpack());
            }
            //SpawnObjects();
            EventManager.Broadcast(GameEvent.OnGameStart);
        }
        #region OnGameStart
        void ConfigLabels()
        {
            UIManager.Instance.txtLevel.text = "Level " + level.ToString();
            TimeManager.Instance.StartTimer(selectedLvlSO.time);
        }
        void SpawnObjects()
        {
            SpawnFoodpackObj.Instance.SpawnObjs(requiredFoodpacks, true);
            SpawnFoodpackObj.Instance.SpawnObjs(otherFoodpacks, false);
        }
        void FillRequirementCards() => CardsPool.Instance.FillRequirements(requiredFoodpacks);
        #endregion
    }
}