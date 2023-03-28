using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Managers;

namespace UI.Cards
{
    public class CardsPool : PoolControl<CardsPool>
    {
        public List<FoodpackSO> requiredFoodpacks = new List<FoodpackSO>();
        public void FillRequirements(List<FoodpackSO> _requiredFoodpacks)
        {
            requiredFoodpacks = _requiredFoodpacks;
            FillUIs(requiredFoodpacks);
        }
        public void CollectRequiredFp(FoodpackSO foodpackSO)
        {
            if (requiredFoodpacks.Contains(foodpackSO))
            {
                FoundUI(foodpackSO).GetComponent<RequiredAmount>().DecreaseRequiredAmount();
            }
        }
        public void RemoveFromList(FoodpackSO foodpackSO)
        {
            requiredFoodpacks.Remove(foodpackSO);
            if (requiredFoodpacks.Count <= 0)
            {
                EventManager.Broadcast(GameEvent.OnGameWin);
            }
        }
    }
}