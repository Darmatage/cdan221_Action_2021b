using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt : MonoBehaviour {

      public Animator animMain;
      public Animator animInvisible;
      public CameraShake camShake;
	  public Rigidbody2D rb2D;

      void Start(){
        rb2D = transform.GetComponent<Rigidbody2D>();
		camShake = GameObject.FindWithTag("CameraShake").GetComponent<CameraShake>();
      }

      public void playerHit(){
            animMain.SetTrigger ("GetHurt");
			animInvisible.SetTrigger ("GetHurt");
			StartCoroutine(camShake.ShakeMe(0.15f, 0.3f));
      }

      public void playerDead(){
            rb2D.isKinematic = true;
            animMain.SetTrigger ("Dead");
			animInvisible.SetTrigger ("Dead");
      }
}