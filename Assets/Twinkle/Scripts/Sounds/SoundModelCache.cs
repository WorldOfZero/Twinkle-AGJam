using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

[ExecuteInEditMode]
public class SoundModelCache : MonoBehaviour {

    public AudioMixerGroup mixer;
    public Dictionary<string, SoundModel> soundModels = new Dictionary<string, SoundModel>();

    void Awake()
    {
        InitializeSoundModels();
    }

    void Update()
    {
        if (soundModels.Count == 0)
        {
            InitializeSoundModels();
        }
    }

    private void InitializeSoundModels()
    {
        var sounds = GetComponentsInChildren<SoundModel>();
        foreach (var sound in sounds)
        {
            soundModels.Add(sound.guid, sound);
        }
    }
}
