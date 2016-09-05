using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventory : MonoBehaviour {

    private int _selectedSlot;
    public int selectedSlot
    {
        get { return _selectedSlot; }
        set {
            if (_selectedSlot != value)
            {
                _selectedSlot = value;
                UpdateStoredSound();
            }
        }
    }

    public List<string> content = new List<string>();

    public AudioSource source;
    public SoundModelCache cache;

	// Use this for initialization
	void Start () {
        cache = FindObjectOfType<SoundModelCache>();
        content = InventoryIO.Load();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void AddToInventory(string id)
    {
        content.Add(id);
        InventoryIO.Save(content);
    }

    public void UpdateStoredSound()
    {
        var soundModel = cache.soundModels[content[selectedSlot]];
        var audioclip = Resources.Load<AudioClip>(soundModel.sound);
        source.loop = true;
        source.clip = audioclip;
        source.volume = soundModel.volume;
        source.pitch = soundModel.pitch;
        source.Play();
    }

    public int WrapIndex(int index)
    {
        if (content.Count <= 0)
        {
            return 0;
        }
        return (index + content.Count) % content.Count;
    }
}
