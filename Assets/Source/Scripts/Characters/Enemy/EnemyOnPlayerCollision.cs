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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out PlayerStats player))
            {
                _enemyAttack.SetTarget(player);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerStats player))
            {
                _enemyAttack.SetTarget(null);
            }
        }
    }
}
