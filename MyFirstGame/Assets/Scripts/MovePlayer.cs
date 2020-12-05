using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float equipmentMultiplier = 0.9f;
    Vector2 movement;
    private Transform t;
    private float defaultFr;

    void Start()
    {
        defaultFr = Aim.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Aim.fireRate = defaultFr;
            SceneManager.LoadScene("GameScene");//(SceneManager.GetActiveScene().name);
        }
        if (other.tag == "equipment")
        {
            Destroy(other.gameObject);
            Aim.fireRate *= equipmentMultiplier;
        }
    }

    public void resetFireRate()
    {
        Aim.fireRate = defaultFr;
    }
}
