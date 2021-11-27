using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Events;
using NaughtyAttributes;
namespace Ingame.Movement { 
        public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private PlayerEventSystem player;
        private Transform _playerPosition;
        private void Awake()
        {
            _playerPosition = player.transform;
        }

        public void FollowPlayer()
        {
            var direction = (this.transform.position.z - _playerPosition.position.z) /
                (this.transform.position.x - _playerPosition.position.x);

        }

        public void RunAwayFromPlayer()
        {
            
        }
    }
}
