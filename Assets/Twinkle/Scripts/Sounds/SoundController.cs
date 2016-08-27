using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public string selectedSoundId;
    public bool selected;

    public Color color
    {
        get { return viewModel.soundColor; }
    }

    private SoundModelCache cache;
    private SoundModel viewModel
    {
        get {
            if (cache == null)
            {
                cache = FindObjectOfType<SoundModelCache>();
            }
            return cache.soundModels[selectedSoundId];
        }
    }

    // Use this for initialization
    void Start () {
        var audioclip = Resources.Load<AudioClip>(viewModel.sound);
        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioclip;
        audioSource.volume = viewModel.volume;
        audioSource.pitch = viewModel.pitch;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnDrawGizmos()
    {
        cache = FindObjectOfType<SoundModelCache>();
        if (cache.soundModels.ContainsKey(selectedSoundId) && viewModel != null)
        {
            Gizmos.color = color;
        }
        Gizmos.DrawSphere(this.transform.position, 0.1f);
    }
}
