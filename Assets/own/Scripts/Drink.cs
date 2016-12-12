using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
	public decimal Price;
	public Dictionary<string, decimal> Ingredients;

	// Basic ingredients like "Cola" or "Beer" always have value >=100
	private static Dictionary<string, Dictionary<string, decimal>> drinkList = new Dictionary<string, Dictionary<string, decimal>>() {
		{"Beer", new Dictionary<string, decimal> {{"Beer", 200.0m}}},
		{"Cola", new Dictionary<string, decimal> {{"Cola", 200.0m}}},
		{"Diesel", new Dictionary<string, decimal> {{"Beer", 100.0m}, {"Cola", 100.0m}}},
		{"Cuba Libre", new Dictionary<string, decimal> {{"Cola", 100.0m}, {"Schnapps", 60.0m}, {"Lemon", 0.5m}}},
		{"Sex on the Beach", new Dictionary<string, decimal> {{"Cola", 100.0m}, {"Schnapps", 60.0m}}}
	};

	public static string[] GetDrinkList() {
		return drinkList.Keys.ToArray ();
	}

	public Drink(string name) {
		this.Name = name;
		this.SetDrink ();
	}

	private void SetDrink() {
		switch(this.Name) {
		case "Beer":
			this.Ingredients = drinkList ["Beer"];
			this.Price = 3;
			break;
		case "Cola":
			this.Ingredients = drinkList ["Cola"];
			this.Price = 2;
			break;
		case "Diesel":
			this.Ingredients = drinkList ["Diesel"];
			this.Price = 2.5m;
			break;
		case "Cuba Libre":
			this.Ingredients = drinkList ["Cuba Libre"];
			this.Price = 6;
			break;
		case "Sex on the Beach":
			this.Ingredients = drinkList ["Sex on the Beach"];
			this.Price = 6.5m;
			break;
		}
	}
}
