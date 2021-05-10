using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour {

      public Animator animMain;
      public Animator animInvisible;
	  public Rigidbody2D rb2D;
      public GameObject torso;
      public Transform feet;
	  public LayerMask groundLayer;
      public LayerMask enemyLayer;
      public bool isAlive = true;

      void Start(){
            rb2D = GetComponent<Rigidbody2D>();
      }

     void Update() {
           if ((Input.GetButton("Crouch")) && (IsGrounded()) && (isAlive==true)) {
                  torso.SetActive(false);
                  animMain.SetBool("Crouch", true);
				  animInvisible.SetBool("Crouch", true);
            } else {
                  torso.SetActive(true);
                  animMain.SetBool("Crouch", false);
				  animInvisible.SetBool("Crouch", false);
            }
      }

      public bool IsGrounded() {
            Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 2f, groundLayer);
            Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);
           if ((groundCheck != null) || (enemyCheck != null)) {
                  return true;
                  //Debug.Log("I can crouch now!");
            }
            return false;
      }
}