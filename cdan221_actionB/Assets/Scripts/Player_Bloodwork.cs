using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bloodwork : MonoBehaviour
{
	
	public GameHandler gameHandler;
	public GameObject playerShield;
	public GameObject speedArt;
	public GameObject playerArt;
	public GameObject playerArtInvisible;
	
	public float defendTime = 2f;
	public float invisibleTime = 2f;
	public float speedTime = 2f;
	
    // Start is called before the first frame update
    void Start(){
		if (GameObject.FindWithTag("GameHandler") != null){ 
			gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		}
		playerShield.SetActive(false);
		speedArt.SetActive(false);
		playerArt.SetActive(true);
		playerArtInvisible.SetActive(false);
		
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler.canDefend == true){
			if (Input.GetButtonDown("BloodDefend")){
				StartCoroutine(DefendTimer());
			}
			
		}

		if (gameHandler.canInvisible == true){
			if (Input.GetButtonDown("BloodDefend")){
				StartCoroutine(InvisibleTimer());
			}
			
		}

		if (gameHandler.canSpeed == true){
			if (Input.GetButtonDown("BloodSpeed")){
				StartCoroutine(SpeedTimer());
			}
			
		}
		
		IEnumerator DefendTimer(){
			//turn on defense things
			Debug.Log("I am defending!");
			gameHandler.isDefending = true;
			playerShield.SetActive(true);
			yield return new WaitForSeconds(defendTime);
			
			//turn off defense things
			Debug.Log("I am not defending!");
			gameHandler.isDefending = false;
			playerShield.SetActive(false);
		}
		
		
		IEnumerator InvisibleTimer(){
			//turn on defense things
			Debug.Log("I am invisible!");
			gameHandler.isInvisible = true;
			playerArt.SetActive(false);
			playerArtInvisible.SetActive(true);
			yield return new WaitForSeconds(invisibleTime);
			
			//turn off defense things
			Debug.Log("I am not invisible!");
			gameHandler.isInvisible = false;
			playerArt.SetActive(true);
			playerArtInvisible.SetActive(false);
		}
		
		
		IEnumerator SpeedTimer(){
			//turn on defense things
			Debug.Log("I am speedy!");
			gameHandler.isInvisible = true;
			speedArt.SetActive(true);
			yield return new WaitForSeconds(speedTime);
			
			//turn off defense things
			Debug.Log("I am not speedy!");
			gameHandler.isInvisible = false;
			speedArt.SetActive(false);
		}
		
    }
}
