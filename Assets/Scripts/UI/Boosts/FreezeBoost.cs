using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FreezeBoost : BoostClick
{
    public override void StartBoost()
    {
        EventManager.Broadcast(GameEvent.OnBoostFreeze);
    }
}
