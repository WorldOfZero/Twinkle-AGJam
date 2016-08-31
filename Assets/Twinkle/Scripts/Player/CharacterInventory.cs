﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventory : MonoBehaviour {

    public int selectedSlot;
    public List<string> content = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
