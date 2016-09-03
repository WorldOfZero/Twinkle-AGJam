using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

[Serializable]
public class GameWorldsCollection
{
    public GameWorldData[] Worlds;
}

[Serializable]
public class GameWorldData
{
    public string UserId;
    public DateTime CreatedDate;
    public SoundData[] Sounds;
}

[Serializable]
public class SoundData
{
    public string Id;
    public Vector3 Position;
}