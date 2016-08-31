using UnityEngine;
using System.Collections;

public class CharacterInventorySelector : MonoBehaviour {

    public CharacterInventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var modification = Input.GetAxis("InventorySelection");
        inventory.selectedSlot = inventory.WrapIndex(inventory.selectedSlot + Mathf.RoundToInt(modification));
	}
}
