using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public int maxHp;
	public int currentHp
	{
		get { return _currentHp; } 
		private set { _currentHp = value; } 
	}

	private int _currentHp;
	private GameManager gameManager;

	void Start()
    {
        currentHp = maxHp;
		gameManager = GameManager.instance;

	}

    public void ReduceHp(int amount)
	{
		currentHp -= amount;
		currentHp = Mathf.Clamp(currentHp, 0, maxHp);

		if(currentHp <= 0 && gameManager != null)
		{
			gameManager.GameOver();
		}
	}
}
