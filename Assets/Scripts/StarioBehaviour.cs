using UnityEngine;
using System.Collections;

// script simply needs to be attached to a gameObject, in order to work
public class StarioBehaviour : MonoBehaviour {

    public float speed = 5.0F;
    public float jumpSpeed = 20.0F;
    public float rotationSpeed = 10.0F;
    public float gravity = 50.0F;
    public Vector3 spawn = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private float yRot;

    // Use this for initialization
    void Start()
    {
        spawn.Set(0.0F, 1.0F, 0.0F);
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
		Transform charCamTransform = Camera.main.transform;
        // sets player back to spawn, if falling below a certain threshold
        if (controller.transform.position.y <= -50)
            controller.transform.position = spawn;
        
//        // enables the player to walk and jump
       if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection) * speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
		//print (moveDirection.ToString());
        }

        // enables the player to rotate the character (and it´s sight)
//        if (Input.GetAxis("Mouse X")!=0)
//            yRot += rotationSpeed * Input.GetAxis("Mouse X");

        // applies rotation to the character
		transform.rotation = Quaternion.Euler (0, charCamTransform.rotation.eulerAngles.y, 0);
//		Vector3 rotation = new Vector3(0,charCamTransform.rotation.eulerAngles.y,0);
//		transform.Rotate(rotation);
		print (charCamTransform.rotation.eulerAngles.y);
        // applies gravity to the character
        moveDirection.y -= gravity * Time.deltaTime;
        // applies moving to the character
        controller.Move(moveDirection * Time.deltaTime);
    }
}
