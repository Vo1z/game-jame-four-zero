    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame.Enviroment {
    public class BedScript : BackGroundChange
    {
        // Start is called before the first frame update
        
        private const int MIN_RAND_VAL = 0;
        private const int MAX_RAND_VAL = 10;
        private const int chance = 3;

        private bool Roll()
        {
            int rand = Random.Range(MIN_RAND_VAL, MAX_RAND_VAL);
            var result = rand % chance == 0 ? true : false;
            return result;
        }
        public override void EnterSecondMode()
        {
            bool result = Roll();
            if (result)
            {
                base.EnterSecondMode();
            }
        }
        

    }
}