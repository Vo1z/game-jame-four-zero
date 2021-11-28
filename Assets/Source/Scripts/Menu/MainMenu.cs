using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;
using Support;
namespace Ingame.Settings { 
    public class MainMenu : MonoBehaviour
    {
        [Foldout("BUTTON A")]
        [SerializeField]
        private Sprite buttonASprite;
        [Foldout("BUTTON A")]
        [SerializeField]
        private Sprite buttonAOnActiveSprite;
        [Foldout("BUTTON A")]
        [SerializeField]
        private Button buttonA;

        [Foldout("BUTTON B")]
        [SerializeField]
        private Sprite buttonBSprite;
        [Foldout("BUTTON B")]
        [SerializeField]
        private Sprite buttonBOnActiveSprite;
        [Foldout("BUTTON B")]
        [SerializeField]
        private Button buttonB;


        [Foldout("BUTTON C")]
        [SerializeField]
        private Sprite buttonCSprite;
        [Foldout("BUTTON C")]
        [SerializeField]
        private Sprite buttonCOnActiveSprite;
        [Foldout("BUTTON C")]
        [SerializeField]
        private Button buttonC;

        private float _delay = .13f;

        private IEnumerator PerformActionCoroutine(Button btn,Sprite spr, Sprite sprOnActive, MenuManager.MenuType type)
        {
            btn.image.sprite = sprOnActive;
            yield return new WaitForSeconds(_delay);
            btn.image.sprite = spr;
            MenuManager.Instance.SetMenu(type);

        }
        private IEnumerator DelayCoroutine()
        {
            yield return new WaitForSeconds(_delay);
        }
        private void PerformAction(Button btn,Sprite spr, Sprite sprOnActive, MenuManager.MenuType type)
        {
            StartCoroutine(PerformActionCoroutine(btn,spr, sprOnActive,type));
        }
        public void StartGame()
        {
            buttonA.image.sprite = buttonAOnActiveSprite;
            StartCoroutine(DelayCoroutine());
            MenuManager.Instance.SetMenu(MenuManager.MenuType.Start);
            
        }
 
        public void OpenTutorial()
        {
            
            PerformAction(buttonB, buttonBSprite, buttonBOnActiveSprite, MenuManager.MenuType.Tutorial);
        }
        public void OpenCredits()
        {
            PerformAction(buttonC, buttonCSprite, buttonCOnActiveSprite, MenuManager.MenuType.Credits);
        }
    }
}