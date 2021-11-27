using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor 
{
    public void TakeDmg(float dmg);
    public void Heal(float heal);
    public void Die();
}
