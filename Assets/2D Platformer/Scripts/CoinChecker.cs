using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChecker : MonoBehaviour
{
	public KeyCode triggerKey;
	public int coinCounter
	{
		get { return _coinCounter; }
		set
		{
			_coinCounter = value;

			if (gameManager != null)
			{
				gameManager.coinText.text = _coinCounter.ToString();
			}

			if (_coinCounter >= coinsToGet)
			{
				gameManager.LoadScene(sceneToLoad);
			}
		}

	}

	[SerializeField]
	private int _coinCounter;

	[SerializeField]
	private int coinsToGet;
	public int sceneToLoad;


	private GameObject player;
	private GameManager gameManager;
	public static CoinChecker instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		//Asegurarse que al menos se necsite una moneda para pasar al siguiente nivel.
		if (coinsToGet <= 0)
		{
			coinsToGet = 1;
		}

		gameManager = GameManager.instance;
		GetTotalCoins();
	}


	/// <summary>
	/// Obtiene todas las monedas colocadas en el nivel
	/// </summary>
	private void GetTotalCoins()
	{
		coinsToGet = GameObject.FindGameObjectsWithTag("Coin").Length;
	}
}
