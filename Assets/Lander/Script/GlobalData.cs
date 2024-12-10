using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour {

    public Text HighScoreText;

    void Start()
    {     
            
    }


    public static class GlobalDataCarrier
    {
        public static int Score;
        public static int Lives;
        public static int Level;
        public static float Fuel;
        public static bool FirstRun;
        public static bool isCrashed;
        public static bool LandedStatus;
        public static bool LandedStatusOk;
        public static bool LandedLeft;
        public static bool LandedRight;
        public static bool StateMusiic;

    }
}
