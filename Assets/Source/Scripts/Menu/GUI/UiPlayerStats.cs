using Extensions;
using Ingame.Events;
using NaughtyAttributes;
using Support.UI;
using UnityEngine;

namespace Ingame
{
    public class UiPlayerStats : MonoBehaviour
    {
        [Required]
        [SerializeField] private UiSlider hpBarSlider;
        [SerializeField] [Range(0, 1f)] private float frontSliderAnimationSpeed = 0.1f;
        [SerializeField] [Range(0, 1f)] private float backSliderAnimationSpeed = 0.05f;

        private const float PAUSE_BEFORE_SETTING_BACK_IMAGE = .2f;
        
        private void Start()
        {
            PlayerEventSystem.Instance.OnPlayerHpChanged += OnPlayerHpChanged;
        }

        private void OnDestroy()
        {
            PlayerEventSystem.Instance.OnPlayerHpChanged -= OnPlayerHpChanged;
        }

        private void OnPlayerHpChanged(float currentHp)
        {
            currentHp = Mathf.Max(0, currentHp);

            var hpBarValue = Mathf.InverseLerp(0, PlayerEventSystem.Instance.Data.InitialHp, currentHp);
            
            hpBarSlider.SetFrontImageWithLerping(frontSliderAnimationSpeed, hpBarValue);
            this.WaitAndDoCoroutine(PAUSE_BEFORE_SETTING_BACK_IMAGE, () => hpBarSlider.SetBackImageWithLerping(backSliderAnimationSpeed, hpBarValue));
        }
    }
}