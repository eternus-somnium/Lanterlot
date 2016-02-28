using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{

	public float speed;
	public int damage;
	public bool 
		destroyOnContact = true;
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		if(Vector2.Distance(gameObject.transform.position, player.transform.position) > 20)
			Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if((gameObject.layer == 9 || gameObject.layer == 10) && c.gameObject.tag == "Enemy")
			c.gameObject.GetComponent<Enemy>().health -= damage;
		else if(gameObject.layer == 12 && c.gameObject.tag == "Player")
			c.gameObject.GetComponent<CharacterController>().health -= damage;
		
		if(destroyOnContact) Destroy(this.gameObject);
	}
}
