using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    private float x, y;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    public float xvel;
    

    //private Animator myanimator;

    void Start()
    {
        //myanimator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        y = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;

        //transform.Translate(x, y, 0f);

        
        //rb.MovePosition = new Vector2(x, y);


        //myanimator.SetBool("Walk", true);

    }

    void FixedUpdate()
    {
        Vector2 xvel = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime);
        rb.velocity = xvel;
        //Vector2 yvel = new Vector2(0, );
        //rb.velocity = yvel;
    }

}
