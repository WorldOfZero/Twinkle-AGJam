using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

[Serializable]
public class SoundModel : MonoBehaviour{

    public string guid = Guid.NewGuid().ToString();
    public Color soundColor;
    public string sound = "SFX/Beat/Synthetic/kick";
    [Range(0,1)]
    public float volume = 1;
    [Range(-3,3)]
    public float pitch = 1;
}
