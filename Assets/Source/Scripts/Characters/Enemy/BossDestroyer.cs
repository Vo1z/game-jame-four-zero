using Support;
using UnityEngine;

namespace Ingame
{
    public class BossDestroyer : MonoBehaviour
    {
        private void OnDestroy()
        {
            GameController.Instance.EndLevel(true);
        }
    }
}