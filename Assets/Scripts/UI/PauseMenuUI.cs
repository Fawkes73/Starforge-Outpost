using UnityEngine;
using StarforgeOutpost.Core;

namespace StarforgeOutpost.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;

        public void Resume()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ResumeGame();
            }
        }

        public void Restart()
        {
            if (sceneLoader == null)
            {
                return;
            }

            sceneLoader.RestartGame();
        }

        public void MainMenu()
        {
            if (sceneLoader == null)
            {
                return;
            }

            sceneLoader.LoadMainMenu();
        }
    }
}
