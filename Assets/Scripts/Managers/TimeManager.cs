using Other;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class TimeManager : MonoSingleton<TimeManager>
    {
        float leftTime;
        TextMeshProUGUI txtTime;
        bool stopTimer = false;

        float freezeTimeValue = 8;
        float addTimeValue = 10;

        public void StartTimer(float seconds) => leftTime = Time.deltaTime + seconds;
        public void StopTimer() => StartCoroutine(StopTimerCorout(freezeTimeValue));
        public void AddTime() => leftTime += addTimeValue;
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnBoostFreeze, StopTimer);
            EventManager.AddHandler(GameEvent.OnBoostTime, AddTime);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnBoostFreeze, StopTimer);
            EventManager.RemoveHandler(GameEvent.OnBoostTime, AddTime);
        }

        private void Start()
        {
            txtTime = UIManager.Instance.txtTime;
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGamePlaying() || stopTimer) return;
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime;
                txtTime.text = SecondsToMinutes();
            }
            else
            {
                GameManager.Instance.ChangeGameState(false);
                txtTime.text = "00:00";
                EventManager.Broadcast(GameEvent.OnGameLose);
            }
        }
        string SecondsToMinutes()
        {
            string minutes = Mathf.Floor(leftTime / 60).ToString("00");
            string seconds = (leftTime % 60).ToString("00");

            return $"{minutes}:{seconds}";
        }
        IEnumerator StopTimerCorout(float sec)
        {
            stopTimer = true;
            yield return new WaitForSeconds(sec);
            stopTimer = false;
        }
    }
}