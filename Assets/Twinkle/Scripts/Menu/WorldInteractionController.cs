using UnityEngine;
using System.Collections;
using System;
using Rewired;

public class WorldInteractionController : MonoBehaviour {

    public WorldInitializer initializer;
    public WorldSelectionController worldSelector;

    public int playerId;
    private Player player;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
	    if (initializer.inGame)
	    {
            if (player.GetButtonDown("Exit"))
            {
                initializer.inGame = false;
                ExitGameMode();
            }
        }
	    else
	    {
            if (player.GetButtonDown("Interact"))
            {
                initializer.inGame = true;
                EnterGameMode();
            }
            else if (player.GetButtonDown("Exit"))
            {
                Application.Quit();
            }
	    }
	}

    private void ExitGameMode()
    {
        var gameWorld = WorldExporter.ExportCurrentWorld();
        gameWorld.UserId = worldSelector.worlds[worldSelector.index].UserId;
        var worldIndex = worldSelector.worlds.FindIndex((world) => world.Equals(gameWorld));
        if (worldIndex < 0)
        {
            worldSelector.worlds.Add(gameWorld);
        }
        else
        {
            worldSelector.worlds.RemoveAt(worldIndex);
            worldSelector.worlds.Insert(worldIndex, gameWorld);
        }

        var service = new WorldService();
        service.Post(gameWorld);
    }

    private void EnterGameMode()
    {
        
    }
}
