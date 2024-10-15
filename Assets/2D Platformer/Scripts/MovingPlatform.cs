using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
	public Transform platform;
	public Transform [] points;
	private int destinationCounter;
	public float movementTime;
	public Ease easeType;

	void Start()
	{
		platform.DOMove(ChangeDestination(), movementTime).SetLoops(-1, LoopType.Yoyo).OnComplete(delegate { ChangeDestination(); }).SetEase(easeType);
	}

	public Vector3 ChangeDestination()
	{
		destinationCounter++;
		if(destinationCounter > points.Length)
		{
			destinationCounter = 0;
		}

		return points[destinationCounter].position;
	}

}
