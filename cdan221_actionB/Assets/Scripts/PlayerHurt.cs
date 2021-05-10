using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt : MonoBehaviour {

      public Animator animMain;
      public Animator animInvisible;
      public Rigidbody2D rb2D;

      void Start(){
           rb2D = transform.GetComponent<Rigidbody2D>();           
      }

      public void playerHit(){
            animMain.SetTrigger ("GetHurt");
			animInvisible.SetTrigger ("GetHurt");
      }

      public void playerDead(){
            rb2D.isKinematic = true;
            animMain.SetTrigger ("Dead");
			animInvisible.SetTrigger ("Dead");
      }
}