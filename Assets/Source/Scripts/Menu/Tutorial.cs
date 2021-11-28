using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();
    [SerializeField]
    private Image image;
    private int _counter =0;

    public void GoNext()
    {

        if (++_counter >= sprites.Count)
        {
            _counter = 0;
            MenuManager.Instance.SetMenu(MenuManager.MenuType.MainMenu);
        }
        image.sprite = sprites[_counter];
        
    }
}
