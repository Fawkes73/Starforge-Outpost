using UnityEngine;

namespace StarforgeOutpost.Core
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

        private void Update()
        {
            if (Input.GetKeyDown(pauseKey))
            {
                if (GameManager.Instance == null)
                {
                    return;
                }

                if (GameManager.Instance.CurrentState == GameState.Paused)
                {
                    GameManager.Instance.ResumeGame();
                }
                else if (GameManager.Instance.CurrentState == GameState.Playing)
                {
                    GameManager.Instance.PauseGame();
                }
            }
        }
    }
}
