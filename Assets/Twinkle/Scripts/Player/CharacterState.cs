using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public enum CharacterConstructionState
{
    Exploring,
    Building
}

public class CharacterState : MonoBehaviour {

    private CharacterConstructionState _state;

    public CharacterConstructionState state
    {
        get { return _state; }
        set
        {
            if (_state != value)
            {
                _state = value;
                UpdateSoundState();
            }
        }
    }

    public float transitionTime = 1;

    public AudioMixer audioMixer;

    public AudioMixerSnapshot[] snapshots;

    public MonoBehaviour[] exploringBehaviors;
    public MonoBehaviour[] buildingBehaviors;

	// Use this for initialization
	void Start () {
        UpdateSoundState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            state = state == CharacterConstructionState.Exploring ? CharacterConstructionState.Building : CharacterConstructionState.Exploring;
        }
    }

    // Update is called once per frame
	void UpdateSoundState () {
	    switch (state)
	    {
            case CharacterConstructionState.Exploring:
                audioMixer.TransitionToSnapshots(snapshots, new float[] { 1, 0 }, transitionTime);
                DisableAndEnableBehaviors(true);
                break;
            case CharacterConstructionState.Building:
                audioMixer.TransitionToSnapshots(snapshots, new float[] { 0, 1 }, transitionTime);
                DisableAndEnableBehaviors(false);
	            break;
	    }
	}

    private void DisableAndEnableBehaviors(bool isExploring)
    {
        foreach (var behavior in exploringBehaviors)
        {
            behavior.enabled = isExploring;
        }
        foreach (var behavior in buildingBehaviors)
        {
            behavior.enabled = !isExploring;
        }
    }
}
