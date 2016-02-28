using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	public int score = 0;

	GameObject 
		player,
		healthSlider,
		energySlider,
		scoreText;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		healthSlider = GameObject.Find("HealthSlider");
		energySlider = GameObject.Find("EnergySlider");
		scoreText = GameObject.Find("ScoreText");

		healthSlider.GetComponent<Slider>().maxValue = player.GetComponent<CharacterController>().maxHealth;
		energySlider.GetComponent<Slider>().maxValue = player.GetComponent<CharacterController>().maxEnergy;

	}
	
	// Update is called once per frame
	void Update () 
	{
		healthSlider.GetComponent<Slider>().value = player.GetComponent<CharacterController>().health;
		energySlider.GetComponent<Slider>().value = player.GetComponent<CharacterController>().energy;
		scoreText.GetComponent<Text>().text =  score.ToString();
	}
}
