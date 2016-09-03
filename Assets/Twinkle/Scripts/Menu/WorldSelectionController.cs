using UnityEngine;
using System.Collections;
using System.Linq;

public class WorldSelectionController : MonoBehaviour {

    private int lastIndex;
    public int index;
    public GameWorldData[] worlds;

	// Use this for initialization
	void Start () {
        index = 0;
        lastIndex = -1;
        var service = new WorldService();
        worlds = service.Get().ToArray();
	}
	
	// Update is called once per frame
	void Update () {
	    if (lastIndex != index)
	    {
            index = (index + worlds.Length) % worlds.Length;

            lastIndex = index;
            Debug.Log("World Shift");

            foreach (var sound in FindObjectsOfType<SoundController>())
            {
                Destroy(sound.gameObject);
            }
            WorldImporter.ImportWorld(worlds[index]);
        }
	}
}
