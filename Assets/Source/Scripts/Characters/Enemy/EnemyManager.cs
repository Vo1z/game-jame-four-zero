using System.Collections.Generic;
using Support;
using Ingame.Stats;

namespace Ingame
{
    public class EnemyManager : MonoSingleton<EnemyManager>
    {
        public List<EnemyStats> enemies = new List<EnemyStats>();

        private void Start()
        {
            GameController.Instance.OnFirstStagePassed += OnFirstStagePassed;
        }

        private void OnDestroy()
        {
            GameController.Instance.OnFirstStagePassed -= OnFirstStagePassed;
        }

        public void AddEnemy(EnemyStats enemy)
        {
            enemies.Add(enemy);
        }

        public void RemoveEnemy(EnemyStats enemy)
        {
            enemies.Remove(enemy);

            if (enemies.Count < 1)
                GameController.Instance.EndLevel(true);
        }
        
        private void OnFirstStagePassed()
        {
            if (enemies.Count < 1)
            {
                GameController.Instance.EndLevel(true);
            }
        }
    }
}
