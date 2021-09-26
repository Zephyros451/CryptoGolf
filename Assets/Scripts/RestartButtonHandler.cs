using UnityEngine;

public class RestartButtonHandler : MonoBehaviour
{
    public void Restart()
    {
        SceneSwitcher.instance.LoadMainMenuScene();
    }
}
