using UnityEngine;
using System.Collections;
using Rewired;

public class WorldSelector : MonoBehaviour {

    public float delayPeriod = 0.5f;
    public WorldSelectionController controller;

    private float timer;

    public int playerId;
    private Player player;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update ()
    {
        var horizontal = player.GetAxis("Slide");
        if (timer <= 0)
	    {
	        if (horizontal > 0f)
	        {
	            timer = delayPeriod;
	            controller.index += 1;
	        }
	        else if (horizontal < 0f)
	        {
	            timer = delayPeriod;
	            controller.index -= 1;
	        }
	    }

	    if (Mathf.Approximately(horizontal, 0))
	    {
            timer = 0;
	    }

	    timer -= Time.deltaTime;
	}
}
