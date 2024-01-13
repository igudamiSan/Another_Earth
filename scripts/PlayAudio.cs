using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource ButtonSound,DoorSound,lavaSound,IceSound;
    public AudioClip click,door,lava,ice;
    public static bool buttonPlay = false, DoorPlay = false, LavaPlay,IcePlay;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DoorPlay) {
            doorClick();
            DoorPlay= false;
        }
        if (buttonPlay)
        {
            ButtonClick();
            buttonPlay = true;
        }
        if (LavaPlay) {

            lavaScream();
            LavaPlay= false;
        }
        if (IcePlay) {
            iceScream();
            IcePlay= false;
        }
    }
    public void ButtonClick()
    {
        ButtonSound.PlayOneShot(click);
    }

    void doorClick() {
        DoorSound.PlayOneShot(door);
    }

    void lavaScream()
    {
        lavaSound.PlayOneShot(lava);
    }

    void iceScream() {
        IceSound.PlayOneShot(ice);
    }
}
