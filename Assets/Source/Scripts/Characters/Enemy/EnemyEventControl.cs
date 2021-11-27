using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventControl : MonoBehaviour
{
    [Required]
    [SerializeField]
    private EnemyData enemyStats;

    public EnemyData EnemyStats => enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
