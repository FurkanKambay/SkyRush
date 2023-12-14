using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    static int currentLevel = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchTo(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchTo(2);
        else if (Input.GetKeyDown(KeyCode.Alpha0))
            SwitchTo(0);
    }

    void SwitchTo(int index)
    {
        if (currentLevel == index) return;

        currentLevel = index;
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
