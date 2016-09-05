using UnityEngine;
using System.Collections;
using System.Linq;
using Rewired;

public class CharacterCollector : MonoBehaviour {

    public float range = 2;
    public SoundController selectedSoundController;

    public CharacterInventory inventory;

    public int playerId;
    private Player player;

	// Use this for initialization
	void Start () {
	    Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
        var nearbySounds = GameObject.FindObjectsOfType<SoundController>();
        var selectedSound = nearbySounds.
            //Where((sound) => Vector3.Dot(this.transform.forward, sound.transform.position - this.transform.position) > 0).
            Where((sound) => (this.transform.position - sound.transform.position).magnitude < range).
            OrderBy((sound) => (this.transform.position - sound.transform.position).magnitude).
            FirstOrDefault();

	    if (selectedSound != null)
	    {
            Debug.Log(Vector3.Dot(this.transform.forward, selectedSound.transform.position - this.transform.position));
	        if (selectedSoundController != null)
	        {
	            selectedSoundController.selected = false;
	        }
	        selectedSound.selected = true;
	        selectedSoundController = selectedSound;
	    }
	    else
	    {
            if (selectedSoundController != null)
            {
                selectedSoundController.selected = false;
            }
        }

	    if (selectedSound != null && !selectedSound.destroyed)
	    {
	        if (player.GetButtonDown("Interact"))
	        {
	            if (!inventory.content.Any((sound) => sound == selectedSound.selectedSoundId))
	            {
	                inventory.AddToInventory(selectedSound.selectedSoundId);
                    inventory.UpdateStoredSound();
                }
                selectedSound.destroyed = true;
	        }
	    }
	}
}
