using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartSystem  : CountSystemBase
{
    public static HeartSystem Instance;
    [SerializeField] TextMeshProUGUI txtCount;
    void ShowOnText() => txtCount.text = Count.ToString();
    void Awake()
    {
        Instance = this;
        key = "Heart";
    }
    
    override protected void Start()
    {
        base.Start();
        ShowOnText();
    }

    public override void CountChanged()
    {
        Debug.Log("Heart Count Changed");
        ShowOnText();
    }
}
