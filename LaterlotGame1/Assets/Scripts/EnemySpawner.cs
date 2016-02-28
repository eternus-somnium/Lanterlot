using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject[] enemies;
	public int 
		unitsLeft,
		maxUnits;
	public float
		cooldown = 0,
		maxCooldown = 1,
		bounceHeight;
	public bool bounce;
	public GameObject[] targets;
	public Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		unitsLeft = maxUnits;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(unitsLeft > 0)
		{
			spawnUnits(0);
		}

		if(bounce)
			transform.position = startPosition + Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad) * bounceHeight;
		Debug.Log(Mathf.Sin(Time.timeSinceLevelLoad));
	}

	void spawnUnits(int i)
	{
		if(cooldown == 0)
		{
			unitsLeft--;
			cooldown = maxCooldown;
			GameObject newEnemy = (GameObject)Instantiate(enemies[i], transform.position, Quaternion.identity);
			newEnemy.GetComponent<Enemy>().targets = targets;
		}
		else
			cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
	}
}
