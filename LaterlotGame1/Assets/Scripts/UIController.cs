using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	public int score = 0;
	GameObject 
		player,
		healthSlider,
	scoreText;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		healthSlider = GameObject.Find("HealthSlider");
		scoreText = GameObject.Find("ScoreText");

		healthSlider.GetComponent<Slider>().maxValue = player.GetComponent<CharacterController>().maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthSlider.GetComponent<Slider>().value = player.GetComponent<CharacterController>().health;
		scoreText.GetComponent<Text>().text =  score.ToString();
	}
}
