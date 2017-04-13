using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 150.0F;
    public float jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    Vector3 defaultPos;

    bool isGrounded;

    public Animator EndAnimation; 

    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            _rigidbody.AddForce(Vector3.up * jumpSpeed);

        }

    }




    // refer to the Rigidbody component
    // this does not mean that the Rigidbody will be available
    // by default.
    protected Rigidbody _rigidbody;


    // when the object wakes up (is created), get its components
    void Awake()
    {
        // Get the Rigidbody component on this object.
        // GetComponent <Type> ();
        _rigidbody = GetComponent<Rigidbody>();
        defaultPos = transform.position;

    }


    // Fixed Update is used for Physics and Regular Intervals
    void FixedUpdate()
    {

        // the player will press on the left and right keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (_rigidbody.position.y < -500f)
        {
            Reset();
        }

        Move(-horizontal, vertical);

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "EndGameCollider")
        {
            GameObject.FindObjectOfType<GlitchEffect>().intensity = 10f;
            EndAnimation.SetTrigger("Fade In"); 
        }

        if (c.tag == "PillCollider")
        {
            GameObject.FindObjectOfType<GlitchEffect>().intensity += 0.3f;
            Destroy(c.gameObject);
        }

   }


    void Reset()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    // Controls the player movement
    void Move(float h, float v)
    {

        // Sets the movement I'm inputting on the keyboard
        moveDirection.Set(h, 0, v);

        // make sure the player is moving on a circle, not a square
        moveDirection = moveDirection.normalized * speed * Time.deltaTime;

        // moves the player to a specified position
        _rigidbody.MovePosition(transform.position + moveDirection);
    }
}