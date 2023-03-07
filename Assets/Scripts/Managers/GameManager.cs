using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] GameState gameState;

        public bool IsGamePlaying()
        {
            return gameState == GameState.Play;
        }
        public void ChangeGameState(bool play)
        {
            gameState = play ? GameState.Play : GameState.Pause;
        }

        public enum GameState
        { 
            Pause,
            Play
        }
    }
}