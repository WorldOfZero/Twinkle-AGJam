using UnityEngine;
using System.Collections;
using Rewired;

public class CharacterController : MonoBehaviour {

    public float speed;
    public float verticalSensitivity;
    public float horizontalSensitivity;
    public float rollSensitivity;

    public int playerId;
    private Player player;

    // Use this for initialization
    void Start () {
        player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update ()
    {
        var verticalRotation = Quaternion.Euler(-player.GetAxis("Pitch") * verticalSensitivity, 0, 0);
        var horizontalRotation = Quaternion.Euler(0, player.GetAxis("Yaw") * horizontalSensitivity, 0);
        var rollRotation = Quaternion.Euler(0, 0, player.GetAxis("Roll") * rollSensitivity);

        this.transform.rotation *= verticalRotation;
        this.transform.rotation *= horizontalRotation;
        this.transform.rotation *= rollRotation;

        this.transform.position += this.transform.forward * player.GetAxis("Thruster") * speed * Time.deltaTime;
        this.transform.position += this.transform.right * player.GetAxis("Slide") * speed * Time.deltaTime;
        this.transform.position += this.transform.up * player.GetAxis("Raise") * speed * Time.deltaTime;
    }
}
