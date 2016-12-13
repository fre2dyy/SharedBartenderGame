using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkController : MonoBehaviour {

	public Dictionary<string, decimal> DrinkIngredients = new Dictionary<string, decimal>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * Adds ingredients to Equipment objects
	 */
	private void AddIngredient(Transform Ingredient) {
		decimal tmp;
		// Add a shot
		if (this.DrinkIngredients.TryGetValue (Ingredient.name, out tmp))
			this.DrinkIngredients [Ingredient.name] += 20;
		else
			this.DrinkIngredients.Add (Ingredient.name, 20);

		Debug.Log ("In Shaker:" + this.DrinkIngredients [Ingredient.name]);
	}

	/*
	 * Empty Equipment
	 */
	public void EmptyEquipment() {
		this.DrinkIngredients.Clear();
		Debug.Log (this.DrinkIngredients);
	}
}
