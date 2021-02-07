using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeBlock : MonoBehaviour
{
    public GameObject block, spawnPosition;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnBlock", 0.0f, 0.12f);
    }

    // Update is called once per frame
    void SpawnBlock()
    {
        Instantiate(block, spawnPosition.transform.position, transform.rotation * Quaternion.Euler(0, 0, 0));
    }
}