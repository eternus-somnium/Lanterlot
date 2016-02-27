using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public Vector3 target;

	public int 
	health,
	maxHealth;

	// Use this for initialization
	void Start () 
	{
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
