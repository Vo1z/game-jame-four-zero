using Ingame.Events;
using Support;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(PlayerEventSystem))]
    public class PlayerStats : MonoBehaviour, IActor
    {
        private PlayerEventSystem _playerEventSystem;
        private float _currentHp;
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
        }

        public void TakeDmg(float dmg)
        {
            dmg = Mathf.Abs(dmg);

            _currentHp -= dmg;
            
            CheckPlayerCondition();
        }

        public void Heal(float heal)
        {
            heal = Mathf.Abs(heal);

            _currentHp += heal;
            
            CheckPlayerCondition();
        }
    }
}