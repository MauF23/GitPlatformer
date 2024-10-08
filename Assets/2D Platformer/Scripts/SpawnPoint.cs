using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	void Start()
	{
		Transform player = GameManager.instance.playerGameObject.transform;
		player.transform.position = transform.position;
	}

}
