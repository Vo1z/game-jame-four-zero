using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;
using Ingame.Movement;
using System;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    

    public event Action OnFollowEnter;
    public event Action OnFollowExit;

  
    public void FollowEnter()
    {
        if (OnFollowEnter == null)
        {
            return;
        }
        OnFollowEnter();

    }
    public void FollowExit()
    {
        if (OnFollowExit == null)
        {
            return;
        }
        OnFollowExit();

    }


}
