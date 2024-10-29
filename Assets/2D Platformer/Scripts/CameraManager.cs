using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
	[Header("DamageShakeParameters")]
	public float damageShakeFrecuency;
	public float damageShakeAmplitude;

	[Range(0f, 1f)]
	public float damageShakeDuration;

	[Header("HitEnemyShakeParameters")]
	public float hitEnemyShakeFrecuency;
	public float hitEnemyAmplitude;

	[Range(0f, 1f)]
	public float hitEnemyDuration;

	public CinemachineVirtualCamera virtualCamera;
	private CinemachineBasicMultiChannelPerlin noise;
	private Coroutine shakeRoutine;
	public static CameraManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	void Start()
	{
		noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		ResetShake();
	}

	public void CameraShakeDamage()
	{
		if(shakeRoutine != null)
		{
			StopCoroutine(shakeRoutine);
		}

		shakeRoutine = StartCoroutine(ShakeCoroutine(damageShakeAmplitude, damageShakeFrecuency, damageShakeDuration));
	}

	public void CameraShakeHitEnemy()
	{
		if (shakeRoutine != null)
		{
			StopCoroutine(shakeRoutine);
		}

		shakeRoutine = StartCoroutine(ShakeCoroutine(hitEnemyAmplitude, hitEnemyShakeFrecuency, hitEnemyDuration));
	}

	private void ResetShake()
	{
		noise.m_FrequencyGain = 0f;
		noise.m_AmplitudeGain = 0f;
	}

	IEnumerator ShakeCoroutine(float apmlitude, float frecuency, float duration)
	{
		noise.m_FrequencyGain = frecuency;
		noise.m_AmplitudeGain = apmlitude;

		yield return new WaitForSecondsRealtime(duration);
		ResetShake();

	}



}
