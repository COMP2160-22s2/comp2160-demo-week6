using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("No instance of GameManager in scene");
            }
            return instance;
        }
    }

    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text homeText;
    [SerializeField] private string livesFormat = "Lives left: {0}";
    [SerializeField] private string homeFormat = "Frogs home: {0}";

    [SerializeField] Transform frogPrefab;
    [SerializeField] Transform spawnPoint;
 
    private int lives = 3;
    private int home = 0;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of GameManager in scene.");
        }
    }

    void Start()
    {
        SpawnFrog();
    }

    void Update()
    {
        livesText.text = string.Format(livesFormat, lives);        
        homeText.text = string.Format(homeFormat, home);        
    }

    public void OnFrogDies()
    {
        lives--;
        if (lives > 0)
        {
            SpawnFrog();
        }
    }

    public void OnFrogHome()
    {
        home++;
        if (home < 4)
        {
            SpawnFrog();
        }
    }

    private void SpawnFrog()
    {
        Transform frog = Instantiate(frogPrefab);
        frog.position = spawnPoint.position;
    }
}
