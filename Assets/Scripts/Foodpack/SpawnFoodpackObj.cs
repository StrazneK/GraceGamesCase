using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Other;
using System.Linq;

namespace Foodpack
{
    public class SpawnFoodpackObj : MonoSingleton<SpawnFoodpackObj>
    {
        const float MAX_Z = 2f;
        const float MAX_X = 2f;
        List<GameObject> spawnedRequiredFp = new List<GameObject>();
        List<GameObject> spawnedOtherFp = new List<GameObject>();
        public void SpawnObjs(List<FoodpackSO> foodpacks,bool isRequired)
        {
            for (int i = 0; i < foodpacks.Count; i++)
            {
                SpawnMultiple(foodpacks[i], isRequired);
            }
        }
        void SpawnMultiple(FoodpackSO foodpackSO, bool isRequired)
        {
            for (int j = 0; j < 3; j++)
            {
                InstantiateObj(foodpackSO, isRequired);
            }
        }
        public void InstantiateObj(FoodpackSO foodpackSO, bool isRequired)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-MAX_X, MAX_X), 2, Random.Range(-MAX_Z, MAX_Z));
            Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            GameObject newObj = Instantiate(foodpackSO.prefab, randomPosition, randomRotation, transform);

            newObj.GetComponent<FoodpackObj>().foodpackSO = foodpackSO;

            if (isRequired)
                spawnedRequiredFp.Add(newObj);
            else
                spawnedOtherFp.Add(newObj);
        }
    }
}