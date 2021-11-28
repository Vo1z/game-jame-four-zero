using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Events;
using Ingame.Movement;
namespace Ingame.Stats
{
    [RequireComponent(typeof(EnemyMovement),typeof(EnemyEventControl))]
    public class EnemyStats : MonoBehaviour, IActor
    {
        private EnemyEventControl _enemyEventControl;
        private EnemyMovement _movement;
        private int _currHp;
        private int _maxHp;
        public float CurrHp => _currHp;
        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _enemyEventControl = GetComponent<EnemyEventControl>();
        }
        private void Start()
        {
            EnemyManager.Instance.AddEnemy(this);
        }
        public void SetInitHp(float i)
        {
            _maxHp = (int)i;
            _currHp = _maxHp;
        }

        public void Heal(float heal)
        {
            _currHp += (int)heal;
        }

        public void TakeDmg(float dmg)
        {
            _movement.PushEnemy();
            _currHp -= (int)dmg;
            if (_currHp <= 0)
            {
                _enemyEventControl.Die();
            }
        }
        private void OnDestroy()
        {
            EnemyManager.Instance.RemoveEnemy(this);
            if (EnemyManager.Instance.Win())
            {

            }
        }
    }
}