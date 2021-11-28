using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;
public class MenuManager : MonoSingleton<MenuManager>
{
    // Start is called before the first frame update
    [SerializeField]
    private Canvas mainMenuCanvas;
    [SerializeField]
    private Canvas tutorialCanvas;
    [SerializeField]
    private Canvas creditsCanvas;
    public enum MenuType
    {
        Start,
        MainMenu,
        Tutorial,
        Credits
    }

    public void HideAll()
    {
 
        mainMenuCanvas.enabled = false;
        tutorialCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }

    public void SetMenu(MenuType type)
    {
        HideAll();
        switch (type)
        {
            case MenuType.Start:
                GameController.Instance.RestartLevel();
                break;

            case MenuType.Credits:
                creditsCanvas.enabled = true;
                break;

            case MenuType.Tutorial:
                tutorialCanvas.enabled = true;
                break;

            case MenuType.MainMenu:
                mainMenuCanvas.enabled = true;
                break;
        }
    }
    
}
