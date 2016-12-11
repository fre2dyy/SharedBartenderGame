using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PersonContoller : MonoBehaviour {

	private RaycastHit hit;
	private float range = 10f;
	public UiController Ui;
	public Transform Inventory;
	private Transform Ingredients;
	private Transform Equipment;
	private Transform Clients;

	// Use this for initialization
	void Start () {
		// Load UiController in order to execute member functions
		Ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UiController>();
		Ingredients = GameObject.Find ("Ingredients").transform;
		Equipment = GameObject.Find ("Equipment").transform;
		Clients = GameObject.Find ("Clients").transform;
	}
	
	// Update is called once per frame
	void Update () {
		CheckForHit ();

		// Drop Inventory
		if (Input.GetButtonDown ("Fire2")) {
			this.dropItem ();
		}
	}

	/*
	 * Everytime when the Ray hits a collider it checks if the hit object
	 * is an object one can interact with
	 */
	void CheckForHit () {
		// Check if Ray hits an item
		if(Physics.Raycast(transform.position, transform.forward, out hit, range)) {
			// Check if item is interactable
			if(hit.transform.tag.Equals("Interaction")) {
				Ui.ActivateCrosshair();
				if (Input.GetButtonDown ("Fire1"))
					Interact ();
			} else {
				Ui.DeactivateCrosshair();
			}
		} else {
			// Change Crosshair to inactive
			Ui.DeactivateCrosshair();
		}
	}

	/*
	 * Depending on hit objects this controls the interaction between Barkeeper
	 * Ingredient, Glass/Shaker and Client
	 */
	void Interact() {
		// If click on ingredient always replace inventory with it
		if (hit.transform.IsChildOf (Ingredients)) {
			this.pickupIngredient ();
		}

		// If hit Equipment
		if (hit.transform.IsChildOf (Equipment)) {
			this.interactEquipment ();
		}

		if (hit.transform.IsChildOf (Clients)) {
			this.interactClient ();
		}
		// Empty Equipment if it hits the sink
		if(hit.transform.gameObject.name.Equals("Sink")) {
			this.emptyEquipment ();
		}
	}

	/*
	 * Raycast hits Equipment
	 */
	private void interactEquipment() {
		// If nothing in Inventory or other Equipment, pickup this!
		if (this.Inventory == null || this.Inventory.IsChildOf(Equipment))
			this.Inventory = hit.transform;
		Ui.ReceiveItem (this.Inventory.name);
		// If Ingredient in Inventory, mix it!
		if(this.Inventory.IsChildOf(Ingredients)) {
			// TODO
			Dictionary<string, int> DrinkIngredients = hit.transform.gameObject.GetComponent<DrinkController> ().DrinkIngredients;
			foreach(var item in DrinkIngredients) {
				Debug.Log (item.Key + " : " + item.Value);
			}
			hit.transform.SendMessage ("AddIngredient", Inventory);
		}		
	}

	/*
	 * Raycast hits Client
	 */
	private void interactClient() {
		if (this.Inventory == null) {
			Debug.Log ("Do you want something from me?");
		}
		else if (this.Inventory.IsChildOf (Equipment)) {
			Dictionary<string, int> DrinkIngredients = Inventory.GetComponent<DrinkController> ().DrinkIngredients;
			if (DrinkIngredients != null && DrinkIngredients.Count > 0)
				hit.transform.SendMessage ("GetDrink", DrinkIngredients);
			else
				Debug.Log ("There's no damn drink in it!");
		}
		else if (this.Inventory.IsChildOf (Ingredients)){
			// Send dictionary to ClientController
			hit.transform.SendMessage("GetDrink", new Dictionary<string, int>() {{this.Inventory.name, 1}});
			this.dropItem ();
		}		
	}

	/*
	 * Raycast hits Ingredient
	 */
	private void pickupIngredient() {
		this.Inventory = hit.transform;
		Ui.ReceiveItem (this.Inventory.name);		
	}
		
	/*
	 * Drop item: Clear Inventory
	 */
	private void dropItem() {
		Inventory = null;
		Ui.ReceiveItem (null);
	}

	/*
	 * Empty Equipment: Clear DrinkIngredients out of Equipment
	 */
	private void emptyEquipment() {
		if(this.Inventory.IsChildOf(Equipment)) {
			this.Inventory.GetComponent<DrinkController> ().EmptyEquipment ();
		}		
	}
}
