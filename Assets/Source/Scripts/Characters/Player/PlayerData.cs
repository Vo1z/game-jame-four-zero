using UnityEngine;

namespace Ingame
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "NewPlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] [Range(0, 100)] private float speed = 10;

        public float Speed => speed;
    }
}