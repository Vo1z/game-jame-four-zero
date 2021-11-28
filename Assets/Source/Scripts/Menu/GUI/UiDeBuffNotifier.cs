using DG.Tweening;
using Extensions;
using Ingame.Events;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace Ingame
{
    public class UiDeBuffNotifier : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float animationDuration;
        [Required] [SerializeField] private CanvasGroup parentCanvasGroup;
        [Required] [SerializeField] private TMP_Text deBuffText;

        private void Start()
        {
            PlayerEventSystem.Instance.OnPsychoMode += OnPsychoMode;
        }

        private void OnDestroy()
        {
            PlayerEventSystem.Instance.OnPsychoMode -= OnPsychoMode;
        }

        private void OnPsychoMode(PsychoModeDeBuff deBuff)
        {
            parentCanvasGroup.SetGameObjectActive();
            deBuffText.SetText($"{deBuff} was initiated");
            PresentDeBuffLabel();
            this.WaitAndDoCoroutine(animationDuration * 2, HideDeBuffLabel);
        }

        private void PresentDeBuffLabel()
        {
            parentCanvasGroup.SetGameObjectActive();
            parentCanvasGroup.DOFade(1, animationDuration);
        }

        private void HideDeBuffLabel()
        {
            parentCanvasGroup.DOFade(0, animationDuration)
                .OnComplete(parentCanvasGroup.SetGameObjectInactive);
        }
    }
}