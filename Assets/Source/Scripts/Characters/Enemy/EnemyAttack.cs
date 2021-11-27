using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Events;
namespace Ingame { 
    [RequireComponent(typeof(EnemyEventControl))]
    public class EnemyAttack : MonoBehaviour
    {
        private EnemyEventControl _enemyEvent;
        private float _attackDmg;
        private float _attackCoolDown;
        private bool _isAttackCharging = false;
        private bool _isPlayerOnRange = false;
        private void Awake()
        {
            _enemyEvent = GetComponent<EnemyEventControl>();
            _attackDmg = _enemyEvent.EnemyStatsData.AttackDmg;
            _attackCoolDown = _enemyEvent.EnemyStatsData.AttackCoolDown;
        }


        private IEnumerator AttackCoroutine(PlayerStats player)
        {
            _isAttackCharging = true;
            yield return new WaitForSeconds(_attackCoolDown);
            if (_isPlayerOnRange)
            {
                player.TakeDmg(_attackDmg);
            }
            _isAttackCharging = false;
        }
        public void PeformAttackOnPlayer(PlayerStats player)
        {
            if (!_isAttackCharging)
            {
                StartCoroutine(AttackCoroutine(player));
            }
        }
        public void ChangeRangeCondition(bool b)
        {
            _isPlayerOnRange = b;
        }
    }
}
