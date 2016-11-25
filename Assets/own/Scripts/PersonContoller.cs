using UnityEngine;
using System.Collections;
using System;

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
		if (Input.GetButtonDown ("Fire2")) 
			Inventory = null;
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
		if (hit.transform.IsChildOf (Ingredients))
			this.Inventory = hit.transform;
		
		if (hit.transform.IsChildOf (Equipment)) {
			// If nothing in Inventory or other Equipment, pickup this!
			if (this.Inventory == null || this.Inventory.IsChildOf(Equipment))
				this.Inventory = hit.transform;
			// If Ingredient in Inventory, mix it!
			if(this.Inventory.IsChildOf(Ingredients)) {
				hit.transform.SendMessage ("AddIngredient", Inventory);
			}
		}

		if (hit.transform.IsChildOf (Clients)) {
			if (this.Inventory == null)
				Debug.Log ("Do you want something from me?");
			else if (this.Inventory.IsChildOf (Ingredients) || this.Inventory.IsChildOf (Equipment))
				hit.transform.SendMessage ("GetDrink");
		}
		Debug.Log (this.Inventory + " is now in the inventory.");
	}
}
