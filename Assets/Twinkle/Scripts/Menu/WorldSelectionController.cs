using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

public class WorldSelectionController : MonoBehaviour {

    private int lastIndex;
    public int index;
    public List<GameWorldData> worlds;

	// Use this for initialization
	void Start () {
        index = 0;
        lastIndex = -1;
        var service = new WorldService();
        worlds = new List<GameWorldData>();
	    try
	    {
	        worlds = service.Get().ToList();
	    }
	    catch (WebException socketException)
	    {
	        Debug.LogException(socketException);
	    }
	    catch (Exception exception)
	    {
            Debug.LogException(exception);
	    }
	    worlds.Insert(0, new GameWorldData());
	}
	
	// Update is called once per frame
	void Update () {
	    if (lastIndex != index)
	    {
            index = (index + worlds.Count) % worlds.Count;

            lastIndex = index;
            Debug.Log("World Shift");

            foreach (var sound in FindObjectsOfType<SoundController>())
            {
                sound.destroyed = true;
            }
            WorldImporter.ImportWorld(worlds[index]);
        }
	}
}
