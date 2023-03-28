using Managers;
using TMPro;
using UnityEngine;

namespace UI.Count
{
    public class CoinSystem : CountSystemBase
    {
        public static CoinSystem Instance;
        [SerializeField] TextMeshProUGUI txtCount;
        void ShowOnText() => txtCount.text = Count.ToString();
        void Awake()
        {
            Instance = this;
            key = "Coin";
        }
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnMatch, AddTenCoin);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnMatch, AddTenCoin);
        }

        override protected void Start()
        {
            base.Start();
            ShowOnText();
        }

        public override void CountChanged()
        {
            ShowOnText();
        }

        public void AddTenCoin()
        {
            AddCount(10);
            SaveCount();
        }
    }
}