using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public string selectedSoundId;
    public bool selected;
    public AudioSource audioSource;

    public float soundFade = 1;
    public bool destroyed = false;
    private float timer = 0;

    public Color color
    {
        get { return viewModel.soundColor; }
    }

    private SoundModelCache cache;
    public SoundModel viewModel
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
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.outputAudioMixerGroup = cache.mixer;
        audioSource.spatialBlend = 1;
        audioSource.loop = true;
        audioSource.clip = audioclip;
        audioSource.volume = viewModel.volume;
        audioSource.pitch = viewModel.pitch;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!destroyed)
	    {
	        timer = Mathf.Min(timer + Time.deltaTime, soundFade);
	    }
	    else
	    {
            timer -= Time.deltaTime;
	        if (timer < 0)
	        {
                Destroy(gameObject);
	        }
	    }

        audioSource.volume = viewModel.volume * (timer / soundFade);
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
