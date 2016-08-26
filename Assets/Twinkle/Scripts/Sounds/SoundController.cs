using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    public SoundModel model;
    public bool selected;

	// Use this for initialization
	void Start () {
        var audioclip = Resources.Load<AudioClip>(model.sound);
        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioclip;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnDrawGizmos()
    {
        if (model != null)
        {
            Gizmos.color = model.soundColor;
        }
        Gizmos.DrawSphere(this.transform.position, 0.1f);
    }
}
