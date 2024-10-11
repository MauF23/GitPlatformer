using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting.Dependencies.NCalc;

namespace Platformer
{
	public class GameManager : MonoBehaviour
	{
		public int coinsCounter = 0;

		public GameObject playerGameObject;
		private PlayerController player;
		public GameObject deathPlayerPrefab;
		public GameObject test;
		public Text coinText;
		public Fader fader;
		public static GameManager instance;
		public int hp 
		{
			get 
			{ 
				return _hp; 
			}
			set 
			{ 
				_hp = value;
				Debug.Log($"MyHpIs{_hp}");
			} 
		}
		private int _hp;

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		void Start()
		{
			player = GameObject.Find("Player").GetComponent<PlayerController>();
		}

		void Update()
		{
			coinText.text = coinsCounter.ToString();
			if (player.deathState == true)
			{
				playerGameObject.SetActive(false);
				GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
				deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
				player.deathState = false;
				Invoke("ReloadLevel", 3);
			}

			if (Input.GetKeyDown(KeyCode.P))
			{
				SceneManager.LoadScene(1);
			}
		}

		private void ReloadLevel()
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
