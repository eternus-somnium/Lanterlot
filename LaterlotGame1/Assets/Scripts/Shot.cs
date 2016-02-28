using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{

	public float speed;
	public bool destroyOnContact = true;
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
			Destroy(this.transform.root.gameObject);
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag == "Enemy")
			c.gameObject.GetComponent<Enemy>().health--;
		if(destroyOnContact) Destroy(this.transform.root.gameObject);
	}
}
