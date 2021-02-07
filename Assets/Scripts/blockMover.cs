using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + (135.38f - 23.96911f));
        transform.Translate(Vector3.back * 8 * Time.deltaTime);
        if(gameObject.transform.position.z < -90) // Instantiating in VR can mess with meshes
        {
            Destroy(gameObject);
        }
    }
}