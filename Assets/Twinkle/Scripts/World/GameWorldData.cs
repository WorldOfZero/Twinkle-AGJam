using System;
using UnityEngine;

[Serializable]
public class GameWorldsCollection
{
    public GameWorldData[] Worlds;
}

[Serializable]
public class GameWorldData
{
    public string UserId = Guid.NewGuid().ToString();
    public DateTime CreatedDate;
    public SoundData[] Sounds = new SoundData[0];

    public override bool Equals(object obj)
    {
        var gameWorld = obj as GameWorldData;
        if (gameWorld != null)
        {
            return String.Equals(UserId, gameWorld.UserId, StringComparison.InvariantCultureIgnoreCase);
        }
        return base.Equals(obj);
    }
}

[Serializable]
public class SoundData
{
    public string Id;
    public Vector3 Position;
}