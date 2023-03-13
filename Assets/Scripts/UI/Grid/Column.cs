using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Column : MonoBehaviour
{
    Image image;
    FoodpackSO FoodpackSO;
    private void OnEnable()
    {
        image = GetComponent<Image>();
    }
    public FoodpackSO foodpackSO 
    {
        get
        {
            return FoodpackSO;
        }
        set
        {
            image.sprite = value.image;
            FoodpackSO = value;
        }
    }
    public void FillContent(FoodpackSO _foodpackSo)
    {
        gameObject.SetActive(true);
        foodpackSO = _foodpackSo;
    }
    public void RemoveContent()
    {
        gameObject.SetActive(false);
    }
}
