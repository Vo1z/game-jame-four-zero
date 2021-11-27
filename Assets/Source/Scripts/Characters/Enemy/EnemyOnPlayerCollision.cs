using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame.Events;
public class EnemyOnPlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerEventSystem player))
        {
            EnemyManager.Instance.DmgZoneEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerEventSystem player))
        {
            EnemyManager.Instance.DmgZoneExit();
        }
    }
}
