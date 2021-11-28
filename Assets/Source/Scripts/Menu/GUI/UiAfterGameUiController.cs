using DG.Tweening;
using Extensions;
using Support;
using UnityEngine;

namespace Ingame.UI
{
    public class UiAfterGameUiController : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float animationDuration = 1;
        [Space]
        [SerializeField] private CanvasGroup winScreenParentCanvas;
        [SerializeField] private CanvasGroup looseScreenParentCanvas;

        private Sequence _animationSequence;

        private void Awake()
        {
            winScreenParentCanvas.SetGameObjectInactive();
            looseScreenParentCanvas.SetGameObjectInactive();
        }

        private void Start()
        {
            GameController.Instance.OnLevelEnded += PlayAfterLevelMenuAnimation;
        }

        private void OnDestroy()
        {
            GameController.Instance.OnLevelEnded -= PlayAfterLevelMenuAnimation;
            
            if(_animationSequence != null)
                _animationSequence.Kill();
        }

        private void PlayAfterLevelMenuAnimation(bool isVictory)
        {
            if(isVictory)
                ShowWinScreen();
            else
                ShowLooseScreen();
        }

        private void ShowWinScreen()
        {
            winScreenParentCanvas.alpha = 0;
            winScreenParentCanvas.SetGameObjectActive();

            _animationSequence = DOTween.Sequence()
                .Append(winScreenParentCanvas.DOFade(1, animationDuration / 1.5f));
        }

        private void ShowLooseScreen()
        {
            looseScreenParentCanvas.alpha = 0;
            looseScreenParentCanvas.SetGameObjectActive();

            _animationSequence = DOTween.Sequence()
                .Append(looseScreenParentCanvas.DOFade(1, animationDuration / 1.5f));
        }
    }
}