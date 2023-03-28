using Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.Count
{
    public class HeartSystem : CountSystemBase
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
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnGameLose, RemoveOneHeart);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnGameLose, RemoveOneHeart);
        }
        public override void CountChanged()
        {
            ShowOnText();
        }
        public void RemoveOneHeart()
        {
            RemoveCount(1);
            SaveCount();
        }
    }
}