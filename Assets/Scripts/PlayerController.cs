using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
 
    private float movementX;
    private float movementY;

    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Animator playerAnim;

    public int speed = 1;
    public float aimAngle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector2((transform.position.x + movementX * speed * Time.deltaTime),
            transform.position.y + movementY * speed * Time.deltaTime));

        if (movementX != 0 || movementY != 0)
        {
            playerAnim.SetBool("isRunning", true);
        }

        else
        {
            playerAnim.SetBool("isRunning", false);
        }

        CharFlip();

        //Vector2 lookDir = mousePos - rb.position;
        //float aimAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = aimAngle;

        //checks for mouse location
        //Debug.Log("looking = " + lookDir);
      
       
    }

    void CharFlip()
    {
        if (movementX < 0)
        {
            spriteRender.flipX = true;
        }

        if (movementX > 0)
        {
            spriteRender.flipX = false;
        }
    }
}
