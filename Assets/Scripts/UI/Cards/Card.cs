using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Cards
{
    [RequireComponent(typeof(FillFoodpackUI))]
    public class Card : RequiredAmount
    {
        public bool isEnabled = false;
        public override void RequiredAmountFinished()
        {
            CardsPool.Instance.RemoveFromList(GetComponent<FillFoodpackUI>().foodpackSO);
        }
    }
}