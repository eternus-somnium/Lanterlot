using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {


    [HideInInspector]public bool 
		facingRight = true,
		grounded = false;
		
    public float 
		maxspeed = 3,
		speed = 50f,
		currentJumpCounter = 0,
		maxJumpCounter = 1,
		jumpPower = 150f,
		aimSensitivity,
		cooldown = 0,
		maxCooldown = .05f;

	public bool[] activeShots;
	public GameObject[] shots;

    public Transform groundCheck;

	public GameObject shot;

	private Rigidbody2D playerRigidbody;
    private Animator anim;

	void Start () {

        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
		activeShots[0] = true;

	}
	
	
	void Update () 
	{

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

	}


    void FixedUpdate()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));


		moveController();
		weaponController();

    }

	void jump(float currentJumpPower)
	{
		playerRigidbody.AddForce(Vector2.up * currentJumpPower);
	}

	void moveController()
	{
		float h = Input.GetAxis("Horizontal");

		if (Input.GetButton("Jump") && grounded && currentJumpCounter < maxJumpCounter)
		{
			currentJumpCounter += Time.deltaTime;
			h = 0;
		}
		else if(grounded && currentJumpCounter > 0)
		{
			jump(currentJumpCounter * jumpPower);
			currentJumpCounter = 0;
		}

		if (h * playerRigidbody.velocity.x < maxspeed)
			playerRigidbody.AddForce(Vector2.right * h * speed);

		if (Mathf.Abs(playerRigidbody.velocity.x) > maxspeed)
			playerRigidbody.velocity = new Vector2(Mathf.Sign(playerRigidbody.velocity.x) * maxspeed, playerRigidbody.velocity.y);

		if (h > 0 && !facingRight || h < 0 && facingRight)
			Flip();
	}

	void weaponController()
	{
		int i;
		GameObject lanternCircle = GameObject.Find("Lantern Circle");
		lanternCircle.transform.Rotate(new Vector3(0,0,Input.GetAxis("Mouse X")*aimSensitivity));
		GameObject lantern = GameObject.Find("Lantern");
		lantern.transform.rotation = Quaternion.identity;

		if(Input.GetAxis("Fire1") != 0 && cooldown == 0)
		{
			cooldown = maxCooldown;
			for(i=0;i<activeShots.Length;i++)
			{
				if(activeShots[i])
					Instantiate(shots[i], lantern.transform.position, Quaternion.Inverse(lanternCircle.transform.rotation));
			}
		}
		else
			cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
	}
		
    void Flip()
    {
        facingRight = !facingRight;
		GetComponent<SpriteRenderer>().flipX = !facingRight;
    }
}
