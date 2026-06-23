using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float jumpForce = 8f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;

    private int desiredLane = 1;
    private GameManager gameManager;
    public AudioClip jumpSound;
    public GameObject hitEffect;
    private Vector2 startTouchPos;
    
private Vector2 endTouchPos;

private AudioSource audioSource;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameManager = FindObjectOfType<GameManager>();
     audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (forwardSpeed < 25f)
        {
            forwardSpeed += 0.3f * Time.deltaTime;
        }

        forwardSpeed = Mathf.Clamp(forwardSpeed, 10f, 25f);

        Vector3 move = Vector3.forward * forwardSpeed;

        // LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;

            if (desiredLane < 0)
                desiredLane = 0;
        }

        // RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;

            if (desiredLane > 2)
                desiredLane = 2;
        }

        // LANE POSITION
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;

        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        Vector3 difference = targetPosition - transform.position;

        move.x = difference.x * 10f;

        // JUMP
        // JUMP
        if (Input.GetKeyDown(KeyCode.UpArrow) && controller.isGrounded)
        {
            velocity.y = jumpForce;

            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        // GRAVITY
        velocity.y += gravity * Time.deltaTime;

        move.y = velocity.y;

        controller.Move(move * Time.deltaTime);

        if (Input.touchCount > 0)
{
    Touch touch = Input.GetTouch(0);

    if (touch.phase == TouchPhase.Began)
    {
        startTouchPos = touch.position;
    }

    if (touch.phase == TouchPhase.Ended)
    {
        endTouchPos = touch.position;

        Vector2 swipe =
            endTouchPos - startTouchPos;

        // LEFT
        if (swipe.x < -50)
        {
            desiredLane--;

            if (desiredLane < 0)
                desiredLane = 0;
        }

        // RIGHT
        if (swipe.x > 50)
        {
            desiredLane++;

            if (desiredLane > 2)
                desiredLane = 2;
        }

        // UP JUMP
        if (swipe.y > 50 &&
            controller.isGrounded)
        {
            velocity.y = jumpForce;
        }
    }
}
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
{
    if (hit.transform.tag == "Obstacle")
    {
        Instantiate(
    hitEffect,
    transform.position,
    Quaternion.identity);
        forwardSpeed = 0;

        gameManager.EndGame();
    }
}
}