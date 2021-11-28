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

        private void Start()
        {
            GameController.Instance.OnLevelEnded += OnLevelEnd;
            
            PlayEnterLevel();
        }

        private void OnDestroy()
        {
            GameController.Instance.OnLevelEnded -= OnLevelEnd;
        }

        private void OnLevelEnd(bool _)
        {
            PlayExitLevel();
        }

        private void PlayExitLevel()
        {
            spriteRenderer.enabled = true;
            
            levelTransitionCircleAnimator.SetTrigger("ExitLevel");
            this.DoAfterNextFrameCoroutine(() => levelTransitionCircleAnimator.ResetTrigger("ExitLevel"));
        }

        private void PlayEnterLevel()
        {
            spriteRenderer.enabled = true;
            
            levelTransitionCircleAnimator.SetTrigger("EnterLevel");
            this.DoAfterNextFrameCoroutine(() => levelTransitionCircleAnimator.ResetTrigger("EnterLevel"));
        }
    }
}