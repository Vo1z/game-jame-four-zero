using Extensions;
using UnityEngine;

namespace Ingame
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float pauseBeforeDestruction;

        private void Start()
        {
            this.WaitAndDoCoroutine(pauseBeforeDestruction, () => Destroy(gameObject));
        }
    }
}