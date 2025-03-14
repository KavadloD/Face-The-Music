using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    //Outlets
    private PlayerController playerScr;
    private GameManager gameManager;
    private GameObject obj_Canvas;
    
    public GameObject goodObj;
    public GameObject perfectObj;
    public GameObject missObj;
    private GameObject scoreObj;

    private int scoreNumber;

    //Tracking
    public Vector3 scoreSpawn;
    private bool minionInRange;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        obj_Canvas = GameObject.Find("Canvas");
        playerScr = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
        {
            SetSpawnPos();
            
            if (!minionInRange)
            {
                Instantiate(missObj, scoreSpawn, Quaternion.identity, obj_Canvas.transform);
                gameManager.score -= 1;
                gameManager.missCount += 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Minion")
        {
            minionInRange = true;
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Minion")
        {
            minionInRange = false;
        }

    }

    public void SetSpawnPos()
    {
        int spawnPosition = playerScr.playerPosition;
        
        if (spawnPosition == -1)
        {
            scoreSpawn = obj_Canvas.transform.position - new Vector3(200f, 200f, 0);
        }

        if (spawnPosition == 0)
        {
            scoreSpawn = obj_Canvas.transform.position - new Vector3(0f, 200f, 0);
        }

        if (spawnPosition == 1)
        {
            scoreSpawn = obj_Canvas.transform.position - new Vector3(-200f, 200f, 0);
        }
    }
    
    public void Perfect()
    {
        Instantiate(perfectObj, scoreSpawn, Quaternion.identity, obj_Canvas.transform);
        gameManager.score += 3;
        gameManager.perfectCount += 1;
    }
    
    public void Good()
    {
        Instantiate(goodObj, scoreSpawn, Quaternion.identity, obj_Canvas.transform);
        gameManager.score += 1;
        gameManager.goodCount += 1;
    }
}
