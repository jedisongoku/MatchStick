using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    public int id;
    public enum circleColors { DarkPurple, Purple, Blue, LightBlue, Green, Red, Yellow };
    public circleColors circleColor;

    public void SetColor(string Color)
    {
        circleColor = (circleColors)System.Enum.Parse(typeof(circleColors), Color);
    }

    public string GetColor()
    {
        return circleColor.ToString();
    }
}
