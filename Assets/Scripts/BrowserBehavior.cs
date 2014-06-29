using UnityEngine;
using System.Collections;

public class BrowserBehavior : MonoBehaviour {

	private bool interact = false;

	public float speed = 7.5F;
	public float jumpSpeed = 20.0F;
	public float rotationSpeed = 10.0F;
	public float gravity = 50.0F;
	public Vector3 spawn = Vector3.zero;
	private Vector3 moveDirection = Vector3.zero;
	private float yRot;
	
	// Use this for initialization
	void Start () {		
		spawn.Set(0.0F, 1.0F, 0.0F);
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		Transform charCamTransform = GameObject.FindGameObjectWithTag ("browserCam").transform;
		// sets player back to spawn, if falling below a certain threshold
		if (controller.transform.position.y <= -50)
			controller.transform.position = spawn;
		
		// enables the player to walk and jump
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("BrowserHorizontal"), 0, Input.GetAxis("BrowserVertical"));
			moveDirection = transform.TransformDirection(moveDirection) * speed;
			if (Input.GetButton("BrowserJump"))
				moveDirection.y = jumpSpeed;
		}

		// interact with spawner
		interact = Input.GetButton("BrowserInteract");
		
		// applies rotation to the character
		transform.rotation = Quaternion.Euler (0, charCamTransform.rotation.eulerAngles.y, 0);
		// applies gravity to the character
		moveDirection.y -= gravity * Time.deltaTime;
		// applies moving to the character
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (interact && hit.collider.gameObject.tag == "SpawnPoint") {
			SpawnPoint spawn = (SpawnPoint) hit.collider.gameObject.GetComponent("SpawnPoint");
			spawn.ActivateTargetObject();
		}
	}
}
