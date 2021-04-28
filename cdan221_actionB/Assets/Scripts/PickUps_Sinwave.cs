using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUps_Sinwave : MonoBehaviour{

	//initial values, can be made public
	private Vector3 startPos;
	
	private float speedUpDown = 1.5f;
	private float distUpDown = 0.5f;

	//extra parameters for randomizing movement
	private float randBottom = 0.6f;
	private float randTop = 1f;

	private bool SinWaveMove = true;
	private bool randomizeSin = true;

    void Start(){
		//randomize a little
		startPos = transform.position;
		
		//randomize distance
		if (randomizeSin==true){
			speedUpDown = (speedUpDown * Random.Range(randBottom, randTop));
		}
    }

	void Update (){
		//use Mathf.Sin function to move up and down
		if (SinWaveMove == true){
			transform.position = startPos + new Vector3(0.0f, (Mathf.Sin(Time.time * speedUpDown) * distUpDown), 0.0f);
		}
     }

}