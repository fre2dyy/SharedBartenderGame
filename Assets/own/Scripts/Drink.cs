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

	public string Name;
	public Dictionary<string, int> Ingredients;
	private static Dictionary<string, Dictionary<string, int>> drinkList = new Dictionary<string, Dictionary<string, int>>() {
		{"Beer", new Dictionary<string, int> {{"Beer"}, 1}},
		{"Cola", new Dictionary<string, int> {{"Cola"}, 1}},
		{"Diesel", new Dictionary<string, int> {{"Bier", 1}, {"Cola", 1}}},,
		{"Cuba Libre", new Dictionary<string, int> {{"Cola", 1}, {"Schnapps", 6}}}
	};

	Drink(string name) {
		this.Name = name;
		this.SetIngredients ();
	}

	private void SetIngredients() {
		switch(this.Name) {
		case "Beer":
			this.Ingredients = drinkList ["Beer"];
			break;
		case "Cola":
			this.Ingredients = drinkList ["Cola"];
			break;
		case "Diesel":
			this.Ingredients = drinkList ["Diesel"];
			break;
		case "Cuba Libre":
			this.Ingredients = drinkList ["Cuba Libre"];
			break;
		}
	}
}
