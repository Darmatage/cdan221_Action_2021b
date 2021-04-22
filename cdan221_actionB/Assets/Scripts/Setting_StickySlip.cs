using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_StickySlip : MonoBehaviour{
	
	public bool isSlippery = false;
	private float normalSpeed;
	public float slipperyMultiplier = 2f;
	public float stickyMultiplier = 0.5f;

    void Start(){
	   normalSpeed = PlayerMove.runSpeed;
    }

    // Update is called once per frame
    void OnColliderEnter2D(Collision2D other){ 
		if(other.gameObject.tag == "Player"){
			Debug.Log("I hit the player");
			
			if (isSlippery==true){
				Debug.Log("I am slipping!");
				PlayerMove.runSpeed = normalSpeed * slipperyMultiplier;
			}
			else {
				Debug.Log("I am sticking!");
				PlayerMove.runSpeed = normalSpeed * stickyMultiplier;
				
			}
			
			
		} else { 
		PlayerMove.runSpeed = normalSpeed;
		
		} 
    }
	
	void OnColliderExit2D(Collision2D other){ 
		if(other.gameObject.tag == "Player"){
			PlayerMove.runSpeed = normalSpeed;
			Debug.Log("I am moving normally!");
		} 
    }
	
}
