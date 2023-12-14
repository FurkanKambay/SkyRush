using UnityEngine;

namespace Aircraft
{
    public class LevelChanger : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SwitchTo(Level.Desert);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                SwitchTo(Level.Forest);
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                SwitchTo(Level.MainMenu);
        }

        void SwitchTo(Level level)
        {
            if (GameManager.Instance.CurrentLevel == level)
                return;

            GameManager.Instance.LoadLevel(level, GameState.Preparing);
        }
    }
}
