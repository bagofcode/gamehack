using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    public Transform target;
    public Vector2 offset; //TODO: leaning etc
	
	// Update is called once per frame
	void Update () {
        Vector2 cameraPositionTarget = (Vector2)target.position + offset;

        this.transform.position = new Vector3(cameraPositionTarget.x, cameraPositionTarget.y, this.transform.position.z);
	}
}
