using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public enum GameEvent
    {
        OnGameStart,
        OnGameLose,
        OnGameWin,

        OnBoostFreeze,
        OnBoostTime,
        OnBoostLightning,
        OnBoostMagnet,

        OnMoveAnimationEnd,
        OnMatch

    }
    
    public static class EventManager
    {
        private static Dictionary<GameEvent, Action> eventTable
            = new Dictionary<GameEvent, Action>();

        public static void AddHandler(GameEvent gameEvent, Action action)
        {
            if (!eventTable.ContainsKey(gameEvent)) eventTable[gameEvent] = action;
            else eventTable[gameEvent] += action;
        }

        public static void RemoveHandler(GameEvent gameEvent, Action action)
        {
            if (eventTable[gameEvent] != null)
                eventTable[gameEvent] -= action;
            if (eventTable[gameEvent] == null)
                eventTable.Remove(gameEvent);
        }

        public static void Broadcast(GameEvent gameEvent)
        {
            if (eventTable[gameEvent] != null)
                eventTable[gameEvent]();
        }
        public static IEnumerator BroadcastWithSec(GameEvent gameEvent,float sec)
        {
            yield return new WaitForSeconds(sec);
            if (eventTable[gameEvent] != null)
                eventTable[gameEvent]();
        }

    }
}