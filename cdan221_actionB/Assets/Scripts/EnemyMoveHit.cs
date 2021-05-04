using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveHit : MonoBehaviour
{

    public Animator anim;
    public float speed = 4f;
    private Transform target;
    public int damage = 10;
    private bool FaceRight = true; // determine which way player is facing.
    public bool isAlive = true;

    public int EnemyLives = 3;
    private Renderer rend;
    private GameHandler gameHandler;

    public float attackRange = 10;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void Update(){
		
		bool isPlayerInvisible = gameHandler.isInvisible;
		
        float DistToPlayer = Vector3.Distance(transform.position, target.position);

        if ((target != null) && (DistToPlayer <= attackRange) && (isPlayerInvisible==false))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
        Vector3 hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (isAlive == true)
        {

            // NOTE: if input is moving the Player right and Player faces left, turn, and vice-versa
            if ((hMove.x > 0 && !FaceRight) || (hMove.x < 0 && FaceRight))
            {
                Enemyturn();
            }
        }
    }



   public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            gameHandler.playerGetHit(damage);
            anim.SetTrigger("attack");
            //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
            //StartCoroutine(HitEnemy());
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", false);
        }
    }

    private void Enemyturn()
    {
        // NOTE: Switch player facing label
        FaceRight = !FaceRight;

        // NOTE: Multiply player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator HitEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        rend.material.color = Color.white;
    }

    //DISPLAY the range of enemy's attack when selected in the Editor

    void OnDrawGizmosSelected()

    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

} 
