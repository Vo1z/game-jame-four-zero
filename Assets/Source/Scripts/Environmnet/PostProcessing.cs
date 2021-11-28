using Support;
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

    private void Start()
    {
        EnterNormalMode();
        GameController.Instance.OnFirstStagePassed += EnterBerserkMode;
    }

    private void OnDestroy()
    {
        GameController.Instance.OnFirstStagePassed -= EnterBerserkMode;
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
