using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float speed;
    public float verticalSensitivity;
    public float horizontalSensitivity;
    public float rollSensitivity;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        var verticalRotation = Quaternion.Euler(-Input.GetAxis("Mouse Y") * verticalSensitivity, 0, 0);
        var horizontalRotation = Quaternion.Euler(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        var rollRotation = Quaternion.Euler(0, 0, Input.GetAxis("Roll") * rollSensitivity);

        this.transform.rotation *= verticalRotation;
        this.transform.rotation *= horizontalRotation;
        this.transform.rotation *= rollRotation;

        this.transform.position += this.transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.transform.position += this.transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.position += this.transform.up * Input.GetAxis("Rise") * speed * Time.deltaTime;
    }
}
