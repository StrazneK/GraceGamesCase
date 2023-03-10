using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Managers;

public class TimeBoost : BoostClick
{
    public override void StartBoost()
    {
        EventManager.Broadcast(GameEvent.OnBoostTime);
    }
}
