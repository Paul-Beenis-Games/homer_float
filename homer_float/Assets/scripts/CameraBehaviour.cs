using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public Transform playerPosition;
    public Vector3 offset;

	void Start () {
        
        
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerPosition.position.x + offset.x, playerPosition.position.y + offset.y, offset.z);

    }
}
