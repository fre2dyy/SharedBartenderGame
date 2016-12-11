using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkController : MonoBehaviour {

	public Dictionary<string, int> DrinkIngredients = new Dictionary<string, int>();

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
		int tmp;
		// Add a shot
		if (this.DrinkIngredients.TryGetValue (Ingredient.name, out tmp))
			this.DrinkIngredients [Ingredient.name] += 2;
		else
			this.DrinkIngredients.Add (Ingredient.name, 2);

		Debug.Log (this.DrinkIngredients[Ingredient.name]);
	}

	/*
	 * Empty Equipment
	 */
	public void EmptyEquipment() {
		this.DrinkIngredients.Clear();
		Debug.Log (this.DrinkIngredients);
	}
}
