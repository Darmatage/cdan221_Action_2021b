﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameHandler : MonoBehaviour {

	private GameObject player;
	public static int playerHealth;
	public int StartPlayerHealth = 100;
	public GameObject healthText;

	public static int myBlood = 0;
	public GameObject bloodText;

	public bool canInvisible = false;
	public bool canSpeed = false;
	public bool canDefend = false;

    public bool isDefending = false;
	public bool isInvisible = false;
	public bool isSpeedy = false;


      void Start(){
            player = GameObject.FindWithTag("Player");
            playerHealth = StartPlayerHealth;
            updateStatsDisplay();       
      }


		public void playerGetBlood(int newBlood){
			myBlood += newBlood;
            updateStatsDisplay();
		
		}

      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage;
                  updateStatsDisplay();
                  player.GetComponent<PlayerHurt>().playerHit();
            }

           if (playerHealth >= 100){
                  playerHealth = 100;
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth;

            Text bloodTextTemp = bloodText.GetComponent<Text>();
            bloodTextTemp.text = "BLOODS: " + myBlood;
      }

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}