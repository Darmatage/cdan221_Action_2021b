using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public Animator anim;
    public GameObject dialogueBox;
    public Text dialogueText;
    public bool playerInRange = false;
    public int primeInt = -1;
    public string dialogue0;
    public string dialogue1;
    public string dialogue2;
    public string dialogue3;
    public string dialogue4;
    public string dialogue5;

    void Start()
    {
        dialogueBox.SetActive(false);
        anim.SetBool("Chat", false);
       }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        { //can change the key to
            if (dialogueBox.activeInHierarchy)
            {
                //dialogueBox.SetActive(false);
                //anim.SetBool("Chat", false);

            }
            else
            {
                NPCdialogue();
                dialogueBox.SetActive(true);
                //anim.SetBool("Chat", true);
            }
        }
    }

    public void NPCdialogue()
    {
        primeInt += 1;

        if (primeInt == 1)
        {
            dialogueText.text = dialogue1;
        }

        if (primeInt == 2)
        {
            dialogueText.text = dialogue2;
        }

        if (primeInt == 3)
        {
            dialogueText.text = dialogue3;
        }

        if (primeInt == 4)
        {
            dialogueText.text = dialogue4;
        }

        if (primeInt == 5)
        {
            dialogueText.text = dialogue5;
        }

        if (primeInt == 6)
        {
            dialogueBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            primeInt = -1;
            //Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
            //Debug.Log("Player left range");
        }
    }
}