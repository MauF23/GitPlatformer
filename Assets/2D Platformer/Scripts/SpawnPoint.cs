using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	private GameManager gameManager;
	void Start()
	{
		gameManager = GameManager.instance;

		if(gameManager!= null)
		{
			gameManager.playerGameObject.transform.position = transform.position;
		}
	}

}
