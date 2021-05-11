using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameHandler : MonoBehaviour {

	private GameObject player;
	public static int playerHealth;
	public int StartPlayerHealth = 100;
	public GameObject healthText;

	public static int myBlood = 0;
	public GameObject bloodText;
	
	public static bool gotitem1 = false;
    public static bool gotitem2 = false;
    public static bool gotitem3 = false;

	public bool canInvisible = false;
	public bool canSpeed = false;
	public bool canDefend = false;

    public bool isDefending = false;
	public bool isInvisible = false;
	public bool isSpeedy = false;

	public int costInvis = 1;
	public int costShield = 1;
	public int costSpeed = 1;
	
	public static string SceneDied = "MainMenu";
	
	
	public static int Lives = 5;
    public int maxLives = 5;
    public GameObject lifeHeart1;
    public GameObject lifeHeart2;
    public GameObject lifeHeart3;
    public GameObject lifeHeart4;
    public GameObject lifeHeart5;


	void Start(){
        player = GameObject.FindWithTag("Player");
        playerHealth = StartPlayerHealth;
        updateStatsDisplay();
		
		string thisLevel = SceneManager.GetActiveScene().name;
		if ((thisLevel != "EndLose") && (thisLevel != "SceneWin")){
			SceneDied = thisLevel;
		}
	}


	public void playerGetBlood(int newBlood){
			myBlood += newBlood;
            updateStatsDisplay();
		
	}

	public int CurrentHealth(){
		return playerHealth;
	}


    void Update(){

		if ((myBlood >= costInvis)&&(gotitem1==true)){
			canInvisible = true;}
		else {canInvisible = false;}

		if ((myBlood >= costShield)&&(gotitem2==true)){
			canDefend = true;}
		else {canDefend = false;}

		if ((myBlood >= costSpeed)&&(gotitem3==true)){
			canSpeed = true;}
		else {canSpeed = false;}


        // if (Input.GetKeyDown(KeyCode.P))
        // {
            // if (gameObject.GetComponent<GameInventory>().item1bool == true)
            // {
                // gameObject.GetComponent<GameInventory>().InventoryRemove(item1);
                // player.speedBoost(2f, 5f);
            // }
        // }

    }


	public void playerGetHit(int damage){
          string sceneName = SceneManager.GetActiveScene().name;		  
		  if (isDefending == false){
				  playerHealth -= damage;
				  updateStatsDisplay();
				  player.GetComponent<PlayerHurt>().playerHit();
			}

		   if (playerHealth >= StartPlayerHealth){
				  playerHealth = StartPlayerHealth;
			}

		   if ((playerHealth <= 0) && (sceneName != "EndLose") && (Lives <= 0)){
				  playerHealth = 0;
				  playerDies();
			}
			else if (playerHealth <= 0){ UpdateLives(-1, "down"); }
	}

 public void UpdateLives(int lifeChange, string changeDir){
              Lives += lifeChange;
              if (changeDir == "down"){
                     if (lifeHeart5.activeInHierarchy){lifeHeart5.SetActive(false);}
                     else if (lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(false);}
                     else if (lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(false);}
                     else if (lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(false);}
                     else if (lifeHeart1.activeInHierarchy){lifeHeart1.SetActive(false);}
              } else if (changeDir == "up"){
                     if (!lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(true);}
                     else if (!lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(true);}
                     else if (!lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(true);}
                     else if (!lifeHeart5.activeInHierarchy){lifeHeart5.SetActive(true);}
              }
       }

	public void playerRespawnHealth(){
		  
				  playerHealth = StartPlayerHealth;
				  updateStatsDisplay();
				
			
	}

	public void updateStatsDisplay(){
			Text healthTextTemp = healthText.GetComponent<Text>();
			healthTextTemp.text = "HEALTH: " + playerHealth;

			Text bloodTextTemp = bloodText.GetComponent<Text>();
			bloodTextTemp.text = "BLOODS: " + myBlood;
	  }

	public void playerDies(){
		player.GetComponent<PlayerHurt>().playerDead();
		StartCoroutine(DeathPause());
		SceneManager.LoadScene("EndLose");
	}

	IEnumerator DeathPause(){
		player.GetComponent<PlayerMove>().isAlive = false;
		player.GetComponent<PlayerJump>().isAlive = false;
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("EndLose");
	}

	public void StartGame() {
		SceneManager.LoadScene("Tutorial");
		Lives = maxLives;
		playerHealth = StartPlayerHealth;
	}

	public void ReplayGame(){
		SceneManager.LoadScene(SceneDied);
		Lives = maxLives;	
		playerHealth = StartPlayerHealth;
	}


	public void RestartGame() {
		SceneManager.LoadScene("MainMenu");
		Lives = maxLives;
		playerHealth = StartPlayerHealth;
	}

	public void QuitGame() {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
	}

	public void Credits() {
		SceneManager.LoadScene("Credits");
	}
	
	
}