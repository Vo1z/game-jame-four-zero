using UnityEngine;

namespace Ingame.Events
{
    public class PlayerEventSystem : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        private PlayerMovement _playerMovement;
        private PlayerStats _playerStats;
        
        public PlayerData Data => playerData;
        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerStats PlayerStats => _playerStats;
        
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerStats = GetComponent<PlayerStats>();
        }
    }
}
