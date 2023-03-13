using Managers;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoost : BoostClick
{
    public override void StartBoost()
    {
        EventManager.Broadcast(GameEvent.OnBoostTime);
    }
    void SetPositionsParticle()
    {
        int otherFpCount = ConfigureLevel.Instance.otherFoodpacks.Count;
       /* if (otherFpCount > 0)
            LightningParticle.Instance.SetPositionsParticle(ConfigureLevel.Instance.otherFoodpacks[Random.Range(0,otherFpCount)].prefab.transform);*/
    }
}
