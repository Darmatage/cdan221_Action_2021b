using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameHandler gameHandler;
    public Transform pSpawn;       // current player spawn point

    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){
               gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void Update()
    {
        if (pSpawn != null)
        {
            if ((gameHandler.CurrentHealth() <= 0) && (GameHandler.Lives > 0))
            {
                //comment out lines from GameHandler abotu EndLose screen
                Debug.Log("I am going back to the last spawn point. Lives = " + GameHandler.Lives);
                Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, transform.position.z);
                gameObject.transform.position = pSpn2;
				gameHandler.playerRespawnHealth();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            pSpawn = other.gameObject.transform;
            GameObject thisCheckpoint = other.gameObject;
            StopCoroutine(changeColor(other.gameObject));
            StartCoroutine(changeColor(other.gameObject));
        }
    }

    IEnumerator changeColor(GameObject thisCheckpoint)
    {
        Renderer checkRend = thisCheckpoint.GetComponentInChildren<Renderer>();
        checkRend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        checkRend.material.color = Color.white;
    }
}