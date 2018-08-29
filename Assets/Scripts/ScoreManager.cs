using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private static int score = 0;
    private static int highscore;
    private List<Sprite> scoreSprites;
    private List<GameObject> scorePrinted;

    // Origin coordinates of the first letter of the score
    public float scoreX;
    public float scoreY;
    public float highscoreX;
    public float highscoreY;

    // Print positions for score and highscore
    private GameObject firstLetterScore;
    private GameObject secondLetterScore;
    private GameObject thirdLetterScore;
    private GameObject fourthLetterScore;
    private GameObject fifthLetterScore;
    private GameObject sixthLetterScore;
    private GameObject firstLetterHighScore;
    private GameObject secondLetterHighScore;
    private GameObject thirdLetterHighScore;
    private GameObject fourthLetterHighScore;
    private GameObject fifthLetterHighScore;
    private GameObject sixthLetterHighScore;
    private GlobalControl globalControl;

    // All points constants details
    private int bricksPoints = 50;
    private int powerUpPoints = 1000;
    private int enemyPoints = 100;
        
    // All sprites for each numbers
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    public Sprite none;

    void Start () {
        globalControl = GameObject.Find("GlobalControl").GetComponent<GlobalControl>();
        score = globalControl.GetComponent<GlobalControl>().GetScore();
        highscore = 0;
        scorePrinted = new List<GameObject>();
        scoreSprites = new List<Sprite>();

        // Print current HighScore on screen
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        PrintHighScore();
        scorePrinted.Clear();
        scoreSprites.Clear();
        float tempX = scoreX;
        InstantiateLetters(firstLetterScore, tempX, scoreY, zero);
        tempX += none.rect.width;
        InstantiateLetters(secondLetterScore, tempX, scoreY, none);
        tempX += none.rect.width;
        InstantiateLetters(thirdLetterScore, tempX, scoreY, none);
        tempX += none.rect.width;
        InstantiateLetters(fourthLetterScore, tempX, scoreY, none);
        tempX += none.rect.width;
        InstantiateLetters(fifthLetterScore, tempX, scoreY, none);
        tempX += none.rect.width;
        InstantiateLetters(sixthLetterScore, tempX, scoreY, none);
        tempX += none.rect.width;
    }

    // Handle the graphic part of score changing here 
    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
        }

        FromIntToSprite(score);
        if (scoreSprites.Count <= scorePrinted.Count)
        {
            for (int i = 0; i < scoreSprites.Count; i++)
            {
               PrintLetter(scorePrinted.ElementAt(i),scoreSprites.ElementAt(i));
            }
        }
        else
        {
            Debug.Log("score limit reached");
        }
    }

    private void OnDestroy()
    {
        globalControl.SetScore(score);
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void updateScore(GameObject m_gameobject)
    {
        if (m_gameobject.tag == "Brick")
        {
            score += bricksPoints;
        }
        else if (m_gameobject.tag == "PowerUp")
        {
            score += powerUpPoints;
        }
        else if (m_gameobject.tag == "Enemy")
        {
            score += enemyPoints;
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void FromIntToSprite(int m_score)
    {
        List<int> scoreIntList = new List<int>();
        scoreSprites = new List<Sprite>();
        scoreIntList = m_score.ToString().Select(x => Convert.ToInt32(x.ToString())).ToList();
        foreach (int element in scoreIntList)
        {
            switch (element)
            {
                case 0:
                    scoreSprites.Add(zero);
                    break;
                case 1:
                    scoreSprites.Add(one);
                    break;
                case 2:
                    scoreSprites.Add(two);
                    break;
                case 3:
                    scoreSprites.Add(three);
                    break;
                case 4:
                    scoreSprites.Add(four);
                    break;
                case 5:
                    scoreSprites.Add(five);
                    break;
                case 6:
                    scoreSprites.Add(six);
                    break;
                case 7:
                    scoreSprites.Add(seven);
                    break;
                case 8:
                    scoreSprites.Add(eight);
                    break;
                case 9:
                    scoreSprites.Add(nine);
                    break;
                default:
                    scoreSprites.Add(none);
                    break;
            }
        }
    }

    private void PrintLetter(GameObject letter, Sprite sprite)
    {
        letter.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void InstantiateLetters(GameObject letter, float x, float y, Sprite sprite)
    {
        letter = new GameObject();
        letter.AddComponent<SpriteRenderer>();
        PrintLetter(letter, sprite);
        var temp = letter.GetComponent<Transform>().position;
        temp.x = x;
        temp.y = y;
        letter.GetComponent<Transform>().position = temp;
        scorePrinted.Add(letter);
    }

    private void PrintHighScore()
    {
        float tempX = highscoreX;
        FromIntToSprite(highscore);
        InstantiateLetters(firstLetterHighScore, tempX, highscoreY, scoreSprites.ElementAt(0));
        if (scoreSprites.Count > 1)
        {
            tempX += none.rect.width;
            InstantiateLetters(secondLetterHighScore, tempX, highscoreY, scoreSprites.ElementAt(1));
        }
        if (scoreSprites.Count > 2)
        {
            tempX += none.rect.width;
            InstantiateLetters(thirdLetterHighScore, tempX, highscoreY, scoreSprites.ElementAt(2));
        }
        if (scoreSprites.Count > 3)
        {
            tempX += none.rect.width;
            InstantiateLetters(fourthLetterHighScore, tempX, highscoreY, scoreSprites.ElementAt(3));
        }
        if (scoreSprites.Count > 4)
        {
            tempX += none.rect.width;
            InstantiateLetters(fifthLetterHighScore, tempX, highscoreY, scoreSprites.ElementAt(4));
        }
        if (scoreSprites.Count > 5)
        {
            tempX += none.rect.width;
            InstantiateLetters(sixthLetterHighScore, tempX, highscoreY, scoreSprites.ElementAt(5));
        }  
    }
}
