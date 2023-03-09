using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Foodpack
{
    public class SpawnFoodpackObj : MonoSingleton<SpawnFoodpackObj>
    {
        const float MAX_Z = 2f;
        const float MAX_X = 2f;
        public void SpawnObjs(List<FoodpackSO> requiredFoodpacks)
        {
            for (int i = 0; i < requiredFoodpacks.Count; i++)
            {
                SpawnMultiple(requiredFoodpacks[i].prefab);
            }
        }
        public void SpawnObjs(int foodpackCount)
        {
            for (int i = 0; i < foodpackCount; i++)
            {
                SpawnMultiple(PoolManager.Instance.GetFoodpackPref());
            }
        }
        void SpawnMultiple(GameObject pref)
        {
            for (int j = 0; j < 3; j++)
            {
               InstantiateObj(pref);

            }
        }
        public void InstantiateObj(GameObject prefab)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-MAX_X, MAX_X), 2, Random.Range(-MAX_Z, MAX_Z));
            Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            Instantiate(prefab, randomPosition, randomRotation, transform);
        }
    }
}