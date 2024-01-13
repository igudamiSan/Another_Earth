using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public static int Entered=0;
    public static int caveNum;
    public Camera cam1, cam2;
    Camera activeCam;
    public GameObject player;
    public static bool returnSurfaceRequest = false;
    public GameObject image,blankImage;
    public static bool onPlayerdeath = false;
    public AudioSource ambient;
    public AudioClip waterfall,ambience;
    
    // Start is called before the first frame update
    void Start()
    {
        activeCam = cam1;
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        BackToEntrance();
        if (Entered>0) {
            
            StartCoroutine(EnterCave(Entered));
            Entered = 0;
        }
        CamFollow();
    }
    public IEnumerator EnterCave(int sc) {
        blankImage.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blankImage.SetActive(false);
        Vector3 pos=Vector3.zero;
        if (sc == 1)
        {
            //CaveDown
            
            pos = new Vector3(135.59f, 55.34f, 0);
        }
        else if (sc == 2) {
            //CaveUp
            pos = new Vector3(-44.93f, 194.56f, 0);
        } else if (sc == 3) {
            //CaveLeft
            pos = new Vector3(-273.38f, 92.59f, 0);
        } else if (sc==4) {
            //WaterfallCave
            ambient.PlayOneShot(waterfall);
            pos = new Vector3(-19.07f, -107.2f, 0);
        }
        if (sc != 1) {
            ambient.PlayOneShot( ambience);
        }
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
        if (cam1.enabled)
        {
            
            player.transform.position = new Vector3(cam1.transform.position.x, cam1.transform.position.y-0.5f, 0);
            if (onPlayerdeath) {
                playerHealth.resetHp = true;
                onPlayerdeath=false;
            }
            activeCam = cam1;
            caveNum= 0;
            //Debug.Log("Cam1 on");
        }
        else
        {
            player.transform.position = pos;
            activeCam = cam2;
        }
        LevelLoader.checkLoader = 1;
        player.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        

            
    }


    void BackToEntrance() {
        if (returnSurfaceRequest && Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(EnterCave(1));
            returnSurfaceRequest = false;
            image.SetActive(false);
            Time.timeScale = 1;
        }
        else if (returnSurfaceRequest && Input.GetKeyDown(KeyCode.X)) {
            returnSurfaceRequest = false;
            image.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void CamFollow() {
        if (cam1.enabled)
            activeCam = cam1;
        else
            activeCam = cam2;

       activeCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, activeCam.transform.position.z);
    }
    
}
