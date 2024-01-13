using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int checkLoader=0;
    public GameObject sur1,sur2,sur3,cav1_1,cav1_2,cav1_3,cav2_1,cav2_2,cav2_3,cav3_1,cav3_2,cav3_3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkLoader==1) {
            Load_UnLoad();
            checkLoader = 0;
        }
    }

    void Load_UnLoad()
    {
        if (SwitchCamera.caveNum == 0)
        {
            LoadSurface();
        }
        else if (SwitchCamera.caveNum == 1)
        {
            LoadCrystal();

        }
        else if (SwitchCamera.caveNum == 2)
        {
            LoadLava();
        }
        else
        {
            LoadGreen();
        }
    }

void LoadSurface() { 
        sur1.SetActive(true);
        sur2.SetActive(true);
        sur3.SetActive(true);

        cav1_1.SetActive(false);
        cav1_2.SetActive(false);
        cav1_3.SetActive(false);
        
        cav2_1.SetActive(false);
        cav2_2.SetActive(false);
        cav2_3.SetActive(false);

        cav3_1.SetActive(false);
        cav3_2.SetActive(false);
        cav3_3.SetActive(false);
    }

    void LoadCrystal() {
        cav2_1.SetActive(false);
        cav2_2.SetActive(false);
        cav2_3.SetActive(false);

        cav3_1.SetActive(false);
        cav3_2.SetActive(false);
        cav3_3.SetActive(false);

        cav1_1.SetActive(true); 
        cav1_2.SetActive(true); 
        cav1_3.SetActive(true);

        sur1.SetActive(false);
        sur2.SetActive(false);
        sur3.SetActive(false);
    }

    void LoadGreen() {

        cav1_1.SetActive(false);
        cav1_2.SetActive(false);
        cav1_3.SetActive(false);

        cav2_1.SetActive(false);
        cav2_2.SetActive(false);
        cav2_3.SetActive(false);

        cav3_1.SetActive(true);
        cav3_2.SetActive(true);
        cav3_3.SetActive(true);

        sur1.SetActive(false);
        sur2.SetActive(false);
        sur3.SetActive(false);
    }

    void LoadLava(){
        cav1_1.SetActive(false);
        cav1_2.SetActive(false);
        cav1_3.SetActive(false);

        sur1.SetActive(false);
        sur2.SetActive(false);
        sur3.SetActive(false);

        cav3_1.SetActive(false);
        cav3_2.SetActive(false);
        cav3_3.SetActive(false);

        cav2_1.SetActive(true);
        cav2_2.SetActive(true);
        cav2_3.SetActive(true);
    }
        
    
}
