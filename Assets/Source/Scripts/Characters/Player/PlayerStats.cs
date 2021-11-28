using System;
using Extensions;
using Ingame.Events;
using NaughtyAttributes;
using Support;
using Support.SLS;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventSystem))]
    public class PlayerStats : MonoBehaviour, IActor
    {
        private PlayerEventSystem _playerEventSystem;
        [ReadOnly]
        private float _currentHp;
        [ReadOnly]
        private float _currentSpeed;
        [ReadOnly]
        private float _currentRage = 0;

        public float CurrentSpeed => _currentSpeed;

        private void Awake()
        {
            _playerEventSystem = GetComponent<PlayerEventSystem>();
        }

        private void Start()
        {
            _currentHp = _playerEventSystem.Data.InitialHp;
            _currentSpeed = _playerEventSystem.Data.InitialSpeed;
            
            TakeDmg(5);
        }

        private void CheckPlayerCondition()
        {
            if(_currentHp < 1)
                Die();
        }

        private void Die()
        {
            GameController.Instance.EndLevel(false);
            Destroy(gameObject);
        }

        public void TakeDmg(float dmg)
        {
            dmg = Mathf.Abs(dmg);

            _currentHp -= dmg;
            _currentHp = Mathf.Clamp(_currentHp, 0, _playerEventSystem.Data.InitialHp);
            
            this.SafeDebug($"CurrentHp {_currentHp}");
            
            _playerEventSystem.ChangePlayerHp(_currentHp);
            CheckPlayerCondition();
        }

        public void Heal(float heal)
        {
            heal = Mathf.Abs(heal);

            _currentHp += heal;
            _currentHp = Mathf.Clamp(_currentHp, 0, _playerEventSystem.Data.InitialHp);
            
            this.SafeDebug($"CurrentHp {_currentHp}");
            
            _playerEventSystem.ChangePlayerHp(_currentHp);
            CheckPlayerCondition();
        }

        public void IncreaseRage(int rageAmount)
        {
            rageAmount = Math.Abs(rageAmount);
            
            _currentRage += rageAmount;
            _currentRage = Mathf.Clamp(_currentRage, 0, _playerEventSystem.RequiredAmountOfRage);

            this.SafeDebug($"CurrentRage {_currentRage}");
            
            _playerEventSystem.ChangePlayerRage(rageAmount);
        }
    }
}