using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Animations
    private Animator shield_Animator;
    private Animator sword_Animator;
    
    //Controls
    public KeyCode shield;
    public KeyCode sword;
    
    //Stores how far player moved left and right
    public int playerPosition;

    
    //Outlets
    public AudioManager audioManager;
    private GameObject obj_Shield;
    private GameObject obj_Sword;
    
    
    // Start is called before the first frame update
    void Start()
    {
        obj_Shield = this.transform.GetChild(0).gameObject;
        obj_Sword = this.transform.GetChild(1).gameObject;

        shield_Animator = obj_Shield.GetComponent<Animator>();
        sword_Animator = obj_Sword.GetComponent<Animator>();

        playerPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        if (Input.GetKeyDown(shield))
        {
            shield_Animator.SetTrigger("isBlocking");

        }

        if (Input.GetKeyDown(sword))
        {
            sword_Animator.SetTrigger("isAttacking");
        }
        

        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerPosition != -1)
        {
            transform.position += new Vector3(-1.05f,0,0);
            playerPosition -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerPosition != 1)
        {
            transform.position += new Vector3(1.05f,0,0);

            playerPosition += 1;
        }
        
    }
}
