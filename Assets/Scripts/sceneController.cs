using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class sceneController : MonoBehaviour
{

    public GameObject[] positions;
    public GameObject player;
    public GameObject Unity_cam;
    public GameObject VR_cam;
    public GameObject Enviro;
    public GameObject Enviro0;
    public GameObject Enviro1;
    public GameObject Enviro2;
    public GameObject Enviro3;
    public GameObject Enviro4;
    // public GameObject menu;
    public int sceneStage;
    public int resp_index;
    public double sceneTime;
    public AudioClip[] soundclips;
    public string[] lines = { };
    public string[] PC_resp = { };
    public string[] Chad_resp = { };
    public AudioClip[] PC_audio_resp = { };
    public AudioClip[] Chad_audio_resp = { };
    public int[] opt_scenes = { };
    public int[] trans_scenes = { };
    public int cam_loc = 0;

    public Button red_btn;
    public Button blue_btn;
    public Button green_btn;

    public int butn_index = 1;
    //public bool butn_press = false;

    public TextMeshProUGUI dialog;

    public Canvas butn_canvas;

    //public 

    // public AudioClip[] blanky;
    // Start is called before the first frame update
    void Start()
    {
        blue_btn.GetComponent<Image>().color = Color.blue;
        butn_canvas.enabled = false;
        Enviro.SetActive(true);
        Enviro0.SetActive(false);
        Enviro1.SetActive(false);
        Enviro2.SetActive(false);
        Enviro3.SetActive(false);
        Enviro4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // OVRInput.Update();
        // VRCam.transform.position = player.transform.position;
        AudioSource audio = GetComponent<AudioSource>();

        if (opt_scenes.Contains(sceneStage - 1))
        {
            if (Input.GetKeyDown("1") || OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
            {
                red_btn.GetComponent<Image>().color = Color.red;
                blue_btn.GetComponent<Image>().color = Color.white;
                green_btn.GetComponent<Image>().color = Color.white;
                butn_index = 2;
                //butn_press = true;
            }
            else if (Input.GetKeyDown("2") || OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
            {
                red_btn.GetComponent<Image>().color = Color.white;
                blue_btn.GetComponent<Image>().color = Color.blue;
                green_btn.GetComponent<Image>().color = Color.white;
                butn_index = 1;
                //butn_press = true;
            }
            else if (Input.GetKeyDown("3") || OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
            {
                red_btn.GetComponent<Image>().color = Color.white;
                blue_btn.GetComponent<Image>().color = Color.white;
                green_btn.GetComponent<Image>().color = Color.green;
                butn_index = 0;
                //butn_press = true;
            }

            soundclips[sceneStage] = PC_audio_resp[resp_index + butn_index - 3];

            lines[sceneStage] = PC_resp[resp_index + butn_index - 3];

            soundclips[sceneStage + 1] = Chad_audio_resp[resp_index + butn_index - 3];

            lines[sceneStage + 1] = Chad_resp[resp_index + butn_index - 3];
        }

        if (Input.GetKeyDown("backspace") || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && sceneStage > 0)
        {
            sceneStage--;

            if (sceneStage == 0.0)
            {
                //player.transform.position = positions[0].transform.position;
                // Enviro.transform.position = new Vector3(0.189999998f, -1.63f, 10.0832739f);
                Enviro.SetActive(false);
                Enviro0.SetActive(true);
                Enviro1.SetActive(false);
                Enviro2.SetActive(false);
                Enviro3.SetActive(false);
                Enviro4.SetActive(false);
            }
            if (sceneStage >= 1 && sceneStage <= 8)
            {
                //player.transform.position = positions[1].transform.position;
                // Enviro.transform.position = new Vector3(-2.6500001f, -1.63f, 18.7600002f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(true);
                Enviro2.SetActive(false);
                Enviro3.SetActive(false);
                Enviro4.SetActive(false);
            }
            if (sceneStage >= 9 && sceneStage <= 31)
            {
                //player.transform.position = positions[2].transform.position;
                // Enviro.transform.position = new Vector3(-0.389999986f, -5.63000011f, 16.7999992f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(false);
                Enviro2.SetActive(true);
                Enviro3.SetActive(false);
                Enviro4.SetActive(false);
            }
            if (sceneStage >= 32 && sceneStage <= 43)
            {
                //player.transform.position = positions[3].transform.position;
                // Enviro.transform.position = new Vector3(-2.4000001f, -9.63000011f, 18.9400005f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(false);
                Enviro2.SetActive(false);
                Enviro3.SetActive(true);
                Enviro4.SetActive(false);
                // Unity_cam.SetActive(false);
                // VR_cam.SetActive(true);
                //player.transform.rotation = Quaternion.Euler(0, 210, 0);

            }
            if (sceneStage >= 43 && sceneStage <= 44)
            {
                //player.transform.position = positions[4].transform.position;
                // Enviro.transform.position = new Vector3(-101.300003f, -108.800003f, -5.9000001f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(false);
                Enviro2.SetActive(false);
                Enviro3.SetActive(false);
                Enviro4.SetActive(true);
                Unity_cam.SetActive(true);
                VR_cam.SetActive(false);
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (opt_scenes.Contains(sceneStage))
            {
                butn_canvas.enabled = false;
                resp_index -= 3;
            }

            sceneTime = 10;

            audio.clip = soundclips[sceneStage];

            dialog.text = lines[sceneStage];

            audio.Play();

            // Vector3(-8.94014263,-1.63304663,10.0832739) //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Vector3(0.368999988,-0.270999998,-0.0109999999) //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Vector3(-2.5999999,2.41000009,16.6200008) //////////////////////////////////////////////////////////////////////////////////////////////////////////////// FPS
            // Vector3(238.899994, 3.70000005, -110.5) car object
            // Vector3(0.319000542,0.131000042,-0.0229998231) menu
            // Vector3(0.319000006,0.131000042,-1.324) menu new


            red_btn.GetComponent<Image>().color = Color.white;
            blue_btn.GetComponent<Image>().color = Color.blue;
            green_btn.GetComponent<Image>().color = Color.white;

            butn_index = 1;
        }
        if (Input.GetKeyDown("space") || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && sceneStage <= 44)
        {

            if (sceneStage == 0)
            {
                //player.transform.position = positions[0].transform.position;
                // Enviro.transform.position = new Vector3 (0.189999998f, -1.63f, 10.0832739f);
                Enviro.SetActive(false);
                Enviro0.SetActive(true);
                Enviro1.SetActive(false);
                Enviro2.SetActive(false);
                Enviro3.SetActive(false);
                Enviro4.SetActive(false);
            }
            if (sceneStage >= 1 && sceneStage <= 8)
            {
                //player.transform.position = positions[1].transform.position;
                // Enviro.transform.position = new Vector3(-2.6500001f, -1.63f, 18.7600002f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(true);
                Enviro2.SetActive(false);
                Enviro3.SetActive(false);
                Enviro4.SetActive(false);
            }
            if (sceneStage >= 9 && sceneStage <= 31)
            {
                //player.transform.position = positions[2].transform.position;
                // Enviro.transform.position = new Vector3(-0.389999986f, -5.63000011f, 16.7999992f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(false);
                Enviro2.SetActive(true);
                Enviro3.SetActive(false);
                Enviro4.SetActive(false);
            }
            if (sceneStage >= 32 && sceneStage <= 43)
            {
                //player.transform.position = positions[3].transform.position;
                // Enviro.transform.position = new Vector3(-2.4000001f, -9.63000011f, 18.9400005f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(false);
                Enviro2.SetActive(false);
                Enviro3.SetActive(true);
                Enviro4.SetActive(false);
                // Unity_cam.SetActive(false);
                // VR_cam.SetActive(true);
                //player.transform.rotation = Quaternion.Euler(0, 210, 0);
            }
            if (sceneStage >= 43 && sceneStage <= 44)
            {
                //player.transform.position = positions[4].transform.position;
                // Enviro.transform.position = new Vector3(-101.300003f, -108.800003f, -5.9000001f);
                Enviro.SetActive(false);
                Enviro0.SetActive(false);
                Enviro1.SetActive(false);
                Enviro2.SetActive(false);
                Enviro3.SetActive(false);
                Enviro4.SetActive(true);
                // Unity_cam.SetActive(true);
                // VR_cam.SetActive(false);
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (opt_scenes.Contains(sceneStage))
            {
                butn_canvas.enabled = true;

                //print("AAAAAAAAAAAAAAAAAAAAAAAAAA____________" + sceneStage);

                /*
                soundclips[sceneStage+1] = PC_audio_resp[resp_index + butn_index];

                lines[sceneStage+1] = PC_resp[resp_index + butn_index];

                soundclips[sceneStage + 2] = Chad_audio_resp[resp_index + butn_index];

                lines[sceneStage + 2] = Chad_resp[resp_index + butn_index];
                */

                resp_index += 3;
            }
            else
            {
                butn_canvas.enabled = false;

            }

            print("space key was pressed");
            sceneTime = 10;

            audio.clip = soundclips[sceneStage];

            dialog.text = lines[sceneStage];

            audio.Play();

            sceneStage++;

            red_btn.GetComponent<Image>().color = Color.white;
            blue_btn.GetComponent<Image>().color = Color.blue;
            green_btn.GetComponent<Image>().color = Color.white;

            butn_index = 1;
        }

        if (sceneTime > 0)
            sceneTime -= Time.deltaTime * 2;
    }
}

/*
Update
    {
        
        if sceneStage is in array[contains scene numbers with choices]
        {
            enable dialogue options
            
        }
        resp_index(left loop thru 0 1 2)
        sceneStage(right++)
        {
            check if sceneStage is in array[contains scene numbers with location change]
            {
                Animation.play
                WaitforSeconds(Animation runtime)
                Transform.position =  new position
            }
            UI_Text and Audio = soundclips[sceneStage] lines[sceneStage]
            UI_Text.diplay
            Audio.play
        }
        
        
    }
    */
