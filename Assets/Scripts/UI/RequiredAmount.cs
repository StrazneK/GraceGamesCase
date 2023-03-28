using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public abstract class RequiredAmount : MonoBehaviour
    {
        public TextMeshProUGUI txtAmount;
        public int _reqAmount;
        public int reqAmount
        {
            get
            {
                return _reqAmount;
            }
            set
            {
                _reqAmount = value;
                txtAmount.text = value.ToString();
            }
        }
        public void AddRequiredAmount(int amount) => reqAmount += amount;
        public void DecreaseRequiredAmount(int amount = 1)
        {
            reqAmount -= amount;
            if (ControlRequiredAmount())
                RequiredAmountFinished();
        }
        public bool ControlRequiredAmount()
        {
            if (reqAmount <= 0)
            {
                return true;
            }
            return false;
        }
        public abstract void RequiredAmountFinished();
    }
}