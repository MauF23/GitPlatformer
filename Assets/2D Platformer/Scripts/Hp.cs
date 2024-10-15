using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
	public int maxHp;
	public int currentHp
	{
		get { return _currentHp; }
		private set { _currentHp = value; }
	}

	[SerializeField]
	private int _currentHp;
	private GameManager gameManager;

	//Variables efecto de da�o
	public SpriteRenderer spriteRenderer;
	public Image image;
	public Color damageColor;
	public float damageTweenTime;

	//Knockback
	public Rigidbody2D rigidbody2D;
	public float knockbackForce;

	void Start()
	{
		currentHp = maxHp;
		gameManager = GameManager.instance;

	}

	private void Knockback()
	{

		//Vector3 knockbackDirection = gameManager.player.FacingRight() ? Vector3.left : Vector3.right;

		Vector3 knockbackDirection = Vector3.zero;

		if (gameManager.player.FacingRight())
		{
			knockbackDirection = Vector3.left;
		}
		else 
		{
			knockbackDirection = Vector3.right;
		}


		rigidbody2D.AddForce(knockbackDirection * knockbackForce);
		rigidbody2D.AddForce(transform.up * knockbackForce);

	}

	public void ReduceHp(int amount)
	{
		currentHp -= amount;
		currentHp = Mathf.Clamp(currentHp, 0, maxHp);

		//Aplicar efecto visual de da�o
		spriteRenderer.DOColor(damageColor, damageTweenTime).SetLoops(2, LoopType.Yoyo).OnStart(BlockMovement).OnComplete(UnblockMovement);


		//C�digo para reflejar el da�o con una imagen, uno con DOFade y otro con DOColor.
		//image.DOFade(1, damageTweenTime).SetLoops(2, LoopType.Yoyo).OnStart(BlockMovement).OnComplete(UnblockMovement);
		//image.DOColor(damageColor, damageTweenTime).SetLoops(2, LoopType.Yoyo).OnStart(BlockMovement).OnComplete(UnblockMovement);

		Knockback();

		if (currentHp <= 0 && gameManager != null)
		{
			gameManager.GameOver();
		}
	}

	public void UnblockMovement()
	{
		gameManager.player.movementBlocked = false;
	}

	public void BlockMovement()
	{
		gameManager.player.movementBlocked = true;	
	}
}
