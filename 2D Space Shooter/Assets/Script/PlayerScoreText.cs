using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreText : MonoBehaviour
{
    // Use this line of Code ONLY IF THE TEXT EDITOR IS THE OLD ONE/ NOT TEXT MESH PRO
    
    Text score;
    public string nameText;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        score.text = PlayerPrefs.GetInt(nameText)+"";
    }
}
