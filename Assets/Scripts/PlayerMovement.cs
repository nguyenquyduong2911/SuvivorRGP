using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
   [SerializeField] private float speed;
  [HideInInspector]  public Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
      InputManagement();

        
    }
    void FixedUpdate()
    {
        Movement();
    }   

    void InputManagement()
    {
        int moveX = (int)Input.GetAxisRaw("Horizontal");
        int moveY = (int)Input.GetAxisRaw("Vertical");
    
        moveDir = new Vector2(moveX, moveY).normalized;
    }
    void Movement()
    {
        rb.velocity = new Vector2(moveDir.x, moveDir.y) * speed;

    }


}
