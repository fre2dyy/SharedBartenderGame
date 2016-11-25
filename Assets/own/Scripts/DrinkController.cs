using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkController : MonoBehaviour {

	public Dictionary<string, int> Drink = new Dictionary<string, int>();

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
		if (this.Drink.TryGetValue (Ingredient.name, out tmp))
			this.Drink [Ingredient.name] += 2;
		else
			this.Drink.Add (Ingredient.name, 2);

		Debug.Log (this.Drink[Ingredient.name]);
	}
}
