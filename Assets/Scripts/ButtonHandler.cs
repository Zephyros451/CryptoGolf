using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject rulesScreen;

    public void ShowRulesScreen()
    {
        rulesScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneSwitcher.instance.LoadGameScene();
    }

    public void GoToPrivatePolicy()
    {
        Application.OpenURL("https://www.google.com/");
    }
}
