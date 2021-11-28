using UnityEngine;

namespace Ingame
{
    [RequireComponent(typeof(Collider2D))]
    public class Pill : MonoBehaviour
    {
        [Tooltip("Amount of HP that player will gain by picking the pill")]
        [SerializeField] private float hp = 1;
        [SerializeField] private int rage = 1;
        [Space] 
        [SerializeField] private GameObject destroyVFX;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerStats player))
            {
                player.Heal(hp);
                player.IncreaseRage(rage);
                
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if(destroyVFX != null)
                Instantiate(destroyVFX, transform.position, Quaternion.identity);
        }
    }
}