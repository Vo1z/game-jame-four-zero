using Extensions;
using Support;
using UnityEngine;

namespace Ingame
{
    public class UiButtonsBehaviour : MonoBehaviour
    {
        public void RestartLevel(UiLevelTransition levelTransition)
        {
            levelTransition.SetGameObjectActive();
            levelTransition.PlayExitLevel();
            this.WaitAndDoCoroutine(UiLevelTransition.PAUSE_BEFORE_LOADING_NEXT_LEVEL, () => LevelManager.Instance.RestartLevel());
        }
        
        public void LoadNextLevel(UiLevelTransition levelTransition)
        {
            levelTransition.SetGameObjectActive();
            levelTransition.PlayExitLevel();
            this.WaitAndDoCoroutine(UiLevelTransition.PAUSE_BEFORE_LOADING_NEXT_LEVEL, () => LevelManager.Instance.LoadNextLevel());
        }

        public void OpenMainMenu()
        {
            LevelManager.Instance.LoadLevel(0);
        }
    }
}