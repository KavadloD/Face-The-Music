using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Select : MonoBehaviour
{
    //Main Menu
    public KeyCode up;
    public KeyCode down;

    public int menuPosition;

    public bool inMainMenu;
    public bool inOptionMenu;
    public bool inLevelSelect;

    //Option Menu
    public int optionMenuPosition;
    public GameObject optionMenuObj;

    public GameObject mainMenuObj;
    public GameObject levelMenuObj;
    
    public ObjectMover mainMenuScr;
    public ObjectMover levelMenuScr;

    public GameObject musicBorder;
    public GameObject sfxBorder;
    
    public Slider mSlider;
    public Slider sSlider;

    //Level Menu
    public bool screenMoved;
    public LevelSelector levelSelectorScr;
    
    //FMOD
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;

    public float MusicVolume = 0.4f;
    public float SFXVolume = 0.4f;

    public float maxVol = 1f;
    public float minVol = 0f;


    private RectTransform _rectTrans;
    //public Vector3 transform.position;
    
    /*
     Positions for the selector
     0 = Play
     1 = menuPositions
     2 = Quit
     */
    
    // Start is called before the first frame update
    void Awake()
    {
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        
    }

    void Start()
    {
        menuPosition = 0;
        inMainMenu = true;
        optionMenuObj.SetActive(false);
        musicBorder.SetActive(false);
        sfxBorder.SetActive(false);
        
        sSlider.maxValue = 0.9f;
        sSlider.minValue = 0.1f;

        _rectTrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //FMOD
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);

        mSlider.value = MusicVolume;
        sSlider.value = SFXVolume;
        
        if (inMainMenu)
        {
            if (Input.GetKeyDown(up))
            {
                if (menuPosition == 0)
                {
                    menuPosition = 2;
                    _rectTrans.anchoredPosition += new Vector2(0, -200);
                }
                else
                {
                    menuPosition -= 1;
                    _rectTrans.anchoredPosition += new Vector2(0, 100);
                }
            }
                 
            if (Input.GetKeyDown(down))
            {
                if (menuPosition == 2)
                {
                    menuPosition = 0;
                    _rectTrans.anchoredPosition += new Vector2(0, 200);
                }
                else
                {
                    menuPosition += 1;
                    _rectTrans.anchoredPosition += new Vector2(0, -100);
                }
            }
         
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (menuPosition == 0)
                {
                    inOptionMenu = false;
                    inMainMenu = false;
                    inLevelSelect = true;
                }
                else if (menuPosition == 1)
                {
                    inOptionMenu = true;
                    inMainMenu = false;
                }
                else
                {
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    #else
                         Application.Quit();
                    #endif
                }
            }
        }

        if (inOptionMenu)
        {
            optionMenuObj.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionMenuObj.SetActive(false);
                inOptionMenu = false;
                inMainMenu = true;
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (optionMenuPosition == 1)
                {
                    optionMenuPosition = 0;
                }
                else
                {
                    optionMenuPosition = 1;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (optionMenuPosition == 0)
                {
                    optionMenuPosition = 1;
                }
                else
                {
                    optionMenuPosition = 0;
                }
            }
            
            if (optionMenuPosition == 0)
            {
                sfxBorder.SetActive(false);
                musicBorder.SetActive(true);
                
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    MusicVolume -= 0.10f;

                    if (MusicVolume < minVol)
                    {
                        MusicVolume = minVol;
                    }
                }
            
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    MusicVolume += 0.10f;
                    
                    if (MusicVolume > maxVol)
                    {
                        MusicVolume = maxVol;
                    }
                }
            }
            
            if (optionMenuPosition == 1)
            {
                sfxBorder.SetActive(true);
                musicBorder.SetActive(false);
                
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    SFXVolume -= 0.10f;
                    
                    if (SFXVolume < minVol)
                    {
                        SFXVolume = minVol;
                    }
                }
            
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    SFXVolume += 0.10f;
                    
                    if (SFXVolume > maxVol)
                    {
                        SFXVolume = maxVol;
                    }
                }
            }
        }

        if (inLevelSelect)
        {
            if (!screenMoved)
            {
                MoveScreensLeft();
                screenMoved = true;
                StartCoroutine(WaitForScreen());
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void MoveScreensLeft()
    {
        mainMenuScr.MoveObjectOverTime(mainMenuObj.transform, -Screen.width, 0.3f);
        levelMenuScr.MoveObjectOverTime(levelMenuObj.transform, -Screen.width, 0.3f);
    }
    
    public void MoveScreensRight()
    {
        mainMenuScr.MoveObjectOverTime(mainMenuObj.transform, Screen.width, 0.3f);
        levelMenuScr.MoveObjectOverTime(levelMenuObj.transform, Screen.width, 0.3f);
    }

    IEnumerator WaitForScreen()
    {
        yield return new WaitForSeconds(0.3f);
        
        levelSelectorScr.onScreen = true;
        levelSelectorScr.levelMenuPosition = 1;
    }
}
