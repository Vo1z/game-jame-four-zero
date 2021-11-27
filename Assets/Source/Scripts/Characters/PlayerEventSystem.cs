using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Events { 
public class PlayerEventSystem : MonoBehaviour
{
        public enum Mode
        {
            Patient,
            PreVenom,
            Venom,
        }
       
        private Mode _mode = Mode.Patient;
        public Mode CurrMode => _mode;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SwitchMode(Mode m)
        {

        }
    }
}
