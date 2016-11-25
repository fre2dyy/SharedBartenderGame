using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Class: Drink
 * 
 * This class is a container for the ingredients of a requested drink.
 * It allocates all the ingredients automatically
 * by calling the constructor with the drink name.
 * 
 * @constructorParams: string "Drink"
 */

public class Drink : MonoBehaviour {

	public Dictionary<string, int> Ingredients;
	public string Name;

	Drink(string name) {
		this.Name = name;
		this.SetIngredients ();
	}

	private void SetIngredients() {
		switch(this.Name) {
		case "Beer":
			{
				this.Ingredients = new Dictionary<string, int> () {
					{ "Beer", 1 }
				};
			}
			break;
		case "Cuba Libre":
			{
				this.Ingredients = new Dictionary<string, int> () {
					{ "Cola", 1 },
					{ "Schnapps", 6 }
				};
			}
			break;
		}
	}
}
