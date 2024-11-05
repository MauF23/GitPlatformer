using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering; //Librería general de rendering
using UnityEngine.Rendering.Universal;//necesaria si el proyecto es URP
using System;

public class PostProcessingManager : MonoBehaviour
{
	public Volume volume;
	private Tween chromaticTween;

	public ChromaticAberration chromaticAberration;
	public Vignette vignette;

	public float myTweenFloat;
	//public Bloom bloom;
	public static PostProcessingManager instance;
	private Action myAction;


	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		GetPostProcessFx();
		SampleTween();
	}

	private void SampleTween()
	{
		float endValue = 5;
		float tweenTime = 2;

		DOTween.To(() => myTweenFloat, targetValue => myTweenFloat = targetValue, endValue, tweenTime);


		myAction = () => LogFuntion();
		myAction.Invoke();
	}

	private void LogFuntion()
	{
		Debug.Log("Hola");
	}

	public void TweenChromaticAberration(float endVale, float tweenTime, bool yoyo)
	{
		int loops = 0;

		if (chromaticAberration != null)
		{
			//if (yoyo)
			//{
			//	loops = 2;
			//}
			//else
			//{
			//	loops = 1;
			//}

			loops = yoyo ? 2 : 1;

			chromaticTween = DOTween.To
			(
				() => chromaticAberration.intensity.value, //MyGetter
				x => chromaticAberration.intensity.value = x,//MySetter
				endVale,
				tweenTime
			).SetLoops(loops, LoopType.Yoyo);
		}
	}
	public void TweenVignette(float endVale, float tweenTime)
	{
		DOTween.To(()=>vignette.intensity.value, x => vignette.intensity.value = x, endVale, tweenTime).SetLoops(2, LoopType.Yoyo);
	}

	private void GetPostProcessFx()
	{
		volume.profile.TryGet(out chromaticAberration);
		volume.profile.TryGet(out vignette);

		if(vignette != null)
		{
			vignette.intensity.value = 0;
		}
	}

	float MyGetter()
	{
		return myTweenFloat;
	}

	void MySetter(float targetValue)
	{
		myTweenFloat = targetValue;
	}
}
