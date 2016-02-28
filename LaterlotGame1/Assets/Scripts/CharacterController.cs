using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {


    [HideInInspector]public bool 
		facingRight = true,
		grounded = false,
		charging = false,
		dying = false;

	public int 
		health,
		maxHealth;
		
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

	public GameObject 
		shot;

	private Rigidbody2D playerRigidbody;
    private Animator anim;
	private AudioSource[] playerNoises;

	void Start () 
	{
		health = maxHealth;
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		playerNoises = GetComponents<AudioSource>();
		activeShots[0] = true;
	}
	
	
	void Update () 
	{
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(!dying)
		{
			anim.SetBool("Grounded", grounded);
			anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));


			moveController();
			weaponController();
			if(health <= 0)
			{
				dying = true;
				deathController();
			}
		}
	}

	void jump(float currentJumpPower)
	{
		playerRigidbody.AddForce(Vector2.up * currentJumpPower);
	}

	void moveController()
	{
		float h = Input.GetAxis("Horizontal");

		if (Input.GetButtonDown("Jump") && grounded)
		{
			playerNoises[0].Pause();
			charging = true;
			h = 0;
		}
		else if(Input.GetButtonUp("Jump") && grounded && currentJumpCounter > 0)
		{
			jump(currentJumpCounter * jumpPower);
			currentJumpCounter = 0;
			charging = false;
		}
		else if(charging) 
			currentJumpCounter = Mathf.Min(currentJumpCounter + Time.deltaTime, maxJumpCounter);

		playerNoises[0].Play();
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
			playerNoises[2].Play();
			if(activeShots[3]) playerNoises[3].Play();

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

	void deathController()
	{
		anim.SetBool("Die",true);
	}
		
    void Flip()
    {
        facingRight = !facingRight;
		GetComponent<SpriteRenderer>().flipX = !facingRight;
    }
}
