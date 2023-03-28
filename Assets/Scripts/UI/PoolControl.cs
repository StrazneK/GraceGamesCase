using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Other;

namespace UI
{
    public class PoolControl<T> : MonoSingleton<T> where T : PoolControl<T>
    {
        public List<FillFoodpackUI> foodpackUIs = new List<FillFoodpackUI>();
        void Start()
        {
            FillFoodpacksUIsList();
        }
        void FillFoodpacksUIsList()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                foodpackUIs.Add(transform.GetChild(i).GetComponent<FillFoodpackUI>());
            }
        }
        public void FillUIs(List<FoodpackSO> collectedObjs)
        {
            if (foodpackUIs.Count <= 0)
                FillFoodpacksUIsList();
            for (int i = 0; i < collectedObjs.Count; i++)
            {
                foodpackUIs[i].FillContent(collectedObjs[i]);
            }
        }
        public GameObject FoundUI(FoodpackSO foodpackSO)
        {
            return foodpackUIs.Where(x => x.foodpackSO == foodpackSO).FirstOrDefault().gameObject;
        }
        public void ClearUIs()
        {
            for (int i = 0; i < foodpackUIs.Count; i++)
            {
                foodpackUIs[i].RemoveContent();
                foodpackUIs[i].gameObject.SetActive(false);
            }
        }
    }
}