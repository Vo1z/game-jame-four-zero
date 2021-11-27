using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame {
     [RequireComponent(typeof(EnemyAttack))]
    public class EnemyOnPlayerCollision : MonoBehaviour
    {
        private EnemyAttack _enemyAttack;
        private void Awake()
        {
                _enemyAttack = GetComponent<EnemyAttack>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerStats player))
            {
                    _enemyAttack.ChangeRangeCondition(true);
                    _enemyAttack.PeformAttackOnPlayer(player);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerStats player))
            {
                    _enemyAttack.ChangeRangeCondition(false);
             }
        }
    }
}
