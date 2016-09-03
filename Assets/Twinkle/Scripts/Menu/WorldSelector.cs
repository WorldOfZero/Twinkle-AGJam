using UnityEngine;
using System.Collections;

public class WorldSelector : MonoBehaviour {

    public float delayPeriod = 0.5f;
    public WorldSelectionController controller;

    private float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (timer <= 0)
	    {
	        if (horizontal > 0.5f)
	        {
	            timer = delayPeriod;
	            controller.index += 1;
	        }
	        else if (horizontal < -0.5f)
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
