using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Rotate(new Vector3(0,0,Time.deltaTime * 360));
		gameObject.transform.localScale += new Vector3(Time.deltaTime *10, Time.deltaTime *10, 0);
		if(transform.localScale.x > 40)
			Destroy(this.gameObject);
	}
}
