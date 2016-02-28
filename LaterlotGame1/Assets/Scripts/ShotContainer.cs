using UnityEngine;
using System.Collections;

public class ShotContainer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GetComponentsInChildren<Transform>().Length == 1)
			Destroy(gameObject);
	}
}
