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
        private bool _StopAction = false;
        private PlayerStats _player;
        private void Awake()
        {
            _enemyEvent = GetComponent<EnemyEventControl>();
            _attackDmg = _enemyEvent.EnemyStatsData.AttackDmg;
            _attackCoolDown = _enemyEvent.EnemyStatsData.AttackCoolDown;
        }

        private void Start()
        {
            StartCoroutine(AttackCoroutine());
        }
        private IEnumerator AttackCoroutine()
        {
            while (!_StopAction) {
                yield return new WaitForSeconds(_attackCoolDown);
                if (_player!=null)
                {
                    _player.TakeDmg(_attackDmg);

                }
            }
        }
        public void SetTarget(PlayerStats player)
        {
            this._player = player;
        }
    }
}
