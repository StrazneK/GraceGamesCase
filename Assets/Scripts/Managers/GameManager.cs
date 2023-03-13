using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] GameState gameState;
        private void OnEnable()
        {
            EventManager.AddHandler(GameEvent.OnGameLose, PauseGame);
            EventManager.AddHandler(GameEvent.OnGameWin, PauseGame);
        }
        private void OnDisable()
        {
            EventManager.RemoveHandler(GameEvent.OnGameLose, PauseGame);
            EventManager.RemoveHandler(GameEvent.OnGameWin, PauseGame);
        }

        public bool IsGamePlaying()
        {
            return gameState == GameState.Play;
        }
        public void ChangeGameState(bool play)
        {
            gameState = play ? GameState.Play : GameState.Pause;
        }
        public void PauseGame()
        {
            ChangeGameState(false);
        }

        public enum GameState
        { 
            Pause,
            Play
        }
    }
}