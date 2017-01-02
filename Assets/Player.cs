using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

    public static int score = 0;
    public static Dictionary<int, List<int>> highScores = new Dictionary<int, List<int>>();
    public static int numberOfTries = 0;
}
