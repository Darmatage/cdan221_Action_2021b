using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUps : MonoBehaviour{

      public GameHandler gameHandler;
	  public int bloodValue = 1; 
      //public playerVFX playerPowerupVFX;
      // public bool isHealthPickUp = true;
      // public bool isObjectPickUp = false;
      // public bool isSpeedBoostPickUp = false;

      // public int healthBoost = 50;
      // public float speedBoost = 2f;
      // public float speedTime = 2f;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  gameHandler.playerGetBlood(bloodValue);
                  //playerPowerupVFX.powerup();
                  Destroy(gameObject);
            }

            // if ((isObjectPickUp == true) && (other.gameObject.tag == "Player")){
                  // gameHandler.GetComponent<GameHandler>().playerFoundObject("tokenName");
                  // Destroy(gameObject);
            // }

            // if ((isSpeedBoostPickUp == true) && (other.gameObject.tag == "Player")){
                  // other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
                  // playerPowerupVFX.powerup();
                  // Destroy(gameObject);
            // }
      }

}