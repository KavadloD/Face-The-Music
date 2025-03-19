using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Setup and timing
    public bool hasStarted;
    public bool hasEnded;
    
    public float beatTempo;
    public float songTimer;
    public float songLength;
    public int positionInList;
    public float offsetTiming;
    
    public List<float> spawnTimings = new List<float>();

    public GameObject startScreen;

    public string filePath;
    public string leveltxt;

    //Spawning
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;

    private Vector3 spawnPoint;

    public GameObject swordPrefab;
    public GameObject shieldPrefab;
    
    //Audio
    public AudioManager audioManager;

    //Scoring
    public int score;
    public TMP_Text TextComponent;

    public Slider progressMeter;
    public int progressMeterMaxValue;

    public int perfectCount;
    public int goodCount;
    public int missCount;

    public GameObject victoryOverlay;

    // Start is called before the first frame update
    void Start()
    {
        filePath = System.IO.Path.Combine(Application.streamingAssetsPath, leveltxt); // Change per level
        Debug.Log("Loading file from: " + filePath);
        
        readTextFile(filePath);

        spawner1 = transform.GetChild(0).gameObject;
        spawner2 = transform.GetChild(1).gameObject;
        spawner3 = transform.GetChild(2).gameObject;

        score = 0;

        progressMeter.maxValue = progressMeterMaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player has started the game
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
                audioManager.PlayMusic();
                startScreen.SetActive(false);
            }
        }
        else if (hasEnded)
        {
            audioManager.StopMusic();
            victoryOverlay.SetActive(true);
        }
        else
        {
            //In charge of spawning notes at the right time
            songTimer += Time.deltaTime;

            progressMeter.value += Time.deltaTime;
            
            if ((spawnTimings[positionInList] - offsetTiming) <= songTimer && positionInList < spawnTimings.Count - 1) 
            {
                SpawnNote();
                
                positionInList += 1;
            }
            
            TextComponent.text = score.ToString();
            
            //Reset level
            if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
            {
                audioManager.StopMusic();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
            //Quit to menu
            if (Input.GetKeyDown(KeyCode.Escape) && Input.GetKey(KeyCode.LeftShift))
            {
                audioManager.StopMusic();
                SceneManager.LoadScene("Menu");
            }
        }

        if (songTimer >= songLength)
        {
            hasEnded = true;
        }
    }

    //Calculates where and which note to spawn
    private void SpawnNote()
    {
        int randomSpawnPoint = Random.Range(0, 3);
        
        int randomEnemy = Random.Range(0, 2);

        //Picks a random lane to spawn
        if (randomSpawnPoint == 0)
        {
            spawnPoint = spawner1.transform.position;
        }
        else if (randomSpawnPoint == 1)
        {
            spawnPoint = spawner2.transform.position;
        }
        else
        {
            spawnPoint = spawner3.transform.position;
        }

        //Picks a random enemy to spawn
        if (randomEnemy == 0)
        {
            Instantiate(swordPrefab, spawnPoint, Quaternion.identity);
        }
        else
        {
            Instantiate(shieldPrefab, spawnPoint, Quaternion.identity);
        }
    }
    
    //Turns file into notes
    void readTextFile(string file)
    {

        StreamReader inp_stm = new StreamReader(file);

        while(!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine( );
            
            float numberToAdd = float.Parse(inp_ln);
            
            spawnTimings.Add(numberToAdd);
        }

        inp_stm.Close( );  
    }
}