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
	
	public float defendTime = 5f;
	public float invisibleTime = 5f;
	public float speedTime = 5f;
	
	private int costInvis;
	private int costShield;
	private int costSpeed;
	
	
    // Start is called before the first frame update
    void Start(){
		if (GameObject.FindWithTag("GameHandler") != null){ 
			gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		}
		playerShield.SetActive(false);
		speedArt.SetActive(false);
		playerArt.SetActive(true);
		playerArtInvisible.SetActive(false);
		
		costInvis = gameHandler.costInvis;
		costShield = gameHandler.costShield;
		costSpeed = gameHandler.costSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler.canDefend == true){
			if (Input.GetButtonDown("BloodShield")){
				StartCoroutine(DefendTimer());
				gameHandler.playerGetBlood(costShield * -1);
			}
			
		}

		if (gameHandler.canInvisible == true){
			if (Input.GetButtonDown("BloodInvis")){
				StartCoroutine(InvisibleTimer());
				gameHandler.playerGetBlood(costInvis * -1);
			}
			
		}

		if (gameHandler.canSpeed == true){
			if (Input.GetButtonDown("BloodSpeed")){
				StartCoroutine(SpeedTimer());
				gameHandler.playerGetBlood(costSpeed * -1);
			}
			
		}
		
		IEnumerator DefendTimer(){
			//turn on defense things
			//Debug.Log("I am defending!");
			gameHandler.isDefending = true;
			playerShield.SetActive(true);
			yield return new WaitForSeconds(defendTime);
			
			//turn off defense things
			//Debug.Log("I am not defending!");
			gameHandler.isDefending = false;
			playerShield.SetActive(false);
		}
		
		
		IEnumerator InvisibleTimer(){
			//turn on defense things
			//Debug.Log("I am invisible!");
			gameHandler.isInvisible = true;
			playerArt.SetActive(false);
			playerArtInvisible.SetActive(true);
			yield return new WaitForSeconds(invisibleTime);
			
			//turn off defense things
			//Debug.Log("I am not invisible!");
			gameHandler.isInvisible = false;
			playerArt.SetActive(true);
			playerArtInvisible.SetActive(false);
		}
		
		
		IEnumerator SpeedTimer(){
			//turn on defense things
			//Debug.Log("I am speedy!");
			gameHandler.isSpeedy = true;
			gameObject.GetComponent<PlayerMove>().isSpeedBoost = true;
			speedArt.SetActive(true);
			yield return new WaitForSeconds(speedTime);
			
			//turn off defense things
			//Debug.Log("I am not speedy!");
			gameHandler.isSpeedy = false;
			gameObject.GetComponent<PlayerMove>().isSpeedBoost = false;
			speedArt.SetActive(false);
		}
		
    }
}
