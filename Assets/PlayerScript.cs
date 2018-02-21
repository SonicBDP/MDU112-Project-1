using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	//Variables
	public int PlayerLVL;			//Player Stats
	public int PlayerXP;
	public int PlayerXPRequired;
	public int PlayerMaxHP;
	public int PlayerStrength;
	public int PlayerAgility;
	public bool ItemCollected;

	void Start () {													
	//Setting variables
		PlayerLVL = 5;												// Player's level
		PlayerXP = 0;												// Player's current XP
		PlayerXPRequired = GetXPRequired(PlayerLVL);				// Player's XP required to reach the next level
		PlayerMaxHP = 10;											// Player stat relating to maximum HP
		PlayerStrength = 10;										// Player stat relating to strength
		PlayerAgility = 10;											// Player stat relating to agility
		ItemCollected = false;										// Whether the player has collected an item
	
	//Running start-up functions

	
	//Debug text
		Debug.Log ("Player's level is: " + PlayerLVL);
		Debug.Log ("XP to next level is: " + PlayerXPRequired);
		Debug.Log ("The stat being boosted on item pickup is: " + StatOnPickup());
		Debug.Log ("The chance to boost a stat is: " + BoostChance());
		Debug.Log ("Player Max HP: " + PlayerMaxHP + " Player Strength: " + PlayerStrength + " Player Agility: " + PlayerAgility);
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.E)) 			//If the E key is pressed then it runs the functions
		{
			ItemCollect ();
			BoostFromItem ();							//Calls the function that boost stats depending on item pickups
			ItemCollected = false;
		}

	}

	//Functions relating to experience
	int GetXPRequired (int PlayerLVL)				//Finds how much experience the player needs to level up
	{
		if (PlayerLVL >= 1 && PlayerLVL <6)			//if the player's level is between 1 and 5, the xp multiplier is *3
		{
			int x = (PlayerLVL * 3);
			return x;								
		}
		else 										//if the player's level is higher than 5, the xp multiplier is *5
		{
			int x = (PlayerLVL * 5);
			return x; 								
		}

	}

	////Functions relating to item pickups

	void ItemCollect ()							//Randomises whether the player has picked up an item
	{
		ItemCollected = true;
	}

	void BoostFromItem()								//If an item has been collected, and it is an apple, then boost the appropriate stat.
	{
		if (ItemCollected == true)						//If the item has been picked up
		{
			if (ItemPickup () == 1) 					//And the pickup is an apple
			{						
				Debug.Log ("You picked up an apple");
				if (StatOnPickup () == 1) 				//And the stat to boost upon pickup is an the player's HP
				{				
					BoostHP ();							//Run the BoostHP function
				} 
				else if (StatOnPickup () == 2) 
				{										//If the stat to boost upon pickup is strength
					BoostStrength ();					//Run the BoostStrength function
				} 
				else 
				{										//If the stat to boost upon pickup is agility
					BoostAgility ();					//Run the BoostAgility function
				}
			} 
			else if (ItemPickup() == 2)
			{
				Debug.Log ("You picked up a donut");
			}
			else
			{
				Debug.Log ("You picked up a cake");
			}
		}
	}


	public int ItemPickup ()								//Randomises an item that the player has picked up. 1 = Apple, 2 = Donut, 3 = Cake
	{
		int x = Random.Range (1, 3);
		return x;
	}

	public int StatOnPickup ()								//Randomises a player's stat boost. 1 = HP, 2 = Strength, 3 = Agility
	{
		int x = Random.Range (1, 3);
		return x;
	}

	public int BoostChance () 								//Generates chance to boost a stat
	{
		int x = (Random.Range (1, 100) + PlayerLVL);
		return x;
	}


	////Stat-boosting functions

	void BoostHP ()									//Increases the player's max HP
	{
		PlayerMaxHP += 1;
		Debug.Log ("Your HP has been increased to " + PlayerMaxHP);
	}

	void BoostStrength ()							//Increases the player's strength
	{
		PlayerStrength += 1;
		Debug.Log ("Your Strength has been increased to " + PlayerStrength);
	}

	void BoostAgility ()							//Increases the player's agility
	{
		PlayerAgility += 1;
		Debug.Log ("Your Agility has been increased" + PlayerAgility);
	}

}

	