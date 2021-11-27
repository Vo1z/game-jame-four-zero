using System;
using DG.Tweening;
using NaughtyAttributes;
using Support;
using UnityEngine;

namespace Ingame
{
    public class FallingObstacleController : MonoBehaviour
    {
        [BoxGroup("Animation options")]
        [SerializeField] [Min(0)] private float displayingShadowDuration = 1.5f;
        [BoxGroup("Animation options")]
        [SerializeField] [Min(0)] private float fallingDuration = .1f;
        [BoxGroup("Animation options")]
        [SerializeField] private Vector2 shadowScaleModifier = new Vector2(1f, 1f);
        [Space]
        [Required] [SerializeField] private GameObject shadowPrefab;
        [Required] [SerializeField] private Obstacle obstaclePrefab;

        private const float GIZMOS_CUBE_SIZE = .3f;
        private const float OBSTACLE_SPAWNING_Y_OFFSET = 30f;
        private const float SHADOW_SPAWNING_OFFSET = .1f;

        private void Start()
        {
            Fall(new Vector3(-30, -30));
        }

        public void Fall(Vector3 destination)
        {
            var obstacleSpawningPos = new Vector2(destination.x, transform.position.y);
            var shadow = Instantiate(shadowPrefab, destination - Vector3.down * SHADOW_SPAWNING_OFFSET, Quaternion.identity);
            var obstacle = Instantiate(obstaclePrefab, obstacleSpawningPos, Quaternion.identity);
            var shadowScale = shadow.transform.localScale;
            var shadowTargetScale = new Vector3
            (
                shadowScale.x * shadowScaleModifier.x,
                shadowScale.y * shadowScaleModifier.y,
                shadowScale.z
            );


            DOTween.Sequence()
                .Append(shadow.transform.DOScale(shadowTargetScale, displayingShadowDuration))
                .Append(obstacle.transform.DOMove(destination, fallingDuration).SetEase(Ease.Linear)
                    .OnComplete(obstacle.Activate));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, Vector3.one * GIZMOS_CUBE_SIZE);
        }
    }
}