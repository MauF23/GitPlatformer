using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChecker : MonoBehaviour
{
	public KeyCode triggerKey;
	private GameObject player;
	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.instance;
	}
	void Update()
	{
		if (Input.GetKeyDown(triggerKey))
		{
			Debug.Log(GameManager.instance.coinsCounter);

			if(gameManager.coinsCounter >= 2)
			{
				gameManager.fader.FadeIn();			
			}

			gameManager.hp = Random.Range(1, 7);
		}
	}
}
