using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerDefend : MonoBehaviour {

      private GameHandler gameHandler;
      //public Animator animator;
      public Rigidbody2D rb2D;
      public GameObject shieldArt;
      public float defendTime = 2.0f;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
           //animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
           shieldArt.SetActive(false);           
      }

      void Update(){
            //Defense activation
           if (Input.GetAxis("Defend") > 0){
                  playerDefend();
            }
      }

      public void playerDefend(){
            gameHandler.isDefending = true;
            shieldArt.SetActive(true);
            //animator.SetBool("Defend", true);
            StartCoroutine(playerNoDefend());
      }

      IEnumerator playerNoDefend(){
            yield return new WaitForSeconds(defendTime);
            gameHandler.isDefending = false;
            shieldArt.SetActive(false);
            //animator.SetBool("Defend", false);
      }
}