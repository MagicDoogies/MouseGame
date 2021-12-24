using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class thirdPersonMovement : MonoBehaviour
{
    public CharacterController controller; // references the character controller
    Vector3 velocity;
    public float gravity = -9.81f;
    
    public float speed; //controls how fast the character moves. 
    public float turnSmoothTime = 0.1f; // how long it takes for player to smooth turn. 
    private float smoothVelocity; // how fast the player smooth turns.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public GameObject startingPoint; //References the Gameobject that functions as a start location for the player. 

    public Transform cam;

    public Flowchart overworldDialogue;
    public Flowchart rheasDialogue;

    public void Start()
    {
        /*transform.position = startingPoint.transform.position;*///At the start of the game, place the player at the location of the startingpoint Gameobject.
        /*transform.Rotate(0f, 180f, 0f);*/ //rotate the player around so they are facing the npc. Subject to change later.
    }
    // Update is called once per frame
    void Update()
    {
        /*if (!overworldDialogue.HasExecutingBlocks() || !rheasDialogue.HasExecutingBlocks())//If neither of these flowcharts have executing blo
        {

        }*/
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal"); //Move left/riht using 'A', 'D' keys or 'Left/Right' arrow keys. 
        float vertical = Input.GetAxisRaw("Vertical");// Move up and down using the 'W', 'S' keys or the 'Up/Down' arrow keys.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
           
        }
        //The following section handles gravity through the player controller. 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
