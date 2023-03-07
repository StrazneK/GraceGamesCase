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
        private void Start()
        {
            txtTime = UIManager.Instance.txtTime;
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime;
                txtTime.text = SecondsToMinutes();
            }
            else
            {
                GameManager.Instance.ChangeGameState(false);
                txtTime.text = "00:00";
                //Yenilme kodlarý
            }
        }
        public void StartTimer(float seconds)
        {
            leftTime = Time.deltaTime + seconds;
        }
        string SecondsToMinutes()
        {
            string minutes = Mathf.Floor(leftTime / 60).ToString("00");
            string seconds = (leftTime % 60).ToString("00");

            return $"{minutes}:{seconds}";
        }
    }
}