using UnityEngine;
using System.Collections;

public class enemyAi : MonoBehaviour {
	
		
		
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public bool attack = false;

	private Transform myTransform;

	Animator anim;



	// Use this for initialization
	void Awake() {
		myTransform = transform;
		anim = GetComponent<Animator> ();
	}
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {    
		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f; // Only needed if objects don't share 'z' value

		
		//Move Towards Target
		myTransform.position += Vector3.left * moveSpeed * Time.deltaTime;

	
		}
	void OnCollisionEnter2D(Collision2D c){

		if (c.gameObject.tag == "Player") {
			anim.SetBool ("Attack", true);
		}


	}
	void OnCollisionExit2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			anim.SetBool ("Attack", false);
		}
	}
}
