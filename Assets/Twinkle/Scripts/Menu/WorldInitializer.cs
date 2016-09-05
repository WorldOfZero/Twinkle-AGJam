using UnityEngine;
using System.Collections;
using System.Linq;

public class WorldInitializer : MonoBehaviour {

    public bool inGame = false;

    public Transform target;
    public GameObject[] ingameObjects;
    public GameObject[] menuObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var disabledSet = inGame ? menuObjects : ingameObjects;
        var enabledSet = inGame ? ingameObjects : menuObjects;

        SetEnabledOfSet(disabledSet, false);
        SetEnabledOfSet(enabledSet, true);

	    foreach (var gobj in ingameObjects.Concat(menuObjects))
	    {
            gobj.transform.position = target.position;
            gobj.transform.rotation = target.rotation;
	    }
	}

    void SetEnabledOfSet(GameObject[] gobjs, bool enabled)
    {
        foreach (var gobj in gobjs)
        {
            gobj.SetActive(enabled);
        }
    }
}
