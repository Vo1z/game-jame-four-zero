using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Sprite ButtonA;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenTutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene(1);
    }
}
