using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class WorldExporter {

    public static string ExportWorldToJson(GameWorldData gameworld)
    {
        return JsonUtility.ToJson(gameworld);
    }

    public static GameWorldData ExportCurrentWorld()
    {
        var world = new GameWorldData();
        world.UserId = Guid.NewGuid().ToString();
        world.CreatedDate = DateTime.Now;

        var worldSounds = GameObject.FindObjectsOfType<SoundController>();
        var worldSoundList = new List<SoundData>();

        foreach(var worldSound in worldSounds)
        {
            worldSoundList.Add(new SoundData()
            {
                Id = worldSound.selectedSoundId,
                Position = worldSound.transform.position
            });
        }

        world.Sounds = worldSoundList.ToArray();

        return world;
    }
}
