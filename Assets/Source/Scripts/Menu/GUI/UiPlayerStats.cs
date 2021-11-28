using System;
using Extensions;
using Ingame.Events;
using NaughtyAttributes;
using Support.UI;
using UnityEngine;

namespace Ingame
{
    public class UiPlayerStats : MonoBehaviour
    {
        [Required] [BoxGroup("Hp")]
        [SerializeField] private UiSlider hpBarSlider;
        [BoxGroup("Hp")]
        [SerializeField] [Range(0, 1f)] private float hpFrontSliderAnimationSpeed = 0.1f;
        [BoxGroup("Hp")]
        [SerializeField] [Range(0, 1f)] private float hpBackSliderAnimationSpeed = 0.05f;
        [Space]
        [Required] [BoxGroup("Rage")]
        [SerializeField] private UiSlider rageBarSlider;
        [BoxGroup("Rage")]
        [SerializeField] [Range(0, 1f)] private float rageFrontSliderAnimationSpeed = 0.1f;

        private const float PAUSE_BEFORE_SETTING_BACK_IMAGE = .2f;
        
        private void Start()
        {
            PlayerEventSystem.Instance.OnPlayerHpChanged += OnPlayerHpChanged;
            PlayerEventSystem.Instance.OnRageChanged += OnRageChanged;
        }

        private void OnDestroy()
        {
            PlayerEventSystem.Instance.OnPlayerHpChanged -= OnPlayerHpChanged;
            PlayerEventSystem.Instance.OnRageChanged -= OnRageChanged;
        }

        private void OnPlayerHpChanged(float currentHp)
        {
            currentHp = Mathf.Max(0, currentHp);

            var hpBarValue = Mathf.InverseLerp(0, PlayerEventSystem.Instance.Data.InitialHp, currentHp);

            // this.SafeDebug($"HP {hpBarValue}");
            
            hpBarSlider.SetFrontImageWithLerping(hpFrontSliderAnimationSpeed, hpBarValue);
            this.WaitAndDoCoroutine(PAUSE_BEFORE_SETTING_BACK_IMAGE, () => hpBarSlider.SetBackImageWithLerping(hpBackSliderAnimationSpeed, hpBarValue));
        }

        private void OnRageChanged(int currentAmountOfRage)
        {
            currentAmountOfRage = Mathf.Max(0, currentAmountOfRage);
            
            var rageBarValue = Mathf.InverseLerp(0, PlayerEventSystem.Instance.RequiredAmountOfRage, currentAmountOfRage);
            
            // this.SafeDebug($"Rage {rageBarValue}");
            
            rageBarSlider.SetFrontImageWithLerping(rageFrontSliderAnimationSpeed, rageBarValue);
        }
    }
}