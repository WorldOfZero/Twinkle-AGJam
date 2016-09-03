using UnityEngine;
using System.Collections;
using System.Linq;

public class WorldExporterDebugger : MonoBehaviour {

    public string jsonWorld;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Tab))
	    {
            //var world = WorldExporter.ExportCurrentWorld();
            //jsonWorld = WorldExporter.ExportWorldToJson(world);
            var worldService = new WorldService();
            var world = worldService.Get().First();
	        foreach (var sound in FindObjectsOfType<SoundController>())
	        {
                Destroy(sound.gameObject);
	        }
            WorldImporter.ImportWorld(world);
	    }
	}
}
