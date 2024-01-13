using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SpaceShipDeposit : MonoBehaviour
{
    public GameObject SpaceshipHUD, BC1, BC2, BC3, Al, Gu, Da;
    public GameObject BC11, BC21, BC31, Al1, Gu1, Da1,prompt;
    public Image pickaxe;
    public Text promptText;
    public Sprite pick1, pick2, pick3,playerPick1,playerPick2,pick4;
    public SpriteRenderer sr;
    public static bool callOnDeath = false, onGetAl = false,onGetGun=false,onGetKo=false;
    public Text Objective;
    public GameObject caveBlock1, caveBlock2,Boss,BossImage,PlayerImg,player,blackScreen;
    public static bool daddyiumGot = false, gameReset = false;
    bool finalChoice=false;
    char choice;
    public AudioSource As;
    public AudioClip kling;
    public GameObject credits,startscreen;

    bool promptWait = false;
    bool promptWaitDone = false;
    bool bossCaveEnterPart = false;
    bool bossCaveEnter = true;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Credits());
        //PlayerPrefs.SetInt("GameStart", 1);
        //ONLY FOR TESTING
        //TILL HERE
        //---------

        //Initialize Deposited items variables
        PlayerPrefs.GetInt("Pickaxe", 0);
        PlayerPrefs.GetInt("BlackCrystal1", 0);
        PlayerPrefs.GetInt("BlackCrystal2", 0);
        PlayerPrefs.GetInt("BlackCrystal3", 0);
        PlayerPrefs.GetInt("Aloshium", 0);
        PlayerPrefs.GetInt("Gundamium", 0);
        PlayerPrefs.GetInt("Daddyium", 0);
        resetStage();
        
    }
    void resetStage() {
        if (PlayerPrefs.GetInt("Pickaxe", 0) == 0)
        {
            pickaxe.sprite = pick1;
            sr.sprite = playerPick1;
        }
        
        if (PlayerPrefs.GetInt("BlackCrystal1", 0) == 0)
        {
            BC1.SetActive(true);
        }
        else
        {
            BC11.SetActive(true);
        }
        if (PlayerPrefs.GetInt("BlackCrystal2", 0) == 0)
        {
            BC2.SetActive(true);
        }
        else
        {
            BC21.SetActive(true);
        }
        if (PlayerPrefs.GetInt("BlackCrystal3", 0) == 0)
        {
            BC3.SetActive(true);
        }
        else
        {
            BC31.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Aloshium", 0) == 0)
        {
            Al.SetActive(true);

        }
        else
        {
            Al1.SetActive(true);
            pickaxe.sprite = pick2;
            sr.sprite = playerPick2;
            PlayerPrefs.SetInt("Pickaxe",1);

        }
        if (PlayerPrefs.GetInt("Gundamium", 0) == 0)
        {
            Gu.SetActive(true);
        }
        else
        {
            Gu1.SetActive(true);
            pickaxe.sprite = pick3;
            sr.sprite = pick3;
            PlayerPrefs.SetInt("Pickaxe", 2);
        }
        if (PlayerPrefs.GetInt("Daddyium", 0) == 0)
        {
            Da.SetActive(true);
        }
        else
        {
            Da1.SetActive(true);
        }
        DoomSlayerCheck();
    } //Used for resetting items after death
    void resetGame() {
        PlayerPrefs.SetInt("BlackCrystal1", 0);
        PlayerPrefs.SetInt("BlackCrystal2", 0);
        PlayerPrefs.SetInt("BlackCrystal3", 0);
        PlayerPrefs.SetInt("Aloshium", 0);
        PlayerPrefs.SetInt("Gundamium", 0);
        PlayerPrefs.SetInt("Daddyium", 0);
        PlayerPrefs.SetInt("Pickaxe", 0);
        PlayerPrefs.SetInt("GameStart", 0);

        //PlayerPrefs.SetInt("CaveUp", 0);
        //PlayerPrefs.SetInt("CaveDown", 0);
        caveBlock1.SetActive(true);
        caveBlock2.SetActive(true);
    }//Resets all items in world and block caves for new game

    void playKling() { 
        As.PlayOneShot(kling);
    }//Sound Cue On deposit

    // Update is called once per frame
    void Update()
    {
        if (gameReset) {//New Game Check
            resetGame();
            gameReset= false;
        }
        if (daddyiumGot) {//Got red crystal
            PlayerImg.SetActive(true);//Visual Cue of player in future going underground
            daddyiumGot= false;
        }

        //Final Choices efore boss fight
        if (promptWait && Input.GetKeyDown(KeyCode.Z) && !finalChoice)
        {
            print("pressedZ");
            promptWaitDone = true;
            promptWait = false;
            PlayAudio.buttonPlay = true;
        }
        else if (promptWait && Input.GetKeyDown(KeyCode.Z) && finalChoice)
        {
            choice = 'Z';
            finalChoice = false;
            promptWaitDone = true;
            promptWait = false;
            PlayAudio.buttonPlay = true;
        }
        else if (promptWait && Input.GetKeyDown(KeyCode.X) && finalChoice)
        {
            choice = 'X';
            finalChoice = false;
            promptWaitDone = true;
            promptWait = false;
            PlayAudio.buttonPlay = true;
        }
        else if (promptWait && Input.GetKeyDown(KeyCode.C) && finalChoice && PlayerPrefs.GetInt("RainDance", 0) == 1)
        {
            choice = 'C';
            finalChoice = false;
            promptWaitDone = true;
            promptWait = false;
            PlayAudio.buttonPlay = true;
        }
        else if (promptWait && Input.GetKeyDown(KeyCode.C) && finalChoice && PlayerPrefs.GetInt("RainDance", 0) == 2) {
            choice = 'V';
            finalChoice = false;
            promptWaitDone = true;
            promptWait = false;
            PlayAudio.buttonPlay = true;
        }
            if (promptWait && Input.GetKeyDown(KeyCode.X) && bossCaveEnterPart) {
            bossCaveEnter = false;
            PlayAudio.buttonPlay = true;
        }
        if (callOnDeath) {
            resetStage();
            SwitchCamera.Entered = 1;
            callOnDeath= false;
            playerHealth.resetHp = true;
        }

        //Set Objective
        if (onGetAl) {
            Objective.text = "return Aloshium to SpaceShip";
            onGetAl = false;
        }
        if (onGetGun) {
            Objective.text = "return Gundamium to SpaceShip";
            onGetGun = false;
        }
        if(onGetKo)
        {
            Objective.text = "return Daddyium to SpaceShip";
            onGetKo = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            StartCoroutine(PutInSpaceShip());
        }
        if (PlayerPrefs.GetInt("Daddyium", 0) == 1 && choice == 'Z') {
            SwitchCamera.Entered = 4;
        }

    }

    IEnumerator PutInSpaceShip(){
        playerHealth.resetHp = true;
        SpaceshipHUD.SetActive(true);
        foreach (string item in Inventory.Items)
        {
            if (item == "BlackCrystal1")
            {
                PlayerPrefs.SetInt("BlackCrystal1", 1);
                yield return new WaitForSeconds(2);
                playKling();
                BC11.SetActive(true);
                DoomSlayerCheck();
                resetStage();
            }
            else if (item == "BlackCrystal2")
            {
                PlayerPrefs.SetInt("BlackCrystal2", 1);
                yield return new WaitForSeconds(2);
                playKling();

                BC21.SetActive(true);
                DoomSlayerCheck();
                resetStage();
            }
            else if (item == "BlackCrystal3")
            {
                PlayerPrefs.SetInt("BlackCrystal3", 1);
                yield return new WaitForSeconds(2);
                playKling();

                BC31.SetActive(true);
                DoomSlayerCheck();
                resetStage();
            }
            else if (item == "Aloshium")
            {
                PlayerPrefs.SetInt("Aloshium", 1);
                yield return new WaitForSeconds(1);
                playKling();

                Al1.SetActive(true);
                PlayerPrefs.SetInt("Pickaxe", 1);
                StartCoroutine(pickaxeUpgraded());
                resetStage();
                Objective.text = "Find element in SouthEast cave";

            }
            else if (item == "Gundamium")
            {
                PlayerPrefs.SetInt("Gundamium", 1);
                playKling();

                yield return new WaitForSeconds(1);
                Gu1.SetActive(true);
                PlayerPrefs.SetInt("Pickaxe", 2);
                StartCoroutine(pickaxeUpgraded());
                resetStage();
                Objective.text = "Find element in NorthEast cave";

            }
            else if (item == "Daddyium")
            {
                PlayerPrefs.SetInt("Daddyium", 1);
                playKling();

                yield return new WaitForSeconds(1);
                Da1.SetActive(true);
                Objective.text = "Go Back Home";

                //spaceship rebuilt
            }
        }
        Inventory.Items = new string[10];
        Inventory.clearInventory = true;
    }

    void DoomSlayerCheck()
    {
        if (PlayerPrefs.GetInt("BlackCrystal3", 0) == 1 && PlayerPrefs.GetInt("BlackCrystal2", 0) == 1 && PlayerPrefs.GetInt("BlackCrystal1", 0) == 1)//pickaxe final level
        {
            PlayerPrefs.SetInt("Pickaxe", 3);
            StartCoroutine(pickaxeUpgraded());
        }
    }

    IEnumerator pickaxeUpgraded() {
        prompt.SetActive(true);
        promptText.text = "PICKAXE UPGRADED";
        yield return new WaitForSeconds(1);
        prompt.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SpaceshipHUD.SetActive(false);
        if (PlayerPrefs.GetInt("Daddyium", 0) == 1 && choice!='Z') { //Go to fight boss
                StartCoroutine(WaterfallEntry());
           
        } 
    }

    IEnumerator WaterfallEntry() {
        print("not entererd");
        //prompts after returning all elements
        Movement.playerStationary1= true;
        prompt.SetActive(true);
        promptText.text = "Rebuilt SpaceShip";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(()=> promptWaitDone==true);
        promptWaitDone = false;

        promptText.text = "The sand under the SpaceShip seems to be wet";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "It seems another cavern has opened up with the crash of the spaceship";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "The sand is wet from this small waterfall under there";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "Explore New Cave?(Z/X)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;
        if (bossCaveEnter)
        {
            StartCoroutine(inBossCave());
        }
        else {
            promptText.text = "Are u sure u want to go back home?(Z/X)";
            promptWait = true;
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => promptWaitDone == true);
            promptWaitDone = false;
            if (bossCaveEnter)
            {
                StartCoroutine(inBossCave());
            }
            else {
                prompt.SetActive(false);
                GameEnd(0);
            }
        }
        yield return new WaitForSeconds(1); 
    }

    void GameEnd(int n) {
        if (n == 0) {
            //Player Goes back in Spaceship
        }    
    }

    IEnumerator inBossCave() {//Conversation with boss
        print("in cave");
        prompt.SetActive(false);
        SwitchCamera.Entered = 4;
        Movement.cutscene = true;
        Movement.playerStationary1 = false;

        yield return new WaitForSeconds(1);
        BossImage.SetActive(true);
        /*player.transform.position= new Vector3(-38.3f, -107.2f, 0);
        yield return new WaitForSeconds(1);
        player.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(100 * Time.deltaTime, 0);
        if (player.transform.position.x <=19.07f)
        {
            print("moving player");
            player.transform.GetComponent<Rigidbody2D>().velocity = new Vector2( 100* Time.deltaTime,0);
            //player.transform.Translate(new Vector2(1,0));
            yield return null;
            
        }
        player.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        */
        prompt.SetActive(true);
        
        promptText.text = "You! Why do you kinda look like me? and I think I saw myself near the ship just now!?(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "???: I know you have many questions(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "Stay? The entire crew is dead on this godforsaken planet and you want me to stay???!(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;
        
        promptText.text = "Boss : It’s a lot to take in, but it’s for the safety of our kind. No matter how hard you defend yourself, in time, you will become me.(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;
        
        promptText.text = " What?(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss : All those aliens you met earlier; they were once humans. Sent decades ago, here to colonize Capsid, in the hopes of starting humanity anew.(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss : Capsid is everything Earth is and more. Oxygen, water, temperature… it’s all here. Except for one anomaly the pioneers failed to see. The infection.(Z) ";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss : The only living organism on this planet whose nature is to engulf any other life form and wholly take over all its functions. Slowly, they became creatures with only one drive: to survive.(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " You mean I’m… infected?(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss: The moment you took off your helmet, you were infected. It’s growing inside me and you.(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " But how are you… me?(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss : Time here is like a river. Water flows in layers, each layer having a different speed. It’s slower on the surface. It gets faster as we go down. Capsid’s sun is not a sun. It’s tidally locked with a whitehole that resets each day. And each layer has different dayspans.(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss : On the surface its 18 minutes, go one layer down its an hour, then 17 hours, 3 days, months, years… you could expect the core to be millenias old. There’s probably another version of you up there, trying to figure out what’s going on.(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "Why did you stay here? The ship can be fixed, why didn’t you leave, go back to Earth?(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " Boss: The infection. Do you really want to destroy an entire species, if not the entire biome of life on Earth? What would you do if I were you?(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = " you must either stay in Capsid or die by my hands. The choice is yours(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        print("choice start");
        prompt.SetActive(true);
        if (PlayerPrefs.GetInt("RainDance", 0) == 1)
        {
            promptText.text = "1.Fight Boss(Z)\n2.Stay with Boss(X)\n3.Raindance(C)";
        }
        else
        {
            promptText.text = "1.Fight Boss(Z)\n2.Stay with Boss(X)";
        }

        finalChoice = true;


        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        if (choice == 'Z')
        {
            promptText.text = "Boss: If u want a fight thats what ull get!(Z)";
            promptWait = true;
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => promptWaitDone == true);
            promptWaitDone = false;
            prompt.SetActive(false);
            BossImage.SetActive(false);
            Boss.SetActive(true);
            Movement.cutscene = false;

            
            yield return new WaitUntil(() => BossMove.dead == true);
            yield return new WaitForSeconds(2f);
            prompt.SetActive(true);
            blackScreen.SetActive(true);
            promptText.text = "You deafeated the boss but ended up becoming the infected boss in Capsid";
            promptWait = true;
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => promptWaitDone == true);
            promptWaitDone = false;
            StartCoroutine(Credits());
            // credits
        }
        else if (choice == 'X')
        {
            blackScreen.SetActive(true);
            promptText.text = "You stay with the boss and ended up becoming the new infected boss in Capsid";
            promptWait = true;
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => promptWaitDone == true);
            promptWaitDone = false;

            prompt.SetActive(false);
            StartCoroutine(Credits());
            //credits
        }
        else if (choice == 'C')
        {
            blackScreen.SetActive(true);
            promptText.text = "You return back home fleeing from the infected boss in Capsid while he was preoccupied with accompanying you in a raindance";
            PlayerPrefs.SetInt("RainDance", 2);
            prompt.SetActive(false);
            StartCoroutine(Credits());
        }
        else if (choice == 'V') {
            blackScreen.SetActive(true);
            promptText.text = "The boss pretends to rainDance and the moment you left your guard down u are slain. As you die you hear 'poor child ive seen that trick once enough'";
            PlayerPrefs.SetInt("RainDance", 2);
            prompt.SetActive(false);
            StartCoroutine(Credits());
        }
    }

    IEnumerator Credits() {
        credits.SetActive(true);
        yield return new WaitForSeconds(59);
        credits.SetActive(false);
        resetGame();
        startscreen.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        resetStage();
    }

}
