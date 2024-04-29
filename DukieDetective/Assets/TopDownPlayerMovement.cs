using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        y = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(x, y, 0f);

    }
}
