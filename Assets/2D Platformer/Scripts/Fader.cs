using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Platformer;

public class Fader : MonoBehaviour
{
	public Image image;

	public float fadeOutWaitTime;
	public float fadeTime;
	public float endValue;
	private int sceneToLoad;
	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.instance;
		StartCoroutine(FadeOut(fadeOutWaitTime));
	}

	/// <summary>
	/// Aparece la imagen moviendo el alpha a uno, cuando llega a ese número carga la escena indicada
	/// </summary>
	/// <param name="sceneIndex">el índice de la escena a cargar</param>
	public void FadeInToScene(int sceneIndex)
	{
		sceneToLoad = sceneIndex;
		Debug.Log($"{transform.name} Alpha is{image.color.a}");
		image.DOFade(1, fadeTime).OnComplete(LoadScene);
	}


	/// <summary>
	/// Desaparece la imagen moviendo el alpha a cero
	/// </summary>
	public void FadeOut()
	{
		image.DOFade(0, fadeTime);
	}

	private void LoadScene()
	{
		SceneManager.LoadScene(sceneToLoad);
		gameManager.ResetPlayer();
		FadeOut();
	}

	public IEnumerator FadeOut(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		FadeOut();
	}

}
