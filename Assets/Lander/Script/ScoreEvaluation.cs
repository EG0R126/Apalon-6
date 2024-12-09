using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreEvaluation : MonoBehaviour {
       
    
    public Text ScoreText;
    
   

    // Update is called once per frame
    void Update ()
    {        
        GlobalData.GlobalDataCarrier.Score += (int)( Math.Round(Time.deltaTime*100));        
        ScoreText.text = ("Score : " + GlobalData.GlobalDataCarrier.Score.ToString());
    }
}
