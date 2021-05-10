using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{
//add this script to an empty GO named CameraShake, camera parented below.
//to have other in0-game interactions cause the shake, comment out the update function below and 
//add this line to the other interation script:     
	
	public float shakeDuration=2f;
	public float shakeMagnitude=2f;
	
	public Vector3 origPos;
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.P)){
			StartCoroutine(ShakeMe(shakeDuration, shakeMagnitude));	
		}
	}
	
	
	
	
	public IEnumerator ShakeMe(float durationTime, float magnitude){
        origPos = transform.localPosition;
		float elapsedTime = 0.0f;
		
		while (elapsedTime < durationTime){
			float shkX = Random.Range(-1f, 1f) * magnitude;
			float shkY = Random.Range(-1f, 1f) * magnitude;		
		
			transform.localPosition = new Vector3((origPos.x + shkX),(origPos.y + shkY),origPos.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = origPos;
    }

}
