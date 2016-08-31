using UnityEngine;
using System.Collections;

public class CharacterPlacer : MonoBehaviour {

    public CharacterInventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            var gobj = new GameObject();
            gobj.transform.position = this.transform.position + this.transform.forward;
            var soundController = gobj.AddComponent<SoundController>();
            soundController.selectedSoundId = inventory.content[inventory.selectedSlot];
	    }
	}
}
