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
		public PlayerController player;
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

			//Asegurarse que si ya existe el manager, que solo haya una instancia
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		void Start()
		{

		}

		void Update()
		{
			coinText.text = coinsCounter.ToString();
			//if (Input.GetKeyDown(KeyCode.P))
			//{
			//	SceneManager.LoadScene(1);
			//}
		}

		private void ReloadLevel()
		{
			LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		public void LoadScene(int level)
		{
			fader.FadeInToScene(level);
		}

		public void ResetPlayer()
		{
			coinText.text = 0.ToString();
			playerGameObject.SetActive(true);
			player.hp.Revive();
		}

		public void GameOver()
		{
			playerGameObject.SetActive(false);
			GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
			deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
			player.deathState = false;
			Invoke("ReloadLevel", 3);
		}
	}
}
