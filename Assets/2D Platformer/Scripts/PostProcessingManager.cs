using DG.Tweening;
using DG.Tweening.Core;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
	public Volume volume;
	private ChromaticAberration chromaticAberration;
	private Tween chromaticTween;
	public static PostProcessingManager instance;

	float dude;

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
	}

	public void TweenChromaticAberration(float endVale, float tweenTime, bool yoyo)
	{
		if (chromaticAberration != null)
		{
			int loops = yoyo ? 2 : 1;

			chromaticTween = DOTween.To
			(
				() => chromaticAberration.intensity.value, //MyGetter
				x => chromaticAberration.intensity.value = x,//MySetter
				endVale,
				tweenTime
			).SetLoops(loops, LoopType.Yoyo);
		}
	}

	private void GetPostProcessFx()
	{
		volume.profile.TryGet(out chromaticAberration);
	}

	float MyGetter()
	{
		return chromaticAberration.intensity.value;
	}

	void MySetter(float targetValue)
	{
		chromaticAberration.intensity.value = targetValue;
	}

	//void Example()
	//{
	//	Action <Vector3> myAction = x => transform.position = x;
	//	Func<Vector3, Vector3> myFunc = x => x = Vector3.one;
	//}
}
