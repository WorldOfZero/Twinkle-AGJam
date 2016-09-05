using UnityEngine;
using System.Collections;
using Rewired;

public class CharacterPlacer : MonoBehaviour {

    public CharacterInventory inventory;

    public int playerId;
    private Player player;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
	    if (player.GetButtonDown("Interact"))
	    {
            var gobj = new GameObject();
            gobj.transform.position = this.transform.position + this.transform.forward;
            var soundController = gobj.AddComponent<SoundController>();
            soundController.selectedSoundId = inventory.content[inventory.selectedSlot];
	    }
	}
}
