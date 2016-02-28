using UnityEngine;
using System.Collections;

public class Ghost : Enemy 
{
	public float
		cooldown,
		maxCooldown;

	public GameObject ghostShot;

	// Use this for initialization
	void Start () 
	{
		enemyStart();

	}

	// Update is called once per frame
	void Update () 
	{    
		enemyUpdate();
		attackController();
	}

	void attackController()
	{
		Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
		//Debug.DrawRay(transform.position, playerPosition - transform.position);

		if(cooldown == 0)
		{
			cooldown = maxCooldown;
			GameObject shot = 
				(GameObject)Instantiate(
					ghostShot, 
					transform.position, 
					Quaternion.identity);
			shot.transform.LookAt(playerPosition);
			shot.transform.Rotate(0,-90,0);
		}
		else
			cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
	}
}
