using System;
using Support;
using UnityEngine;

namespace Ingame.Events
{
    public class PlayerEventSystem : MonoSingleton<PlayerEventSystem>
    {
        [SerializeField] private PlayerData playerData;

        private PlayerMovement _playerMovement;
        private PlayerStats _playerStats;
        
        public PlayerData Data => playerData;
        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerStats PlayerStats => _playerStats;

        public Action<float> OnPlayerHpChanged;

        protected override void Awake()
        {
            base.Awake();
            
            _playerMovement = GetComponent<PlayerMovement>();
            _playerStats = GetComponent<PlayerStats>();
        }

        public void ChangePlayerHp(float currentHp)
        {
            OnPlayerHpChanged?.Invoke(currentHp);
        }
    }
}
