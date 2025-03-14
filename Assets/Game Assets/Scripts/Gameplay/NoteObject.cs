using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //Interact
    public bool inRange;
    public KeyCode keyToPress;

    //Scrolling
    public float tempo;
    public GameManager gameManager;

    //Outlets
    private Transform _trans;
    public SpriteRenderer spriteRenderer;
    private Light noteLight;

    private GameObject playerCol;
    private Scoring scoreScr;

    //Tracking
    public float noteRot;
    
    //Scoring
    private int playerLane;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        noteLight = GetComponent<Light>();
        _trans = GetComponent<Transform>();

        playerCol = GameObject.Find("Player_Collisions");
        scoreScr = playerCol.GetComponent<Scoring>();

        tempo = (gameManager.beatTempo)/60f;

        _trans.Rotate(noteRot, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (inRange)
            {
                calculateScore(Vector3.Distance(transform.position, playerCol.transform.position));
                
                spriteRenderer.enabled = false;
                noteLight.enabled = false;
                //noteCol.enabled = false;
            }
        }

        //Scrolls
        _trans.position -= new Vector3(0f, tempo * Time.deltaTime,0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            inRange = true;
        }
        
        if (other.tag == "Despawn")
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            inRange = false;
        }
    }
    
    //Calculates what to rate each note (Good or perfect)
    private void calculateScore(float distance)
    {
        if(distance is >= 0.40f and <= 0.70f)
        {
            scoreScr.Perfect();
        }
        else
        {
            scoreScr.Good();
        }
    }
}
