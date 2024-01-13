using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JawaTalk : MonoBehaviour {

    bool talkable = false;
    bool jawa4 = false;
    public GameObject image;
    public Text text;
    bool exitText = false;
    public static bool doorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("RainDance", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (talkable && Input.GetKeyDown(KeyCode.Z)) {
            StartCoroutine(jawaTalk());
            image.SetActive(true);
            
            talkable= false;
        }

        if (exitText && Input.GetKeyDown(KeyCode.Z)) { 
            image.SetActive(false);
            exitText = false;
        }

        if (jawa4 && Input.GetKeyDown(KeyCode.Z)) {
            text.text = "it seems the translator doesnt want to translate";
            jawa4= false;
            exitText= true;
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") { 
            talkable= true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            talkable= false;
            image.SetActive(false);
            exitText= false;
            jawa4= false;
            text.text = "???";
        }
    }

    IEnumerator jawaTalk() {

        text.text = "???";
        //Time.timeScale= 0;
        yield return new WaitForSeconds(1f);
        if(gameObject.name == "jawa4") 
        {
            jawa4 = true;
        }
        else
        {

            jawa4 = false;
            exitText = true;

        }
        if (gameObject.name == "jawa1")
        {
            text.text = "Search for the symbols weary traveller";
        }
        else if (gameObject.name == "jawa2")
        {
            if (doorOpen)
            {
                text.text = "Thanks for opening that ancient door! here ill teach you how to rain dance";
                StartCoroutine(learnedRaindance());
            }
            else
            {
                text.text = "have you heard of the Rain Dance, traveller?";
            }
        }
        else if (gameObject.name == "jawa3") {
            text.text = "welcome to our humble town traveller!";
        }
        else if (gameObject.name == "jawa4")
        {
            
            text.text = "what d yOU THINK YOURE DOING HERE YOU ???? ????? ???????????";
        }
    }

    IEnumerator learnedRaindance()
    {

        image.SetActive(true);
        text.text = "Learned Raindance";
        PlayerPrefs.SetInt("RainDance",1);
        yield return new WaitForSeconds(1f);
        image.SetActive(false);
    }
}
