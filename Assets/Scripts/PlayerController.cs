using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variables:

    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;
    private Vector2 normalColliderSize;
    private Vector2 normalColliderOffset;
    private Vector3 regularPlayerSize;
    private float moveSpeed = 10f;
    private float jumpForce = 5f;
    private float moveX;
    public bool isGrounded;
    public bool isCrouching;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets the component Rigidbody2D from the editor
        rb = GetComponent<Rigidbody2D>();
        // Gets the component BoxCollider2D from the editor
        playerCollider = GetComponent<BoxCollider2D>();


        // Var blueprints
        normalColliderSize = playerCollider.size;
        normalColliderOffset = playerCollider.offset;
        regularPlayerSize = transform.localScale; // This one of the gameObject's transform's options

    }

    // Update is called once per frame
    void Update()
    {
        // Getting horizontal movement
        moveX = Input.GetAxis("Horizontal");

        // For jumping
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            Debug.Log("moving brotato chip");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }   


        // Check if crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
        }  
        else
        {
            isCrouching = false;
        }

        // Changes the offset, size, and player size if crouching is true, and when we're not, it reverts to normal
        if (isCrouching == true)
        {
            Debug.Log("crouching vro");
            playerCollider.size = new Vector2(normalColliderSize.x, normalColliderSize.y / 2);
            playerCollider.offset = new Vector2(normalColliderOffset.x, normalColliderOffset.y / 4);

            transform.localScale = new Vector3(regularPlayerSize.x, regularPlayerSize.y / 2, regularPlayerSize.z);
        }
        else
        {
            playerCollider.size = normalColliderSize;
            playerCollider.offset = normalColliderOffset;
            transform.localScale = regularPlayerSize;
        }
        
    }

    void FixedUpdate()
    {
        // Moves player left and right based on math and coords
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if touching ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("touching ground manning");
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Checks if not touching ground AFTER checking if touching ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("not touching ground anymore sir");
            isGrounded = false;
        }
    }
}
