using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 7.0f;
    private Rigidbody2D rb;
    private Vector2 bounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > bounds.x * 2
            || transform.position.x < bounds.x * -2
            || transform.position.y > bounds.y * 2
            || transform.position.y < bounds.y * -2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
