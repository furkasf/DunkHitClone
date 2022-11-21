using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameState state;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            CoreGameSignals.onSetGameState += OnSetGameState;
            CoreGameSignals.onGetGameState += OnGetGameState;
        }

        private void UnSubscribe()
        {
            CoreGameSignals.onSetGameState -= OnSetGameState;
            CoreGameSignals.onGetGameState -= OnGetGameState;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void OnSetGameState(GameState state)
        {
            this.state = state;
        }

        private GameState OnGetGameState() => state;
    }

    public enum GameState
    {
        Play,
        Menu
    }
}