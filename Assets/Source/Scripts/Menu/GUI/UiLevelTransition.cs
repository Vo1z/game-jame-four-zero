using Extensions;
using UnityEngine;

namespace Ingame
{
    public class UiLevelTransition : MonoBehaviour
    {
        [SerializeField] private Animator levelTransitionCircleAnimator;

        public const float PAUSE_BEFORE_LOADING_NEXT_LEVEL = 1.5f;

        private void Start()
        {
            PlayEnterLevel();
        }

        private void PlayEnterLevel()
        {
            levelTransitionCircleAnimator.SetGameObjectActive();
            
            levelTransitionCircleAnimator.SetTrigger("EnterLevel");
            this.DoAfterNextFrameCoroutine(() => levelTransitionCircleAnimator.ResetTrigger("EnterLevel"));
        }

        public void PlayExitLevel()
        {
            levelTransitionCircleAnimator.SetGameObjectActive();
            
            levelTransitionCircleAnimator.SetTrigger("ExitLevel");
            this.DoAfterNextFrameCoroutine(() => levelTransitionCircleAnimator.ResetTrigger("ExitLevel"));
        }
    }
}