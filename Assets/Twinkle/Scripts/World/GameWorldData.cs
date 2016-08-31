using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class GameWorldData
{
    public string UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public SoundData[] Sounds { get; set; }
}

[Serializable]
public class SoundData
{
    public string Id { get; set; }
    public Vector3 Position { get; set; }
}