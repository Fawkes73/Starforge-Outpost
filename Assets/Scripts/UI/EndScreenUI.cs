using UnityEngine;
using StarforgeOutpost.Core;

namespace StarforgeOutpost.UI
{
    public class EndScreenUI : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;

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
