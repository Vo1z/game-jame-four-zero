using Extensions;
using UnityEngine;

namespace Ingame
{
    public class HandAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void PlayGrabAnimation()
        {
            animator.SetTrigger("Grab");
            this.DoAfterNextFrameCoroutine(() => animator.ResetTrigger("Grab"));
        }
    }
}