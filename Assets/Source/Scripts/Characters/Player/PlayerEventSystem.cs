using System;
using Extensions;
using Support;
using UnityEngine;

namespace Ingame.Events
{
    public class PlayerEventSystem : MonoSingleton<PlayerEventSystem>
    {
        [SerializeField] private PlayerData playerData;

        private PlayerMovement _playerMovement;
        private PlayerStats _playerStats;
        private PlayerAnimation _playerAnimation;

        public PlayerData Data => playerData;
        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerStats PlayerStats => _playerStats;
        public PlayerAnimation PlayerAnimation => _playerAnimation;

        public Action<float> OnPlayerHpChanged;
        public Action<float> OnPlayerMove;

        protected override void Awake()
        {
            base.Awake();
            
            _playerMovement = GetComponent<PlayerMovement>();
            _playerStats = GetComponent<PlayerStats>();
            _playerAnimation = GetComponent<PlayerAnimation>();
        }

        public void ChangePlayerHp(float currentHp)
        {
            OnPlayerHpChanged?.Invoke(currentHp);
        }

        public void Move(float speed)
        {
            OnPlayerMove?.Invoke(speed);
        }
    }
}
