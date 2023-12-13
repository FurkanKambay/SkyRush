using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Canvas uiCanvas;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            uiCanvas.gameObject.SetActive(isPaused);
        }
    }
}
