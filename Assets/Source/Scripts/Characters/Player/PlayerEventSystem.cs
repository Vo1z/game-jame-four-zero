using System.Collections;
using System.Collections.Generic;
using Support;
using UnityEngine;

namespace Ingame.Events
{
    public class PlayerEventSystem : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        public PlayerData Data => playerData;
    }
}
