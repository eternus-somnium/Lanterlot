using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour 
{
	public int type;
	public float duration = 5;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		duration -= Time.deltaTime;
		if(duration <= 0) Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag == "Player")
		{
			CharacterController p = c.gameObject.GetComponent<CharacterController>();
			switch(type)
			{
			case 0: //Health treasure
				p.health = Mathf.Min(p.maxHealth,p.health+20);
				break;
			case 1: //Power treasure
				p.energy = Mathf.Min(p.maxEnergy,p.energy+1);
				break;
			case 2: //Bomb treasure
				p.bombs = Mathf.Min(p.maxBombs, p.bombs+1);
				break;
			}
			Destroy(gameObject);
		}
	}
}
