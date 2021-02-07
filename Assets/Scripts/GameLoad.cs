using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLoad : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            SceneManager.LoadScene("Structure_02");
        }
    }
}
