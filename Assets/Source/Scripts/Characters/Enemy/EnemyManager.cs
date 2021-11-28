using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;
using Ingame.Movement;
using System;
using Ingame.Stats;
namespace Ingame {
    
    public class EnemyManager : MonoSingleton<EnemyManager>
    {
        public List<EnemyStats> enemies = new List<EnemyStats>();

        public void AddEnemy( EnemyStats enemy)
        {
            enemies.Add(enemy);
        }
        public void RemoveEnemy(EnemyStats enemy)
        {
            enemies.Remove(enemy);
        }

        public bool Win()
        {
            return enemies.Count < 0;
        }
        
    }
}
