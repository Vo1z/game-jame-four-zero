using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Data/EnemyData", fileName = "newEnemyData")]
public class EnemyData : ScriptableObject
{
    [Foldout("Sustain")]
    [SerializeField]
    [Min(0)]
    private float _initHpBar;

    [Foldout("Attack")]
    [SerializeField]
    [Min(0)]
    private float _attackDmg;
    [SerializeField]
    [Min(0)]
    private float _attackCoolDown;

    public float InitHpBar => _initHpBar;
    public float AttackDemg => _attackDmg;
    public float AttackCoolDown => _attackCoolDown;


}
