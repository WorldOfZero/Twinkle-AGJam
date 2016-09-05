using UnityEngine;
using System.Collections;

public class MaterialStreamer : MonoBehaviour {

    public float range = 500;

    public Material workingMaterial;
    private Texture2D texture;

    public Vector3 vector;
    
	void Start () {
	}
	
	void Update () {
        var sounds = FindObjectsOfType<SoundController>();
        texture = new Texture2D(sounds.Length, 2);
        texture.filterMode = FilterMode.Point;
	    for (int x = 0; x < sounds.Length; ++x)
	    {
            if (sounds[x] == null || sounds[x].audioSource == null) continue;

            var distance = sounds[x].transform.position - this.transform.position;
            var normalizedVector = distance.normalized;
            var scalar = Mathf.Max((range - distance.magnitude) / range, 0);
            normalizedVector *= scalar;
            texture.SetPixel(x, 0, new Color(0.5f + 0.5f * normalizedVector.x, 0.5f + 0.5f * normalizedVector.y, 0.5f + 0.5f * normalizedVector.z));
            float currentTime = (sounds[x].audioSource.time / sounds[x].audioSource.clip.length);
            texture.SetPixel(x, 1, Color.Lerp(Color.black, sounds[x].color, sounds[x].viewModel.soundIntensityGraph.Evaluate(currentTime) * sounds[x].audioSource.volume));

            vector = distance;
        }
        texture.Apply();
        workingMaterial.SetTexture("_SoundMap", texture);
        workingMaterial.SetInt("_SoundCount", sounds.Length);
	}
}
