using System.Collections;
using System.Collections.Generic;
using Extensions;
using Ingame.Events;
using Ingame.Stats;
using NaughtyAttributes;
using Support;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ingame
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GameArea : MonoBehaviour
    {
        [SerializeField] [MinMaxSlider(0, 10)] private Vector2 randomPauseBetweenSpawningFallingObstacles;
        [SerializeField] [MinMaxSlider(0, 10)] private Vector2 randomPauseBetweenSpawningPills;
        [SerializeField] [MinMaxSlider(0, 10)] private Vector2 randomPauseBetweenSpawningEnemies;
        [SerializeField] [MinMaxSlider(0, 10)] private Vector2 randomPauseBetweenShowingHands;
        [SerializeField] private FallingObstacleController fallingObstacleController;
        [SerializeField] private List<HandObstacle> hands;
        [Space] 
        [Required] [SerializeField] private GameObject cloudPrefabForPill;
        [Required] [SerializeField] private Pill pillPrefab;
        [Required] [SerializeField] private GameObject cloudPrefabForEnemy;
        [Required] [SerializeField] private EnemyStats enemyPrefab;

        private BoxCollider2D _boxCollider2D;
        private bool _isWorking = false;
        
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            GameController.Instance.OnLevelEnded += OnLevelEnd;
            GameController.Instance.OnFirstStagePassed += OnFirstStagePassed;
            
            _isWorking = true;
            StartCoroutine(SpawnFallingObstaclesRoutine());
            StartCoroutine(ActivateHandsRoutine());
            StartCoroutine(SpawnPillsRoutine());
            StartCoroutine(SpawnEnemies());
        }

        private void OnDestroy()
        {
            GameController.Instance.OnLevelEnded -= OnLevelEnd;
            GameController.Instance.OnFirstStagePassed -= OnFirstStagePassed;
        }

        private void OnFirstStagePassed()
        {
            StopAllCoroutines();
            _isWorking = false;
        }

        private void OnLevelEnd(bool _)
        {
            StopAllCoroutines();
            _isWorking = false;
        }

        private IEnumerator SpawnFallingObstaclesRoutine()
        {
            while (_isWorking)
            {
                var minBounds = _boxCollider2D.bounds.min;
                var maxBounds = _boxCollider2D.bounds.max;
                
                var pauseBetweenFallingObstacles =
                    Random.Range(randomPauseBetweenSpawningFallingObstacles.x, randomPauseBetweenSpawningFallingObstacles.y);
                
                var fallingPos = Random.value >= .5f
                    ? PlayerEventSystem.Instance.transform.position
                    : new Vector3(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.x, maxBounds.x), 0);

                yield return new WaitForSeconds(pauseBetweenFallingObstacles);
                
                fallingObstacleController.Fall(fallingPos);
            }
        }

        private IEnumerator ActivateHandsRoutine()
        {
            while (_isWorking)
            {
                var pauseBetweenShowingHand = Random.Range(randomPauseBetweenShowingHands.x, randomPauseBetweenShowingHands.y);
                var handToActivate = hands.GetRandom();

                yield return new WaitForSeconds(pauseBetweenShowingHand);
                
                handToActivate.Activate();
            }
        }

        private IEnumerator SpawnPillsRoutine()
        {
            while (_isWorking)
            {
                var pauseBetweenSpawningPills = Random.Range(randomPauseBetweenSpawningPills.x, randomPauseBetweenSpawningPills.y);
                
                var minBounds = _boxCollider2D.bounds.min;
                var maxBounds = _boxCollider2D.bounds.max;
                var spawningPos = new Vector3(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.x, maxBounds.x), 0);
                
                yield return new WaitForSeconds(pauseBetweenSpawningPills);

                Instantiate(cloudPrefabForPill, spawningPos, Quaternion.identity);
                Instantiate(pillPrefab, spawningPos, Quaternion.identity);
            }
        }

        private IEnumerator SpawnEnemies()
        {
            while (_isWorking)
            {
                var pauseBetweenSpawningEnemies = Random.Range(randomPauseBetweenSpawningEnemies.x, randomPauseBetweenSpawningEnemies.y);
                var minBounds = _boxCollider2D.bounds.min;
                var maxBounds = _boxCollider2D.bounds.max;
                var spawningPos = new Vector3(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.x, maxBounds.x), 0);
                
                yield return new WaitForSeconds(pauseBetweenSpawningEnemies);

                Instantiate(cloudPrefabForEnemy, spawningPos, Quaternion.identity);
                Instantiate(enemyPrefab, spawningPos, Quaternion.identity);
            }
        }

        private void OnDrawGizmos()
        {
            var boxCollider = GetComponent<BoxCollider2D>();
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.size);
        }
    }
}