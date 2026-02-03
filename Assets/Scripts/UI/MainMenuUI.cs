using UnityEngine;
using StarforgeOutpost.Core;

namespace StarforgeOutpost.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;

        public void StartGame()
        {
            if (sceneLoader == null)
            {
                return;
            }

            sceneLoader.LoadGame();
        }

        public void QuitGame()
        {
            if (sceneLoader == null)
            {
                return;
            }

            sceneLoader.QuitGame();
        }
    }
}
