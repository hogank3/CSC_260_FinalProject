using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
    private Vector2 bounds;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        width = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        height = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, bounds.x * -1 + width, bounds.x - width);
        viewPos.y = Mathf.Clamp(viewPos.y, bounds.y * -1 + height, bounds.y - height);
        transform.position = viewPos;
    }
}
