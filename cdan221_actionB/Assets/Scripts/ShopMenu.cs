using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ShopMenu : MonoBehaviour{

      public GameHandler gameHandler;
	  public NPC_Dialogue_Shop shopScript;
      public static bool ShopisOpen = false;
      public GameObject shopMenuUI;
      public GameObject buttonOpenShop;

	  public GameObject haveInvisibilityIcon;
	  public GameObject haveSpeedIcon;
	  public GameObject haveShieldIcon;

      public GameObject item1BuyButton;
      public GameObject item2BuyButton;
      public GameObject item3BuyButton;

      public int item1Cost = 3;
      public int item2Cost = 4;
      public int item3Cost = 5;
      public AudioSource KaChingSFX;

	void Awake(){
		if (GameObject.FindWithTag("ShopExplain") != null){
			shopScript = GameObject.FindWithTag("ShopExplain").GetComponent<NPC_Dialogue_Shop>();
		}
	}

      void Start (){
            shopMenuUI.SetActive(false);
			haveInvisibilityIcon.SetActive(false);
			haveShieldIcon.SetActive(false);
			haveSpeedIcon.SetActive(false);
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

      void Update (){
            if ((GameHandler.myBlood >= item1Cost) && (GameHandler.gotitem1 == false)) {
                        item1BuyButton.SetActive(true);}
            else { item1BuyButton.SetActive(false);}

            if ((GameHandler.myBlood >= item2Cost) && (GameHandler.gotitem2 == false)) {
                        item2BuyButton.SetActive(true);}
            else { item2BuyButton.SetActive(false);}

            if ((GameHandler.myBlood >= item3Cost) && (GameHandler.gotitem3 == false)) {
                        item3BuyButton.SetActive(true);}
            else { item3BuyButton.SetActive(false);}
      }

      //Button Functions:
      public void Button_OpenShop(){
           shopMenuUI.SetActive(true);
           buttonOpenShop.SetActive(false);
           ShopisOpen = true;
           Time.timeScale = 0f;
		   shopScript.startExplain = true; 
		   if ((GameHandler.gotitem1 == true)&& (GameHandler.gotitem2 == true) && (GameHandler.gotitem3 == true)){
				shopScript.primeInt = 39;
		   } else {shopScript.primeInt = 0;}
      }

      public void Button_CloseShop() {
           shopMenuUI.SetActive(false);
           buttonOpenShop.SetActive(true);
           ShopisOpen = false;
           Time.timeScale = 1f;
      }

      public void Button_BuyItem1(){
            gameHandler.playerGetBlood((item1Cost * -1));
            GameHandler.gotitem1 = true;
			haveInvisibilityIcon.SetActive(true);
            KaChingSFX.Play();
			shopScript.startExplain = true; 
			shopScript.primeInt = 9;
      }

      public void Button_BuyItem2(){
            gameHandler.playerGetBlood((item2Cost * -1));
            GameHandler.gotitem2 = true;
			haveShieldIcon.SetActive(true);
            KaChingSFX.Play();
			shopScript.startExplain = true; 
			shopScript.primeInt = 19;
      }

      public void Button_BuyItem3(){
            gameHandler.playerGetBlood((item3Cost * -1));
            GameHandler.gotitem3 = true;
			haveSpeedIcon.SetActive(true);
            KaChingSFX.Play();
			shopScript.startExplain = true; 
			shopScript.primeInt = 29;
      }
}