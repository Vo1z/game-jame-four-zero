using Extensions;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(Collider2D))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float damage = 1;
        [SerializeField] [Min(0)] private float damageDealingDuration = 1f;

        private enum ObstacleState { DealingDamage, Resting}
        private ObstacleState _obstacleState = ObstacleState.Resting;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if(_obstacleState == ObstacleState.Resting)
                return;

            if (other.TryGetComponent(out PlayerStats player))
            {
                player.TakeDmg(damage);
                _obstacleState = ObstacleState.Resting;
            }
        }

        public void Activate()
        {
            _obstacleState = ObstacleState.DealingDamage;
            
            this.WaitAndDoCoroutine(damageDealingDuration, () => _obstacleState = ObstacleState.Resting);
        }
    }
}