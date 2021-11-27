using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Events;
using NaughtyAttributes;

namespace Ingame.Movement { 
        public class EnemyMovement : MonoBehaviour
    {
        
        [SerializeField]
        private EnemyEventControl enemyEventControl;
        [SerializeField]
        [Required]
        private PlayerEventSystem player;
        private const float MARGIN_ERROR_MIN = .0001f;
        private const float MARGIN_ERROR_MAX = 1f;
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            enemyEventControl = GetComponent<EnemyEventControl>();
            _rb = GetComponent<Rigidbody2D>();
            
        }
        private void Update()
        {
            FollowPlayer();
        }
        private void Start()
        {
            EnemyManager.Instance.OnFollowEnter +=FollowPlayer;
            EnemyManager.Instance.OnFollowExit += RunAwayFromPlayer;
        }
        private void MakeMove(int i)
        {
            float dirY = (player.transform.position.z-this.transform.position.z);
            dirY = dirY > MARGIN_ERROR_MAX ? 1 : (dirY < MARGIN_ERROR_MIN ? -1 : 0);


            float dirX = (player.transform.position.x - this.transform.position.x);
            dirX = dirX > MARGIN_ERROR_MAX ? 1 : (dirX < MARGIN_ERROR_MIN ? -1 : 0);

            var direction =   Vector3.up* dirY + Vector3.right*dirX;
            direction *= enemyEventControl.EnemyStatsData.Speed*Time.fixedDeltaTime;
            
            _rb.velocity = direction;
        }
        public void FollowPlayer()
        {
            MakeMove(1);
        }
        public void RunAwayFromPlayer()
        {
            MakeMove(-1);
        }
    }
}
