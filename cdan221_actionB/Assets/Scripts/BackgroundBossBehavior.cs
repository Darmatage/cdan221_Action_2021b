using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBossBehavior : MonoBehaviour
{
	private Animator anim;
	private Vector3 startScale;
	public float scaleTimeMult = 2f;
	public float pauseTime = 5f;
	public float pauseTimer = 0f;
	public bool isScalingUp = false;
	public bool isScalingDown = false;
	public bool goingBig = true;
	
	public Vector3 BigScale = new Vector3(50,50,1);
	public Vector3 SmallScale = new Vector3(1,1,1);
	public Vector3 BigScaleNeg = new Vector3(-50,50,1);
	public Vector3 SmallScaleNeg = new Vector3(-1,1,1);
	
	private CameraShake camShake;
	private bool canShakeMe = true; 
	
    // Start is called before the first frame update
    void Start(){
        startScale = transform.localScale;
		transform.localScale = SmallScale;
		anim = gameObject.GetComponentInChildren<Animator>();
		camShake = GameObject.FindWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if ((isScalingUp == false) && (isScalingDown == false)){
			pauseTimer += 0.01f;
			anim.SetBool("Walk", false);
		}
		
		if (pauseTimer >= pauseTime){
			pauseTimer = 0;
			if ((goingBig == true) && (isScalingUp == false)){
				isScalingUp = true;
				anim.SetBool("Walk", true);
				//transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale * 100f, Time.deltaTime * 200f);
				StartCoroutine(ScaleUpTheBeast());
			}
			else if ((goingBig == false) && (isScalingDown == false)){
				isScalingDown = true;
				anim.SetBool("Walk", true);
				//transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale / 100f, Time.deltaTime * 200f);
				StartCoroutine(ScaleDownTheBeast());
			}
		}
		
		if ((transform.localScale == BigScale)&&(canShakeMe==true)){
			canShakeMe = false;
			StartCoroutine(camShake.ShakeMe(1.5f, 0.3f));
		} else if ((transform.localScale == SmallScale)&&(canShakeMe==false)){
			canShakeMe = true;
		}
		
    }
	

     IEnumerator ScaleUpTheBeast(){
        float progress = 0;
         
        while(progress <= 1){
             transform.localScale = Vector3.Lerp(SmallScale, BigScale, progress);
             progress += Time.deltaTime * scaleTimeMult;
			 //anim.SetBool("Walk", true);
             yield return null;
        }
        transform.localScale = BigScale;
		goingBig = false;
		isScalingUp = false;
     } 
	 
	IEnumerator ScaleDownTheBeast(){
        float progress = 0;
         
        while(progress <= 1){
             transform.localScale = Vector3.Lerp(BigScaleNeg, SmallScaleNeg, progress);
             progress += Time.deltaTime * scaleTimeMult;
			 //anim.SetBool("Walk", true);
             yield return null;
        }
        transform.localScale = SmallScale;
		goingBig = true;
		isScalingDown = false;
     }
	 
	 
}