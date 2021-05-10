using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrolMoveHit : MonoBehaviour {

	private GameHandler gameHandler;
	private Animator anim;
	private Renderer rend;
	public Rigidbody2D rb;
	private Transform target;

	public int damage = 10;
	public float speed = 4f;
    public float attackRange = 10;	
	

	public LayerMask groundLayers;
	public Transform groundCheck;
	bool isFacingRight = true;
	RaycastHit2D hit;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponentInChildren<Animator>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		
		rend = GetComponentInChildren<Renderer>();

        if (GameObject.FindGameObjectWithTag("Player") != null){
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
	}

    void Update(){
		hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

	private void FixedUpdate(){
		if (hit.collider != false){
			if (isFacingRight){
				rb.velocity = new Vector2(speed, rb.velocity.y);
			} else { 
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			}
		} else {
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
		}
		
		bool isPlayerInvisible = gameHandler.isInvisible;
        float DistToPlayer = Vector3.Distance(transform.position, target.position);

        if ((target != null) && (DistToPlayer <= attackRange) && (isPlayerInvisible==false) && (hit.collider != false)){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
		
	}

	public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            gameHandler.playerGetHit(damage);
            anim.SetTrigger("attack");
            //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
            //StartCoroutine(HitEnemy());
        }
    }

    public void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", false);
        }
    }

	
	
	
	//DISPLAY the range of enemy's attack when selected in the Editor
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
	
	
}
