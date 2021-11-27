using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour,IActor
{

    private const float  MARGIN_OF_DEAD= 0f;
    private const float MARGIN_ERROR = 0.001f;
    private float _currHp;



    private void Awake()
    {
        
    }


    public void Die()
    {
        if (Mathf.Abs((_currHp - MARGIN_ERROR))<=MARGIN_OF_DEAD)
        {
            //todo reset
        }
    }

    public void Heal(float heal)
    {
        _currHp += heal;
    }

    public void TakeDmg(float dmg)
    {
        _currHp -= dmg;
    }

}
