using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit Game");
    }
}