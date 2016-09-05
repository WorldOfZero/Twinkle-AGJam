using UnityEngine;
using System.Collections;
using Rewired;

public class CharacterInventorySelector : MonoBehaviour {

    public CharacterInventory inventory;

    public int playerId;
    private Player player;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
        var modification = player.GetAxis("InventorySelection");
        inventory.selectedSlot = inventory.WrapIndex(inventory.selectedSlot + Mathf.RoundToInt(modification));
	}
}
