using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEquipment : MonoBehaviour
{
    public GameObject equip;
    public float respawnTime = 10.0f;
    private Vector2 bounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(equipmentWave());
    }

    private void spawnEquipment()
    {
        GameObject eob = Instantiate(equip) as GameObject;
        eob.transform.position = new Vector2(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));
    }

    IEnumerator equipmentWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEquipment();
        }
    }
}
