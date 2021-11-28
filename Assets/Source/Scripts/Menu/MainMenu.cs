using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;

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

        private IEnumerator PerformActionCoroutine(Button btn,Sprite spr, Sprite sprOnActive,int scene)
        {
            btn.image.sprite = sprOnActive;
            yield return new WaitForSeconds(_delay);
            btn.image.sprite = spr;
            SceneManager.LoadScene(scene);
        }
        private void PerformAction(Button btn,Sprite spr, Sprite sprOnActive, int scene)
        {
            StartCoroutine(PerformActionCoroutine(btn,spr, sprOnActive, scene));
        }
        public void StartGame()
        {
            PerformAction(buttonA, buttonASprite, buttonAOnActiveSprite, 0);
            
        }
 
        public void OpenTutorial()
        {
            PerformAction(buttonB, buttonBSprite, buttonBOnActiveSprite, 0);
        }
        public void OpenCredits()
        {
            PerformAction(buttonC, buttonCSprite, buttonCOnActiveSprite, 1);
        }
    }
}