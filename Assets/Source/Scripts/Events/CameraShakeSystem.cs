using System.Collections;
using UnityEngine;
using Cinemachine;
namespace Ingame.Settings {

    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraShakeSystem : MonoBehaviour
    {
        #region VARIABLES
        public enum Smothness
        {
            Both,
            Amplitude,
            Freguency,
            None

        }

        private const int LEVEL_OF_SMOTHNESS = 15;
        private const float TIME_MARGIN_ERROR = .0001f;
        private CinemachineVirtualCamera _cinemachineCamera;
        private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

        #endregion
        #region UNITY
        private void Awake()
        {
            _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
            _cinemachineBasicMultiChannelPerlin = _cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        #endregion
        #region PRIVATE_METHODS
        private IEnumerator ShakeScreenCoroutine(float amplitude, float frequency, float time, Smothness smothness)
        {

            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
            _cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequency;
            float timer = .0f;
            var deltaTime = time / LEVEL_OF_SMOTHNESS;
            while (Mathf.Abs(time - timer) > TIME_MARGIN_ERROR)
            {
                yield return new WaitForSeconds(deltaTime);
                timer += deltaTime;

                switch (smothness)
                {
                    case Smothness.Freguency:
                        _cinemachineBasicMultiChannelPerlin.m_FrequencyGain -= (frequency / LEVEL_OF_SMOTHNESS);
                        break;
                    case Smothness.Amplitude:
                        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain -= (amplitude / LEVEL_OF_SMOTHNESS);
                        break;
                    case Smothness.Both:
                        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain -= (amplitude / LEVEL_OF_SMOTHNESS);
                        _cinemachineBasicMultiChannelPerlin.m_FrequencyGain -= (frequency / LEVEL_OF_SMOTHNESS);
                        break;
                    default:
                    case Smothness.None:
                        break;
                }
            }
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
            _cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
        }
        #endregion
        #region PUBLIC_METHODS
        public void ShakeScreen(float amplitude, float frequency, float time, Smothness smothness)
        {
            StartCoroutine(ShakeScreenCoroutine(amplitude, frequency, time, smothness));

        }
        #endregion
    } 
}