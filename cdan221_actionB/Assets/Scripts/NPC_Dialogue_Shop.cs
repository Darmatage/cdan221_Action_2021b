using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue_Shop : MonoBehaviour
{

	public int primeInt = 0;
	public GameObject dialogueBox;
	public GameObject sallyWelcome;
	public GameObject sallyExplain;
	public GameObject sallyDone;
    public Text dialogueText;
	private bool dialogueFinished = false;

	public bool startExplain = true;

	void Start(){
		sallyWelcome.SetActive(true);
		sallyExplain.SetActive(false);
		sallyDone.SetActive(false);
	}

    void Update(){
		if (startExplain == true){
			dialogueBox.SetActive(true);
		} else if (startExplain == false){
			dialogueBox.SetActive(false);
		}
		
        if (Input.GetKeyDown(KeyCode.Space)){
			talkingNPC();	
		}
    }

    public void talkingNPC(){
		primeInt += 1;
		
		//Dialogue #1: Intro to shop
		if (primeInt == 1){
		sallyWelcome.SetActive(true);
		sallyExplain.SetActive(false);
		sallyDone.SetActive(false);
            dialogueText.text = "Honestly, it took you long enough to figure out how to get here, but whatever.";
        }

        if (primeInt == 2){
            dialogueText.text = "This is my shop, where you can come and buy useful tomes for your quest.";
        }

        if (primeInt == 3){
            dialogueText.text = "Since you're a minor demon,";
        }
		
		if (primeInt == 4){
			dialogueText.text = "I can only offer you three at the moment.";
		}

        if (primeInt == 5){
            dialogueText.text = "But, they'll be useful to you in the long run.";
        }

        if (primeInt == 6){
            dialogueText.text = "Blood runs out quickly and I'm not going to give you anything for free.";
        }

        if (primeInt == 7){
            dialogueText.text = "Even in Hell you gotta work for what you want.";
        }

        if (primeInt == 8){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = ". . .";
        }
        
		//Dialogue #2: have invisibility
		
		if (primeInt == 10){
		sallyWelcome.SetActive(false);
		sallyExplain.SetActive(true);
		sallyDone.SetActive(false);
            dialogueText.text = "So, the haples soul decided to spend their blood on an invisiblity tome.";
        }

        if (primeInt == 11){
            dialogueText.text = "Well, I guess that isn't too bad.";
        }

        if (primeInt == 12){
            dialogueText.text = "With invisiblity, you can briefly become invisible to some monsters when you press 1.";
        }

        if (primeInt == 13){
            dialogueText.text = "Allowing for a rather easy escape and to the next platform.";
        }

        if (primeInt == 14){
            dialogueText.text = "But, with clumbsy souls like you, you'll probably end up getting caught by them anyways.";
        }

        if (primeInt == 15){
		sallyWelcome.SetActive(true);
		sallyExplain.SetActive(false);
            dialogueText.text = "Also, no refunds if you do happen to get caught. That's not my problem.";
        }

        if (primeInt == 16){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "Oh-ho-ho!";
        }
		
		
		
		
		
		//Dialogue #3: have speed
		if (primeInt == 20){
		sallyWelcome.SetActive(false);
		sallyExplain.SetActive(true);
		sallyDone.SetActive(false);
            dialogueText.text = "So you decided to give yourself a boost and purchased a Speed tome.";
        }

        if (primeInt == 21){
            dialogueText.text = "Well, I guess it's a pretty smart buy.";
        }

        if (primeInt == 22){
            dialogueText.text = "Some monsters here are really quick and can catch you easily.";
        }
		
		if (primeInt == 23){
            dialogueText.text = "So, a speed tome will allow you to speed up and avoid those monsters.";
        }

        if (primeInt == 24){
            dialogueText.text = "You can activate this tome buy pressing 2.";
        }

        if (primeInt == 25){
            dialogueText.text = "That still won't help you if your dumb enough to happen to run into them.";
        }

        if (primeInt == 26){
		sallyWelcome.SetActive(true);
		sallyExplain.SetActive(false);
            dialogueText.text = "So, don't come demanding your blood back when you accidentally rocket into one.";
        }

        if (primeInt == 27){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "Funny!";
        }
		
		
		
		
		
		//Dialogue #4: have defense
		
		if (primeInt == 30){
		sallyWelcome.SetActive(false);
		sallyExplain.SetActive(true);
		sallyDone.SetActive(false);
            dialogueText.text = "So you've decided on defense.";
        }

        if (primeInt == 31){
            dialogueText.text = "Guess that's kinda a smart move, in my opinion.";
        }

        if (primeInt == 32){
            dialogueText.text = "Some monsters are tough and deal a lot of damage to you.";
        }

        if (primeInt == 33){
            dialogueText.text = "So a defense tome will briefly allow you to keep from getting injured.";
        }
		
		if (primeInt == 34){
            dialogueText.text = "And you activate it by pressing 3.";
        }

        if (primeInt == 35){
            dialogueText.text = "Though, it's also my most expensive tome that I have.";
        }
		
		if (primeInt == 36){
            dialogueText.text = "So even if you're able to avoid a couple of monsters' hits,";
        }
		
		if (primeInt == 37){
            dialogueText.text = "You've probably been smacked around by a dozen beforehand.";
        }

        if (primeInt == 38){
		sallyWelcome.SetActive(true);
		sallyExplain.SetActive(false);
            dialogueText.text = "Honestly, that's just hilarious to think about.";
        }

        if (primeInt == 39){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "Interesting.";
        }
		
		
		
		//Dialogue #5: you have it all
		if (primeInt == 40){
		sallyWelcome.SetActive(false);
		sallyExplain.SetActive(false);
		sallyDone.SetActive(true);
            dialogueText.text = "You bought everything out.";
        }

        if (primeInt == 41){
            dialogueText.text = "Well, good for you, I guess.";
        }

        sallyExplain.SetActive(true);
        sallyDone.SetActive(false);
        if (primeInt == 42){
            dialogueText.text = "What? Did you expect me to congradulate you on buying everything?";
        }

        if (primeInt == 43){
            dialogueText.text = "I don't care, that's just more blood in my pocket to spend.";
        }

        if (primeInt == 44){
            dialogueText.text = "Why are you still here? I have nothing else for you.";
        }

        sallyWelcome.SetActive(true);
        sallyExplain.SetActive(false);
        sallyDone.SetActive(false);
        if (primeInt == 45){
            dialogueText.text = "Go run along and play your game or something.";
        }

        if (primeInt == 46){
            startExplain = false;
			dialogueFinished = true;
			dialogueText.text = "Oh, wow.";
        }
		
		
		
    }
	
	
	
	
	
	
}
