using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.Instance.OnDmgZoneEnter += PeformAttackOnPlayer;
        EnemyManager.Instance.OnDmgZoneExit += NullifyAttack;

    }
    private void PeformAttackOnPlayer()
    {
        
    }
   
    private void NullifyAttack()
    {

    }

}
