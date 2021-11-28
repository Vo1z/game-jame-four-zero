using System;
using System.Collections;
using Support;
using Support.SLS;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ingame.Events
{
    public class PlayerEventSystem : MonoSingleton<PlayerEventSystem>
    {
        [SerializeField] private PlayerData playerData;
        
        private PlayerMovement _playerMovement;
        private PlayerStats _playerStats;
        private PlayerAnimation _playerAnimation;

        public PlayerData Data => playerData;
        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerStats PlayerStats => _playerStats;
        public PlayerAnimation PlayerAnimation => _playerAnimation;

        public event Action<float> OnPlayerHpChanged;
        public event Action<int> OnRageChanged;
        public event Action<float> OnPlayerMove;
        public event Action<PsychoModeDeBuff> OnPsychoMode;
        public event Action OnDeath;
        
        public int RequiredAmountOfRage => Data.InitialRageRequired + 
                                           SaveLoadSystem.Instance.SaveData.CurrentLevelNumber.Value * Data.DeltaRage;

        protected override void Awake()
        {
            base.Awake();
            
            _playerMovement = GetComponent<PlayerMovement>();
            _playerStats = GetComponent<PlayerStats>();
            _playerAnimation = GetComponent<PlayerAnimation>();
        }

        private void Start()
        {
            StartCoroutine(ManagePsychoMode());
        }

        private IEnumerator ManagePsychoMode()
        {
            while (true)
            {
                var psychoModeDeBuffType = Data.DeBuffsForPsychoModeStage[Random.Range(0, Data.DeBuffsForPsychoModeStage.Length - 1)];
                var timeToWaitTheNextStage = Random.Range(Data.RandomPauseBetweenPsychoMods.x, Data.RandomPauseBetweenPsychoMods.y);
                var psychoModeDuration = Random.Range(Data.RandomPsychoModeDuration.x, Data.RandomPsychoModeDuration.y);
                
                yield return new WaitForSeconds(timeToWaitTheNextStage);
                
                ChangePsychoMode(psychoModeDeBuffType);

                yield return new WaitForSeconds(psychoModeDuration);
                
                ChangePsychoMode(PsychoModeDeBuff.Normal);
            }
        }

        public void ChangePlayerHp(float currentHp)
        {
            OnPlayerHpChanged?.Invoke(currentHp);
        }

        public void Move(float speed)
        {
            OnPlayerMove?.Invoke(speed);
        }

        public void ChangePsychoMode(PsychoModeDeBuff psychoModeDeBuff)
        {
            OnPsychoMode?.Invoke(psychoModeDeBuff);
        }

        public void ChangePlayerRage(int amountOfRage)
        {
            OnRageChanged?.Invoke(amountOfRage);
            
            if(amountOfRage >= RequiredAmountOfRage)
                GameController.Instance.PassFirstStage();
        }

        public void Die()
        {
            OnDeath?.Invoke();
            GameController.Instance.EndLevel(false);
            Destroy(gameObject);
        }
    }

    public enum PsychoModeDeBuff
    {
        InverseControls,
        Split,
        Normal
    }
}
