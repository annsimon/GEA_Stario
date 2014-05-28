using UnityEngine;
using System.Collections;

// attach this script to a camera in your scene
// this script needs a gamobject tagged as Player

public class ThirdPersonCamera : MonoBehaviour {


	[SerializeField]
	private float distanceAway = 4;
	[SerializeField]
	private Transform playerTransform;
	[SerializeField]
	private Vector3 offset = new Vector3(0f, 1.5f,0f);

	[SerializeField]
	private float MAX_VERT_ANGLE = Mathf.PI/2 - 0.01f;
	[SerializeField]
	private float MIN_VERT_ANGLE = 0.01f;
	[SerializeField]
	private float MAX_DIST = 10;
	[SerializeField]
	private float MIN_DIST = 1;
	[SerializeField]
	private float mouseSesitivity = 0.1f;
	private float vertAngle = 1;
	private float horAngle = 0;
    [SerializeField]
    private bool inverted = false;

	private Vector3 lookDir;
	private Vector3 targetPosition;


	private Vector3 velocityCamSmooth = Vector3.zero;
	[SerializeField]
	private float camSmoothDampTime = 0.1f;

    // calculate a smooth transition between two positions
	private void smoothPosition(Vector3 fromPos, Vector3 toPos)
	{
		this.transform.position = Vector3.SmoothDamp (fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
	}

	// Use this for initialization
	void Start () {
        // get the player transform
		playerTransform = GameObject.FindWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){

		Vector3 characterOffset = playerTransform.position + offset;

		float inv = inverted ? -1 : 1;

        // get Inputs
		float distOffset = -Input.GetAxis ("Mouse ScrollWheel");
		vertAngle += inv * mouseSesitivity * Input.GetAxis ("Mouse Y");
		horAngle -= mouseSesitivity * Input.GetAxis ("Mouse X");

        // clamp rotation angles and distance
		if (vertAngle >= MAX_VERT_ANGLE) {
			vertAngle = MAX_VERT_ANGLE;
		} else if (vertAngle <= MIN_VERT_ANGLE) {
			vertAngle = MIN_VERT_ANGLE;
		}
		//print (vertAngle);
		if (horAngle >= 2*Mathf.PI) {
			horAngle -= 2*Mathf.PI;
		} else if (horAngle <= 0) {
			horAngle += 2*Mathf.PI;
		}

		distanceAway += distOffset;

		if (distanceAway >= MAX_DIST) {
			distanceAway = MAX_DIST;
		} else if (distanceAway <= MIN_DIST) {
			distanceAway = MIN_DIST;
		}

		// calculate polar coordinates
		Vector3 polar = new Vector3(0f,0f,0f);
		float x = distanceAway * Mathf.Sin(vertAngle) * Mathf.Cos(horAngle);
		float y = distanceAway * Mathf.Cos(vertAngle);
		float z = distanceAway * Mathf.Sin(vertAngle) * Mathf.Sin(horAngle);
		polar.Set (x, y, z);

		targetPosition = characterOffset + polar;
		Debug.DrawLine(characterOffset, targetPosition, Color.magenta);

		smoothPosition(this.transform.position, targetPosition);

        // point the camera to player
		transform.LookAt(characterOffset);
	}
}
