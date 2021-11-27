using UnityEngine;

namespace Ingame
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "NewPlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] [Min(0)] private float initialHp = 10;
        [SerializeField] [Min(0)] private float initialSpeed = 10;

        public float InitialHp => initialHp;
        public float InitialSpeed => initialSpeed;
    }
}