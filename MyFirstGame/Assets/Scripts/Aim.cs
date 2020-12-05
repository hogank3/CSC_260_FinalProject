using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject player;
    public GameObject laser;
    public GameObject laserStart;
    public float speed = 7f;
    private Vector3 target;
    public static float fireRate = 0.7f;
    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            shootLaser(direction, rotationZ);
            nextFire = Time.time + fireRate;
        }
        
        void shootLaser(Vector2 direction, float rotationZvar)
        {
            GameObject lob = Instantiate(laser) as GameObject;
            lob.transform.position = laserStart.transform.position;
            lob.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZvar);
            lob.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
