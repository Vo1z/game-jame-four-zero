using Extensions;
using Ingame.Events;
using NaughtyAttributes;
using Support;
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

        public float CurrentSpeed => _currentSpeed;

        private void Awake()
        {
            _playerEventSystem = GetComponent<PlayerEventSystem>();
        }

        private void Start()
        {
            _currentHp = _playerEventSystem.Data.InitialHp;
            _currentSpeed = _playerEventSystem.Data.InitialSpeed;
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
            
            _playerEventSystem.ChangePlayerHp(_currentHp);
            CheckPlayerCondition();
        }

        public void Heal(float heal)
        {
            heal = Mathf.Abs(heal);

            _currentHp += heal;
            
            _playerEventSystem.ChangePlayerHp(_currentHp);
            CheckPlayerCondition();
        }
    }
}