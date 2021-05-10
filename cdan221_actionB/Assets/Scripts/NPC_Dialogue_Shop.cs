using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue_Shop : MonoBehaviour
{

	public int primeInt = 0;
	public GameObject dialogueBox;
	public GameObject demonGuide;
    public Text dialogueText;
	private bool dialogueFinished = false;

	public bool startExplain = true;

    void Update(){
		if (startExplain == true){
			dialogueBox.SetActive(true);
			demonGuide.SetActive(true);
		} else if (startExplain == false){
			dialogueBox.SetActive(false);
			demonGuide.SetActive(false);
		}
		
        if (Input.GetKeyDown(KeyCode.Space)){
			talkingNPC();	
		}
    }

    public void talkingNPC(){
		primeInt += 1;
		
		//Dialogue #1: Intro to shop
		if (primeInt == 1){
            dialogueText.text = "Welcome to the shop, demon scum!";
        }

        if (primeInt == 2){
            dialogueText.text = "Here you can purchase abilities to survive the trials ahead.";
        }

        if (primeInt == 3){
            dialogueText.text = "The cheapest ability is invisibility. It costs 10 blood to buy.";
        }

        if (primeInt == 4){
            dialogueText.text = "Once you have an ability, it costs a blood to activate.";
        }

        if (primeInt == 5){
            dialogueText.text = "Blood runs out quickly, so spend wisely!";
        }

        if (primeInt == 6){
            dialogueText.text = "You demon scum.";
        }

        if (primeInt == 7){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "...";
        }
        
		//Dialogue #2: have invisibility
		
		if (primeInt == 10){
            dialogueText.text = "You have purchased Invisibility! You fool!";
        }

        if (primeInt == 11){
            dialogueText.text = "Well, I guess it's not too bad.";
        }

        if (primeInt == 12){
            dialogueText.text = "Spend a blood to be briefly invisible to some monsters.";
        }

        if (primeInt == 13){
            dialogueText.text = "But clumsy demons like yourself will likely run into them anyway.";
        }

        if (primeInt == 14){
            dialogueText.text = "Blood runs out quickly, so spend wisely!";
        }

        if (primeInt == 15){
            dialogueText.text = "You demon scum.";
        }

        if (primeInt == 16){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "...";
        }
		
		
		
		
		
		//Dialogue #3: have speed
		if (primeInt == 20){
            dialogueText.text = "You have purchased Speed! You fool!";
        }

        if (primeInt == 21){
            dialogueText.text = "Well, I guerss it's not too bad.";
        }

        if (primeInt == 22){
            dialogueText.text = "Spend a blood to be briefly speedy.";
        }

        if (primeInt == 23){
            dialogueText.text = "But clumsy demons like yourself will likely run into them anyway.";
        }

        if (primeInt == 24){
            dialogueText.text = "Blood runs out quickly, so spend wisely!";
        }

        if (primeInt == 25){
            dialogueText.text = "You demon scum.";
        }

        if (primeInt == 26){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "...";
        }
		
		
		
		
		
		//Dialogue #4: have defense
		
		if (primeInt == 30){
            dialogueText.text = "You have purchased Defense! You fool!";
        }

        if (primeInt == 31){
            dialogueText.text = "Well, I guess it's not too bad.";
        }

        if (primeInt == 32){
            dialogueText.text = "Spend a blood to be briefly defended to some monsters.";
        }

        if (primeInt == 33){
            dialogueText.text = "But silly demons like yourself will likely forget to use it.";
        }

        if (primeInt == 34){
            dialogueText.text = "Blood runs out quickly, so spend wisely!";
        }

        if (primeInt == 35){
            dialogueText.text = "You demon scum.";
        }

        if (primeInt == 36){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "...";
        }
		
		
		
		//Dialogue #5: you have it all
		if (primeInt == 40){
            dialogueText.text = "You bought eveything.";
        }

        if (primeInt == 41){
            dialogueText.text = "That's it. There's nothing else.";
        }

        if (primeInt == 42){
            dialogueText.text = "Go play the game.";
        }

        if (primeInt == 43){
            dialogueText.text = "Why are you still here?";
        }

        if (primeInt == 44){
            dialogueText.text = "Go.";
        }

        if (primeInt == 45){
            dialogueText.text = "You demon scum.";
        }

        if (primeInt == 46){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "...";
        }
		
		
		
    }
	
	
	
	
	
	
}
