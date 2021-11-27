using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Support;
using Ingame.Movement;
using System;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    
    public event Action OnDmgZoneEnter;
    public event Action OnDmgZoneExit;
    public event Action OnFollowEnter;
    public event Action OnFollowExit;

    public void DmgZoneEnter()
    {
        if (OnDmgZoneEnter == null)
        {
            return;
        }
        OnDmgZoneEnter();

    }
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
    public void DmgZoneExit()
    {
        if (OnDmgZoneExit == null)
        {
            return;
        }
        OnDmgZoneExit();

    }


}
