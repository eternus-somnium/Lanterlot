using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public GameObject[] 
		targets,
		treasures;
	public Vector3 dir;

	public Animator anim;

	public int 
		health,
		maxHealth,
		moveSpeed,
		targetID,
		treasureID;

	public bool 
		facingRight,
		dying = false;

	// Use this for initialization
	public void enemyStart () 
	{
		anim = GetComponent<Animator>();
		health = maxHealth;

		//Set treasure type;
		int i = Random.Range(1,100);
		if(i<76) treasureID = 1;
		else if (i<96) treasureID = 0;
		else treasureID = 2;


	}
	
	// Update is called once per frame
	public void enemyUpdate () 
	{
		if(!dying) 
		{
			moveController();
			if(health <= 0)
			{
				dying = true;
				deathController();
			}
		}
	}

	void moveController()
	{
		Vector3 dir = Vector3.Normalize(targets[targetID].transform.position - transform.position);

		//Switch targets
		if(Vector3.Distance(targets[targetID].transform.position, transform.position) < 3)
			targetID = ++targetID%(targets.Length);


		//Move Towards Target
		transform.position += dir * moveSpeed * Time.deltaTime;

		if(dir.x > 0 && !facingRight || dir.x < 0 && facingRight)
			GetComponent<SpriteRenderer>().flipX = facingRight = !facingRight;
	}

	void deathController()
	{
		//Do stuff
		anim.SetBool("Die",true);
		Instantiate(treasures[treasureID],transform.position,Quaternion.identity);
		Invoke("DestroyEnemy", 1);

	}

	void DestroyEnemy()
	{
		GameObject.Find("Canvas").GetComponent<UIController>().score += 100;
		Destroy(this.gameObject);
	}



}
