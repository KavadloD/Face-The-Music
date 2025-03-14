using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public Sprite ARank;
    public Sprite BRank;
    public Sprite CRank;
    public Sprite DRank;
    public Sprite FRank;
    private Sprite finalLetter;
    
    public int AScore;
    public int BScore;
    public int CScore;
    public int DScore;
    public int FScore;
    
    public TMP_Text perfectHits;
    public TMP_Text goodHits;
    public TMP_Text missHits;
    public TMP_Text finalScore;

    public GameObject perfectObj;
    public GameObject goodObj;
    public GameObject missObj;
    public GameObject finalScoreObj;
    public GameObject rankObj;
    
    public GameManager manager;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        perfectHits.text = manager.perfectCount.ToString();
        goodHits.text = manager.goodCount.ToString();
        missHits.text = manager.missCount.ToString();
        finalScore.text = manager.score.ToString();
        
        CalculateLetter();

        StartCoroutine(DisplayResults());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void CalculateLetter()
    {
        if (manager.score >= AScore)
        {
            print("A");
            finalLetter = ARank;
        }
        
        if (AScore > manager.score && manager.score >= BScore)
        {
            print("B");
            finalLetter = BRank;
        }
        
        if (BScore > manager.score && manager.score >= CScore)
        {
            print("C");
            finalLetter = CRank;
        }
        
        if (CScore > manager.score && manager.score >= DScore)
        {
            print("D");
            finalLetter = DRank;
        }
        
        if (manager.score < DScore)
        {
            print("F");
            finalLetter = FRank;
        }
        
        rankObj.GetComponent<Image>().sprite = finalLetter;
    }

    IEnumerator DisplayResults()
    {
        audioManager.VictorySFX();
        
        yield return new WaitForSeconds(1.5f);
        
        audioManager.ScoreSFX();
        perfectObj.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        
        audioManager.ScoreSFX();
        goodObj.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        
        audioManager.ScoreSFX();
        missObj.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        
        audioManager.ScoreSFX();
        finalScoreObj.SetActive(true);
        
        yield return new WaitForSeconds(0.7f);
        
        audioManager.RankSFX();
        rankObj.SetActive(true);
    }
}
