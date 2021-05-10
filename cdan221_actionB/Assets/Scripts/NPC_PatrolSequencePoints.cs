using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolSequencePoints : MonoBehaviour {

	private Animator animator;
	private GameHandler gameHandler;
	public Rigidbody2D rb;

	public float speed = 10f;
	private float waitTime;
	public float startWaitTime = 2f;
	public int damage = 1;

	public Transform[] moveSpots;
	private int nextSpot; 
	public int startSpot = 0;
	public bool moveForward = true; 
	
	private bool FaceRight = true;
	private bool ableToTurn = true;
	private Vector3 startScale;

	void Start(){
		waitTime = startWaitTime;
		nextSpot = startSpot;
		rb = GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponentInChildren<Animator>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		
		startScale = transform.localScale;
	}

	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
			if (waitTime <= 0){
				if (moveForward == true){nextSpot += 1;}
				else if (moveForward == false){nextSpot -= 1;}
				waitTime = startWaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}
		}

		if (nextSpot == 0) {
			moveForward = true;
			playerTurn();
			
		}
		else if (nextSpot == (moveSpots.Length -1)) {
			moveForward = false;
			playerTurn();
		}
		else {ableToTurn=true;}
		
	}
	
		public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player"){
			gameHandler.playerGetHit(damage);
			animator.SetTrigger ("Attack");
		}
	}
	
	
	
      private void playerTurn(){
            
		if (ableToTurn == true){
			// NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
			ableToTurn = false;
		}
      }
	
	
}