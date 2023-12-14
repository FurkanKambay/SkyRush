using UnityEngine;
using UnityEngine.UI;

namespace Aircraft
{

    public class Pause : MonoBehaviour
    {
        public Canvas uiCanvas;

        private bool isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                UpdateState();
            }
        }

        public void MainMenu()
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        public void Resume()
        {
            isPaused = false;
            UpdateState();
        }

        private void UpdateState()
        {
            Time.timeScale = isPaused ? 0 : 1;
            uiCanvas.gameObject.SetActive(isPaused);
        }
    }

}
