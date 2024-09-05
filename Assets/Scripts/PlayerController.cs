using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int health = 5;
    private float MovementX, MovementY;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovementX = Input.GetAxis("Horizontal");
        MovementY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MovementX, 0, MovementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }
    }
}
