using UnityEngine;
using System.Collections;

public static class WorldImporter {

    public static void ImportWorld(GameWorldData worldData)
    {
        foreach (var sound in worldData.Sounds)
        {
            var gobj = new GameObject();
            gobj.transform.position = sound.Position;
            var soundController = gobj.AddComponent<SoundController>();
            soundController.selectedSoundId = sound.Id;
        }
    }
}
