using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{
//add this script to an empty GO named CameraShake, camera parented below.
//to have other in0-game interactions cause the shake, comment out the update function below and 
//add this line to the other interation script:     
	
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.P)){
		StartCoroutine(ShakeMe(2f, 2f));	
		}
	}
	
	
	
	public IEnumerator ShakeMe(float durationTime, float magnitude){
        Vector3 originalPos = transform.localPosition;
		float elapsedTime = 0.0f;
		
		while (elapsedTime < durationTime){
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;		
		
			transform.localPosition = new Vector3(x,y,originalPos.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = originalPos;
    }

}
