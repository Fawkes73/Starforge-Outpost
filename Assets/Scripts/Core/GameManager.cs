using System;
using UnityEngine;

namespace StarforgeOutpost.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("UI")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject endScreen;

        public GameState CurrentState { get; private set; } = GameState.MainMenu;
        public event Action<GameState> OnGameStateChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SetState(GameState newState)
        {
            if (CurrentState == newState)
            {
                return;
            }

            CurrentState = newState;
            HandleStateChanged();
            OnGameStateChanged?.Invoke(CurrentState);
        }

        private void HandleStateChanged()
        {
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(CurrentState == GameState.Paused);
            }

            if (endScreen != null)
            {
                endScreen.SetActive(CurrentState == GameState.GameOver);
            }

            Time.timeScale = CurrentState == GameState.Paused ? 0f : 1f;
        }

        public void PauseGame()
        {
            SetState(GameState.Paused);
        }

        public void ResumeGame()
        {
            SetState(GameState.Playing);
        }

        public void TriggerGameOver()
        {
            SetState(GameState.GameOver);
        }
    }
}
