using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChecker : MonoBehaviour
{
	public KeyCode triggerKey;
	public int coinsToGet = 1;
	private GameObject player;
	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.instance;
	}
	void Update()
	{
		if (gameManager.coinsCounter >= coinsToGet)
		{
			gameManager.fader.FadeIn();
		}
	}
}
