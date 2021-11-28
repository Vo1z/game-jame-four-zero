using NaughtyAttributes;
using UnityEngine;

namespace Support.UI
{
    /// <summary>
    /// Class that allows to access UI elements
    /// </summary>
    public class UiController : MonoSingleton<UiController>
    {
        [Required] [SerializeField] private Joystick _joystick;

        public Joystick Joystick => _joystick;
    }
}