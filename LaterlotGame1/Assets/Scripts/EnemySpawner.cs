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
		maxCooldown = 1;
	public Vector3 target;

	// Use this for initialization
	void Start () 
	{
		unitsLeft = maxUnits;
		target = new Vector3(-transform.position.x, transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(unitsLeft-- > 0)
			spawnUnits(0);
	}

	void spawnUnits(int i)
	{
		if(cooldown == 0)
		{
			cooldown = maxCooldown;
			GameObject newEnemy = (GameObject)Instantiate(enemies[i], transform.position, Quaternion.identity);
			newEnemy.GetComponent<Enemy>().target = target;
		}
		else
			cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
	}
}
