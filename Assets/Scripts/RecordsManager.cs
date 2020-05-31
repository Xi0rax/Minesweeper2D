using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsManager : MonoBehaviour
{
   
    public Text HiScore;
    public Text Nick;
    public Text Rec;


    void Start()
    {
        Rec.text = Records.scores;
        Nick.text = Records.nickname;
        HiScore.text = Records.HighScore.ToString();
    }
}
