using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public GameObject[] targets;
	public Vector3
		dir;

	public Animator anim;

	public int 
		health,
		maxHealth,
		moveSpeed,
		targetID = 0;

	public bool 
		facingRight,
		dying = false;

	// Use this for initialization
	public void enemyStart () 
	{
		anim = GetComponent<Animator>();
		health = maxHealth;


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
		Invoke("DestroyEnemy", 1);

	}

	void DestroyEnemy()
	{
		GameObject.Find("Canvas").GetComponent<UIController>().score += 100;
		Destroy(this.gameObject);
	}



}
