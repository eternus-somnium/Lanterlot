using UnityEngine;
using System.Collections;

public class Zambie : Enemy 
{
	public bool attack = false;

	private Transform myTransform;

	// Use this for initialization
	void Start () 
	{
		enemyStart();
	}

	// Update is called once per frame
	void Update () 
	{    
		enemyUpdate();
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			anim.SetBool ("Attack", true);
		}


	}

	void OnCollisionExit2D(Collision2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			anim.SetBool ("Attack", false);
		}
	}
}
