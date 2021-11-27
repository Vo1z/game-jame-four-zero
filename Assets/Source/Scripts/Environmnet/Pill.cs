using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(Collider2D))]
    public class Pill : MonoBehaviour
    {
        [Tooltip("Amount of HP that player will gain by picking the pill")]
        [SerializeField] private float hp;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerStats player))
            {
                player.Heal(hp);
                Destroy(gameObject);
            }
        }
    }
}