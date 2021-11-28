using System;
using Extensions;

namespace Support
{
    /// <summary>
    /// Class that manages general game logic
    /// </summary>
    public class GameController : MonoSingleton<GameController>
    {
        private const float BERSERKER_STAGE_MAX_DURATION = 8f;
        
        /// <summary>Event that invokes each time when level is ended</summary>
        public event Action<bool> OnLevelEnded;
        /// <summary>Event that invokes each time when level is restarted</summary>
        public event Action OnLevelRestart;
        public event Action OnFirstStagePassed;

        private bool _isLevelEnded = false;

        /// <summary>
        /// Method that restarts level and triggers OnLevel RestartEvent
        /// </summary>
        public void RestartLevel()
        {
            OnLevelRestart?.Invoke();
            LevelManager.Instance.RestartLevel();
        }

        /// <summary>
        /// Method that should be invoked when level is ended
        /// </summary>
        /// <param name="isVictory">Describes whether player won or not</param>
        public void EndLevel(bool isVictory)
        {
            if (_isLevelEnded)
                return;

            _isLevelEnded = true;

            OnLevelEnded?.Invoke(isVictory);
        }

        public void PassFirstStage()
        {
            OnFirstStagePassed?.Invoke();

            this.WaitAndDoCoroutine(BERSERKER_STAGE_MAX_DURATION, () => GameController.Instance.EndLevel(true));
        }
    }
}