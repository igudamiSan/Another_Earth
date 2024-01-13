using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen, controlScreen;
    bool pauseOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)&& !pauseOn) {

            if (pauseScreen.activeInHierarchy || controlScreen.activeInHierarchy)
            {
                pauseScreen.SetActive(false);
                controlScreen.SetActive(false);
                Time.timeScale = 1;
               
            }
            else
            {
                pauseScreen.SetActive(true);
                pauseOn = true;
                Time.timeScale = 0;
                pauseOn = false;
            }
            
        }
    }

    public void OnControlsPress() { 
        controlScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
}
