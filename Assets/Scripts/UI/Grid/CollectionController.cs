using Managers;
using Other;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Cards;
using UnityEngine;

namespace UI.Grid
{
    public class CollectionController : MonoSingleton<CollectionController>
    {
        [SerializeField] List<FoodpackSO> collectedObjs = new List<FoodpackSO>();
        public int lastIndex => collectedObjs.Count - 1;
        int lastSameIndex = -1;
        FoodpackSO lastFpSO;
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnMatch, RemoveFromList);
            EventManager.AddHandler(GameEvent.OnMatch, SortCollectedObjs);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnMatch, RemoveFromList);
            EventManager.RemoveHandler(GameEvent.OnMatch, SortCollectedObjs);
        }
        public void AddCollectedObj(FoodpackSO foodpackSO)
        {
            lastFpSO = foodpackSO;
            if (collectedObjs.Contains(foodpackSO))
            {
                lastSameIndex = collectedObjs.LastIndexOf(foodpackSO);
            }
            collectedObjs.Add(foodpackSO);

            SortCollectedObjs();
            ControlMatch();
            LoseControl();
            CardsPool.Instance.CollectRequiredFp(foodpackSO);
        }

        void SortCollectedObjs()
        {
            ColumnsPool.Instance.ClearUIs();
            FoodpackSO[] tempList; //Create temp list for perfectly sort
            tempList = collectedObjs.ToArray(); //Copy original list
            if (lastSameIndex != -1) //If last added obj already exists
            {
                collectedObjs[lastSameIndex + 1] = collectedObjs[lastIndex];//Replace last object's index
                for (int i = lastSameIndex + 2; i < collectedObjs.Count; i++)
                {
                    collectedObjs[i] = tempList[i - 1]; // Sort after selected index
                }
            }
            lastSameIndex = -1;
            ColumnsPool.Instance.FillUIs(collectedObjs);
        }

        public void ControlMatch()
        {
            int sameFoodpacks = collectedObjs.Where(x => x == lastFpSO).Count();

            if (sameFoodpacks >= 3)
            {
                for (int i = 0; i < sameFoodpacks; i++)
                {
                    int removeIndex = collectedObjs.LastIndexOf(lastFpSO);
                    RemoveFromList(removeIndex);
                    ColumnsPool.Instance.MatchedColumns(removeIndex);
                }
            }
        }
        void RemoveFromList(int removeIndex)
        {
            collectedObjs.RemoveAt(removeIndex);
        }
        void RemoveFromList()
        {
            collectedObjs.Remove(lastFpSO);
        }
        void LoseControl()
        {
            if (collectedObjs.Count >= 7)
                EventManager.Broadcast(GameEvent.OnGameLose);
        }

    }
}