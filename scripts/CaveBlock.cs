using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveBlock : MonoBehaviour
{
    public static bool breakable = false;
    public GameObject image;
    public Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("CaveUp", 0);
        //PlayerPrefs.GetInt("CaveDown", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "caveUpBlock")//Break Cave blocakage if broken with apt level pickaxe
            if (breakable && Input.GetKeyDown(KeyCode.LeftAlt) && PlayerPrefs.GetInt("Pickaxe", 0) == 2)
            {
                StartCoroutine(Break());

                breakable = false;
                PlayAudio.buttonPlay = true;
            }
            else if(breakable && Input.GetKeyDown(KeyCode.LeftAlt) && PlayerPrefs.GetInt("Pickaxe", 0) != 2 || breakable && Input.GetKeyDown(KeyCode.Z) && PlayerPrefs.GetInt("Pickaxe", 0) != 2) { 
                image.SetActive(true);
                prompt.text = "Your PickAxe is not levelled up enough to break this";
                PlayAudio.buttonPlay = true;

            }
            else if(breakable && Input.GetKeyDown(KeyCode.Z) && PlayerPrefs.GetInt("Pickaxe", 0) == 2)
            {
                image.SetActive(true);
                prompt.text = "Your PickAxe is levelled up enough to break this";
                PlayAudio.buttonPlay = true;
            }
        if (gameObject.name == "caveDownBlock")
            if (breakable && Input.GetKeyDown(KeyCode.LeftAlt) && PlayerPrefs.GetInt("Pickaxe", 0) == 1)
            {
                StartCoroutine(Break());
                breakable = false;
                PlayAudio.buttonPlay = true;
            }
            else if(breakable && Input.GetKeyDown(KeyCode.LeftAlt) && PlayerPrefs.GetInt("Pickaxe", 0) !=1 || breakable && Input.GetKeyDown(KeyCode.Z) && PlayerPrefs.GetInt("Pickaxe", 0) != 1) {
                image.SetActive(true);
                prompt.text = "Your PickAxe is not levelled up enough to break this";
                PlayAudio.buttonPlay = true;
            }
            else if (breakable && Input.GetKeyDown(KeyCode.Z) && PlayerPrefs.GetInt("Pickaxe", 0) == 1)
            {
                PlayAudio.buttonPlay = true;
                image.SetActive(true);
                prompt.text = "Your PickAxe is levelled up enough to break this";
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") {//player in breaking range
            breakable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            image.SetActive(false);//Off prompt
        }
    }
    IEnumerator Break(){

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);//Off blocking rock
    }
}
