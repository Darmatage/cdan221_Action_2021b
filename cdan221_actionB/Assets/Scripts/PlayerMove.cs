using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public Animator animMain;
    public Animator animInvisible;
    public Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed;
    public float startSpeed = 10f;
	public float boostSpeed = 20f;
    public bool isAlive = true;
	public AudioSource walkSFX;

	public bool isSpeedBoost = false;

	private Renderer myRend;
	private Color defaultColor;
	private bool isSpeedChange = false;

	private Vector3 hMove; 

    void Start(){
           rb2D = transform.GetComponent<Rigidbody2D>();
		   myRend = gameObject.GetComponentInChildren<Renderer>();
		   defaultColor = myRend.material.color;
		   runSpeed = startSpeed;
    }

    void Update(){
		if (isSpeedChange == false){
			if (isSpeedBoost == true) {runSpeed = boostSpeed;}
			else {runSpeed = startSpeed;}
		}
			
		//NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
		hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
		if (isAlive == true){    
			transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
		}

		if (Input.GetAxis("Horizontal") != 0){
			animMain.SetBool ("Walk", true);
			animInvisible.SetBool ("Walk", true);
			if (!walkSFX.isPlaying){
				walkSFX.Play();
			}
		} else {
			animMain.SetBool ("Walk", false);
			animInvisible.SetBool ("Walk", false);
			walkSFX.Stop();
		}

		// NOTE: if input is moving the Player right and Player faces left, turn, and vice-versa
		if ((hMove.x >0 && !FaceRight) || (hMove.x <0 && FaceRight)){
			playerTurn();
		}
    }

      void FixedUpdate(){
            //slow down on hills / stops sliding from velocity
            if (hMove.x == 0){
                  rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
            }
      } 

    private void playerTurn(){
        // NOTE: Switch player facing label
        FaceRight = !FaceRight;
			
        // NOTE: Multiply player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
		//turnSFX.Play();
    }
	  
	public void playerMoveModify(float multiplier, bool isNormal){
		if (isNormal == true){
			runSpeed = startSpeed;
			isSpeedChange = false;
			myRend.material.color = defaultColor;
		}
		else {
			runSpeed = (startSpeed * multiplier);
			isSpeedChange = true;
			Debug.Log("Speed is now: " + runSpeed);
			myRend.material.color = new Color(1.0f, 1.0f, 2.5f);
		}
		
	}
	  
}