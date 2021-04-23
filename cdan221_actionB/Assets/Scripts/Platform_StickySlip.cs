using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_StickySlip : MonoBehaviour{
	
	private PlayerMove pMove;
	public bool isSlippery = false;
	//private float normalSpeed;
	public float slipperyMultiplier = 10f;
	public float stickyMultiplier = 0.2f;

    void Start(){
		pMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
	   //normalSpeed = PlayerMove.runSpeed;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other){ 
		if(other.gameObject.tag == "Player"){
			if (isSlippery==true){
				Debug.Log("I am a slippery platform");
				//PlayerMove.runSpeed = normalSpeed * slipperyMultiplier;
				pMove.playerMoveModify(slipperyMultiplier, false);
			}
			else {
				Debug.Log("I am a sticky platform");
				//PlayerMove.runSpeed = normalSpeed * stickyMultiplier;
				pMove.playerMoveModify(stickyMultiplier, false);
			}
		}
    }
	
	void OnCollisionExit2D(Collision2D other){ 
		if(other.gameObject.tag == "Player"){
			//PlayerMove.runSpeed = normalSpeed;
			pMove.playerMoveModify(0, true);
			Debug.Log("I am moving normally!");
		} 
    }
	
}
