using UnityEngine;

public class Player2D : MonoBehaviour
{
    float movementSpeed = 5;
    private float XInput;

    public bool isGrounded;
    public Transform jumpPoint;
    public float JumpVelocity;
    public float range;

    /// 1) lable the platform as "Ground"
    /// 2) in the "Inspector" Tab on the player script "Ground Layer = Ground"
    public LayerMask groundLayer;
    // Playerpos = Player position
    public Transform playerPos;

    void Start()
    {

    }

    void Update()
    {
        //jump
        Collider2D[] jumpDetection = Physics2D.OverlapCircleAll(transform.position, range, groundLayer);
        foreach(Collider2D collider2D in jumpDetection)
        {
            if (collider2D.IsTouchingLayers(groundLayer))
            {
                print("Jump");
                isGrounded = Physics2D.OverlapCapsule(playerPos.position, playerPos.GetComponent<CircleCollider2D>().offset, 0, groundLayer);
            } else { isGrounded = false; }
        }
        if (isGrounded == true) if (Input.GetKeyDown(KeyCode.Space)) GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpVelocity;
       

        //movement
        XInput = Input.GetAxis("Horizontal") * movementSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(XInput, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(jumpPoint.position, range);
    }
}
