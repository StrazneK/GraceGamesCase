using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Column : MonoBehaviour
{
    bool isFilled = false;
    string title = "";
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
            title = value.title;
            image.sprite = value.image;
            FoodpackSO = value;
        }
    }
    public void FillContent(FoodpackSO _foodpackSo)
    {
        gameObject.SetActive(true);
        isFilled = true;
        foodpackSO = _foodpackSo;
    }
    public void RemoveContent()
    {
        isFilled = false;
        gameObject.SetActive(false);
    }
}
