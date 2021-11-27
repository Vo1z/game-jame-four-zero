using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ingame { 
public interface IActor 
    {
        public void TakeDmg(float dmg);
        public void Heal(float heal);
    }
}
