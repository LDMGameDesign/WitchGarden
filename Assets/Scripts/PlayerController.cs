using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float movementX;
    private float movementY;

 

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

        //Vector2 lookDir = mousePos - rb.position;
        //float aimAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = aimAngle;

        //checks for mouse location
        //Debug.Log("looking = " + lookDir);
      
       
    }
}
