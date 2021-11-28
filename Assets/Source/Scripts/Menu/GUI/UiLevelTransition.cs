using Extensions;
using Support;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame
{
    public class UiLevelTransition : MonoBehaviour
    {
        [SerializeField] private Animator levelTransitionCircleAnimator;
        [SerializeField] private Image spriteRenderer;

        public const float PAUSE_BEFORE_LOADING_NEXT_LEVEL = 1.5f;

        private void Start()
        {
            PlayEnterLevel();
        }

        private void PlayEnterLevel()
        {
            spriteRenderer.enabled = true;
            
            levelTransitionCircleAnimator.SetTrigger("EnterLevel");
            this.DoAfterNextFrameCoroutine(() => levelTransitionCircleAnimator.ResetTrigger("EnterLevel"));
        }

        public void PlayExitLevel()
        {
            spriteRenderer.enabled = true;
            
            levelTransitionCircleAnimator.SetTrigger("ExitLevel");
            this.DoAfterNextFrameCoroutine(() => levelTransitionCircleAnimator.ResetTrigger("ExitLevel"));
        }
    }
}