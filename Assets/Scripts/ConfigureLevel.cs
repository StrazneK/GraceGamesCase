using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using UnityEngine.Events;
using Managers;
using Foodpack;

public class ConfigureLevel : MonoSingleton<ConfigureLevel>
{
    #region Level
    delegate void ConfigLevelDelegate();
    ConfigLevelDelegate configLevelDelegate;
    LevelSO selectedLvlSO;
    int level;
    #endregion
    public List<FoodpackSO> requiredFoodpacks = new List<FoodpackSO>();
    void SelectLevelSO() => selectedLvlSO = PoolManager.Instance.GetLevel(level - 1);

    private void OnEnable()
    {
        configLevelDelegate += ConfigSettings;
        configLevelDelegate += ConfigLabels;
    }
    private void OnDisable()
    {
        configLevelDelegate -= ConfigSettings;
        configLevelDelegate -= ConfigLabels;
    }
    private void Start()
    {
    }
    public void ConfigLevel(int _level)
    {
        level = _level;
        SelectLevelSO();
        if (configLevelDelegate != null)
            configLevelDelegate();
    }
    void ConfigSettings()
    {
        for (int i = 0; i < selectedLvlSO.difficulty; i++)
        {
            requiredFoodpacks.Add(PoolManager.Instance.GetFoodpack());
        }
        SpawnObjects();
    }
    void ConfigLabels()
    {
        UIManager.Instance.txtLevel.text = "Level " + level.ToString();
        TimeManager.Instance.StartTimer(selectedLvlSO.time);
    }
    void SpawnObjects()
    {
        SpawnFoodpackObj.Instance.SpawnObjs(requiredFoodpacks);
    }
}
