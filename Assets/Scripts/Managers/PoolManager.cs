using Other;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        public List<LevelSO> levelSOs = new List<LevelSO>();
        public List<FoodpackSO> foodpackSOs = new List<FoodpackSO>();


        public GameObject GetFoodpackPref() => GetFoodpack().prefab;
        public GameObject GetFoodpackPref(string foodpackTitle) => GetFoodpack(foodpackTitle).prefab;

        public FoodpackSO GetFoodpack() //GetFoodpack randomly
        {
            return foodpackSOs[Random.Range(0, foodpackSOs.Count)];
        }
        public FoodpackSO GetFoodpack(string foodpackTitle) //GetFoodpack by title
        {
            foreach (var foodpacks in foodpackSOs)
            {
                if (foodpacks.title == foodpackTitle)
                    return foodpacks;
            }
            return null;
        }
        public LevelSO GetLevel(int level)
        {
            return levelSOs[level];
        }
    }
}