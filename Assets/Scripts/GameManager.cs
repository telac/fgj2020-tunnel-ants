using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _happyScore = 0;
    private int _sadScore = 0;

    private Text _happyScoreText;
    private Text _angryScoreText;

    public static GameManager Instance = null;
    public RepairManager RepairManager;
    //public BlockSpawner BlockSpawner;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        _happyScoreText = GameObject.Find("happyText").GetComponent<Text>();
        _angryScoreText = GameObject.Find("angryText").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseScore() {
        _happyScore += 1;
        _happyScoreText.text = _happyScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
