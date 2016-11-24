using UnityEngine;
using System.Collections;
using System;

public class PersonContoller : MonoBehaviour {

	private RaycastHit hit;
	private float range = 10f;
	public UiController Ui;
	public string Inventory;
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
			this.Inventory = hit.transform.name;
		
		if (hit.transform.IsChildOf (Equipment)) {
			if (String.IsNullOrEmpty (this.Inventory))
				this.Inventory = hit.transform.name;
		}

		if (hit.transform.IsChildOf (Clients)) {
			if (String.IsNullOrEmpty (this.Inventory))
				Debug.Log ("Do you want something from me?");
		}
		Debug.Log (this.Inventory + " is now in the inventory.");
	}
}
