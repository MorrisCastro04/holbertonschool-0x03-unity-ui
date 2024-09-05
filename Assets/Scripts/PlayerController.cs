using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isTeleport = false;
    private string TeleporterName;
    public float speed;
    public int health = 5;
    private float MovementX, MovementY;
    private int score = 0;
    private Vector3 otherTeleporter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
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

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }

        if (other.CompareTag("Teleporter") && isTeleport == false)
        {
            if (other.name == "Teleporter")
            {
                transform.position = GameObject.Find("Teleporter (1)").transform.position;
                TeleporterName = "Teleporter (1)";
            }
            else
            {
                transform.position = GameObject.Find("Teleporter").transform.position;
                TeleporterName = "Teleporter";
            }
            isTeleport = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (TeleporterName == other.name)
            isTeleport = false;
    }
}
