using Ingame.Events;
using NaughtyAttributes;
using UnityEngine;

namespace Ingame
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "NewPlayerData")]
    public class PlayerData : ScriptableObject
    {
        [BoxGroup("Stats options")]
        [SerializeField] [Min(0)] private float initialHp = 10;
        [BoxGroup("Stats options")]
        [SerializeField] [Min(0)] private float initialSpeed = 10;
        [Space]
        [Tooltip("Initial amount of rage required to pass to the second stage")]
        [BoxGroup("Rage options")] [SerializeField] [Min(0)] private int initialRageRequired = 2;
        [Tooltip("Number of rage that will increase with levels")]
        [BoxGroup("Rage options")] [SerializeField] [Min(0)] private int deltaRage = 3;
        [Space]
        [BoxGroup("PsychoMode stats")]
        [SerializeField] [MinMaxSlider(0, 40)] private Vector2 randomPauseBetweenPsychoMods;
        [BoxGroup("PsychoMode stats")]
        [SerializeField] [MinMaxSlider(0, 40)] private Vector2 randomPsychoModeDuration;
        [BoxGroup("PsychoMode stats")]
        [SerializeField] private PsychoModeDeBuff[] deBuffsForPsychoModeStage;
        [BoxGroup("VFX")]
        [SerializeField] private Destroyer deathVFX;
        [BoxGroup("VFX")] 
        [SerializeField] private Destroyer damageVFX;
        
        public float InitialHp => initialHp;
        public float InitialSpeed => initialSpeed;

        public int InitialRageRequired => initialRageRequired;
        public int DeltaRage => deltaRage;

        public Vector2 RandomPauseBetweenPsychoMods => randomPauseBetweenPsychoMods;
        public Vector2 RandomPsychoModeDuration => randomPsychoModeDuration;
        public PsychoModeDeBuff[] DeBuffsForPsychoModeStage => deBuffsForPsychoModeStage;

        public Destroyer DeathVFX => deathVFX;
        public Destroyer DamageVFX => damageVFX;
    }
}