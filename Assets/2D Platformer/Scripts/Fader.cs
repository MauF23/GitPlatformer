using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
	public Image image;
	public float fadeTime;
	public float endValue;

	private void Start()
	{
		image.DOFade(endValue, fadeTime);
	}

	public void FadeIn()
	{
		image.DOFade(1, fadeTime).OnComplete(SceneChange);
	}

	public void SceneChange()
	{
		SceneManager.LoadScene(1);
	}

}
