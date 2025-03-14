using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    
    //Outlets
    public Select mainMenuScr;
    
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;
    public GameObject levelOneBorder;
    public GameObject levelTwoBorder;
    public GameObject levelThreeBorder;

    public GameObject latidoSilo;
    public GameObject mobiSilo;
    public GameObject fifeSilo;

    public GameObject audioManager;

    //Tracking
    public bool onScreen;
    public int levelMenuPosition;

    private Vector3 oneStartPos;
    private Vector3 twoStartPos;
    private Vector3 threeStartPos;
    
    /*
     1 = Level 1
     2 = Level 2
     3  Level 3
     */
    
    // Start is called before the first frame update
    void Start()
    {
        onScreen = false;

        levelMenuPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (onScreen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                onScreen = false;
                levelMenuPosition = 0;

                mobiSilo.SetActive(false);
                fifeSilo.SetActive(false);
                latidoSilo.SetActive(false);
                
                mainMenuScr.inMainMenu = true;
                mainMenuScr.inLevelSelect = false;
                mainMenuScr.screenMoved = false;
                mainMenuScr.MoveScreensRight();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (levelMenuPosition == 3)
                {
                    levelMenuPosition = 1;
                }
                else
                {
                    levelMenuPosition += 1;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (levelMenuPosition == 1)
                {
                    levelMenuPosition = 3;
                }
                else
                {
                    levelMenuPosition -= 1;
                }
            }

            if (levelMenuPosition == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    audioManager.SetActive(false);
                    SceneManager.LoadScene("Level 1");
                }
                
                mobiSilo.SetActive(true);
                fifeSilo.SetActive(false);
                latidoSilo.SetActive(false);
                
                levelOneBorder.SetActive(true);
                levelTwoBorder.SetActive(false);
                levelThreeBorder.SetActive(false);
            }
            
            if (levelMenuPosition == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                { 
                    audioManager.SetActive(false);
                    SceneManager.LoadScene("Level 2");
                }
                
                mobiSilo.SetActive(false);
                fifeSilo.SetActive(true);
                latidoSilo.SetActive(false);
                
                levelOneBorder.SetActive(false);
                levelTwoBorder.SetActive(true);
                levelThreeBorder.SetActive(false);
            }
            
            if (levelMenuPosition == 3)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                { 
                    audioManager.SetActive(false);
                    SceneManager.LoadScene("Level 3");
                }

                
                mobiSilo.SetActive(false);
                fifeSilo.SetActive(false);
                latidoSilo.SetActive(true);
                
                levelOneBorder.SetActive(false);
                levelTwoBorder.SetActive(false);
                levelThreeBorder.SetActive(true);
            }
        }
    }

    public void ResetLevels()
    {
        levelOne.transform.position = oneStartPos;
        levelTwo.transform.position = twoStartPos;
        levelThree.transform.position = threeStartPos;
    }
}