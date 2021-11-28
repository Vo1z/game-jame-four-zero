using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(Collider2D), typeof(HandAnimation))]
    public class HandObstacle : MonoBehaviour
    {
        [Required]
        [SerializeField] private Transform targetPos;
        [SerializeField] [Min(0)] private float speed = 3f;
        [SerializeField] [Min(0)] private float grabbingTime = 1f; 

        private enum HandStage { Moving, Grabbing, Resting }

        private const float GIZMOS_SPHERE_SIZE = .2f;
        private const float MINIMAL_DISTANCE_BETWEEN_VECTORS = .1f;
        private const float HAND_DAMAGE = 999999999999999f;

        private HandAnimation _handAnimation;
        private HandStage _handStage = HandStage.Resting;
        private Vector3 _initialPosition;
        
        private void Awake()
        {
            _handAnimation = GetComponent<HandAnimation>();
            _initialPosition = transform.position;
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerStats player))
            {
                switch (_handStage)
                {
                    case HandStage.Moving:
                        return;
                    case HandStage.Grabbing:
                        player.TakeDmg(HAND_DAMAGE);
                        _handAnimation.PlayGrabAnimation();
                        HideFromTheLevel();
                        break;
                    case HandStage.Resting:
                        return;
                }
            }
        }

        private void OnDrawGizmos()
        {
            if(targetPos == null)
                return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetPos.position, GIZMOS_SPHERE_SIZE);
            Gizmos.DrawLine(transform.position, targetPos.position);
        }

        private IEnumerator MoveToTheLevelRoutine()
        {
            if(_handStage == HandStage.Moving || _handStage == HandStage.Grabbing)
                yield break;
            
            _handStage = HandStage.Moving;

            while (Vector3.Distance(transform.position, targetPos.transform.position) > MINIMAL_DISTANCE_BETWEEN_VECTORS)
            {
                transform.position += Vector3.Normalize(targetPos.transform.position - transform.position) * Time.deltaTime * speed;

                yield return null;
            }

            transform.position = targetPos.position;

            _handStage = HandStage.Grabbing;
        }

        private IEnumerator HideFromTheLevelRoutine()
        {
            if(_handStage == HandStage.Moving)
                yield break;

            _handStage = HandStage.Moving;

            while (Vector3.Distance(transform.position, _initialPosition) > MINIMAL_DISTANCE_BETWEEN_VECTORS)
            {
                transform.position += Vector3.Normalize(_initialPosition - transform.position) * Time.deltaTime * speed;
                
                yield return null;
            }
            
            transform.position = _initialPosition;

            _handStage = HandStage.Resting;
        }

        private IEnumerator ActivateRoutine()
        {
            yield return MoveToTheLevelRoutine();
            yield return new WaitForSeconds(grabbingTime);
            yield return HideFromTheLevelRoutine();
        }

        public void MoveToTheLevel()
        {
            StartCoroutine(MoveToTheLevelRoutine());
        }

        public void HideFromTheLevel()
        {
            StartCoroutine(HideFromTheLevelRoutine());
        }

        public void Activate()
        {
            StartCoroutine(ActivateRoutine());
        }
    }
}