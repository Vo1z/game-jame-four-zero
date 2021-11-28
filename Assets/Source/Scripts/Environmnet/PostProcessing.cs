using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private Volume normalVolume;
    [SerializeField]
    private Volume secondStageVolume;

    private void Awake()
    {
        normalVolume.weight = 1;
        secondStageVolume.weight = 0;
    }

    public void EnterBerserkMode()
    {
        normalVolume.weight = 0;
        secondStageVolume.weight = 1;
    }
    public void EnterNormalMode()
    {
        normalVolume.weight = 1;
        secondStageVolume.weight = 0;
    }
}
