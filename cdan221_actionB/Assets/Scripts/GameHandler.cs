using System.Collections.Generic;
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

      public static int gotTokens = 0;
      public GameObject tokensText;

      public bool isDefending = false;

      void Start(){
            player = GameObject.FindWithTag("Player");
            playerHealth = StartPlayerHealth;
            updateStatsDisplay();       
      }

      public void playerGetTokens(int newTokens){
            gotTokens += newTokens;
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

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "GOLD: " + gotTokens;
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