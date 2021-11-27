using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Events;
namespace Ingame.Stats
{
    public class EnemyStats : MonoBehaviour, IActor
    {
     
        private const float MARGIN_OF_DEAD = 0f;
        private const float MARGIN_ERROR = 0.001f;
        private EnemyEventControl _enemyEventControl;
        private float _currHp;
        public float CurrHp => _currHp;

        public void SetInitHp(float i)
        {
            _currHp = i;
        }

        public void Heal(float heal)
        {
            _currHp += heal;
        }

        public void TakeDmg(float dmg)
        {
            _currHp -= dmg;
            if (Mathf.Abs(_currHp - MARGIN_ERROR) <= MARGIN_OF_DEAD)
            {
                _enemyEventControl.Die();
            }
        }
    }
}