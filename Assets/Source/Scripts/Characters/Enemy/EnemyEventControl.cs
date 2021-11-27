using Ingame.Stats;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Movement;
namespace Ingame.Events
{
    public class EnemyEventControl : MonoBehaviour
    {
        [Required]
        [SerializeField]
        private EnemyData enemyStatsData;

        private const float DISAPEARING_TIME = 0.4f;

        [Required]
        private EnemyStats _character;

        public EnemyData EnemyStatsData => enemyStatsData;

        private void Awake()
        {
            _character = GetComponent<EnemyStats>();
            _character.SetInitHp(enemyStatsData.InitHpBar);
        }
        public void Die()
        {

           Destroy(this.gameObject, DISAPEARING_TIME);
            
        }


    }
}