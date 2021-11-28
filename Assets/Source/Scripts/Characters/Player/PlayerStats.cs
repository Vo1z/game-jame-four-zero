using System;
using Ingame.Events;
using NaughtyAttributes;
using Support;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventSystem))]
    public class PlayerStats : MonoBehaviour, IActor
    {
        private const float SECOND_STAGE_DAMAGE = 10;
        
        private PlayerEventSystem _playerEventSystem;
        [ReadOnly] private float _currentHp;
        [ReadOnly] private float _currentSpeed;
        [ReadOnly] private int _currentRage = 0;
        private bool _isInvincible = false;
        
        public float CurrentSpeed => _currentSpeed;

        private void Awake()
        {
            _playerEventSystem = GetComponent<PlayerEventSystem>();
        }

        private void Start()
        {
            GameController.Instance.OnFirstStagePassed += OnFirstStagePassed;
            
            _currentHp = _playerEventSystem.Data.InitialHp;
            _currentSpeed = _playerEventSystem.Data.InitialSpeed;
            
            TakeDmg(5);
        }

        private void OnDestroy()
        {
            GameController.Instance.OnFirstStagePassed -= OnFirstStagePassed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IActor enemy))
            {
                enemy.TakeDmg(SECOND_STAGE_DAMAGE);
            }
        }

        private void OnFirstStagePassed()
        {
            _isInvincible = true;
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
            if(_isInvincible)
                return;
            
            dmg = Mathf.Abs(dmg);

            _currentHp -= dmg;
            _currentHp = Mathf.Max(_currentHp, 0);
            
            _playerEventSystem.ChangePlayerHp(_currentHp);
            CheckPlayerCondition();
        }

        public void Heal(float heal)
        {
            heal = Mathf.Abs(heal);

            _currentHp += heal;
            _currentHp = Mathf.Min(_currentHp, _playerEventSystem.Data.InitialHp);
            
            _playerEventSystem.ChangePlayerHp(_currentHp);
            CheckPlayerCondition();
        }

        public void IncreaseRage(int rageAmount)
        {
            rageAmount = Math.Abs(rageAmount);
            
            _currentRage += rageAmount;
            _currentHp = Mathf.Min(_currentRage, _playerEventSystem.RequiredAmountOfRage);

            _playerEventSystem.ChangePlayerRage(_currentRage);
        }
    }
}