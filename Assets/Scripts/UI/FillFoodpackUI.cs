using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillFoodpackUI : MonoBehaviour
{
    [SerializeField] Image image;
    FoodpackSO _foodpackSO;
    public FoodpackSO foodpackSO
    {
        get
        {
            return _foodpackSO;
        }
        set
        {
            image.sprite = value.image;
            _foodpackSO = value;
        }
    }
    public void FillContent(FoodpackSO _fpSo)
    {
        gameObject.SetActive(true);
        foodpackSO = _fpSo;
        if (transform.GetComponent<Card>() != null)
            transform.GetComponent<Card>().AddRequiredAmount(3);
    }
    public void RemoveContent()
    {
        gameObject.SetActive(false);
    }
}
