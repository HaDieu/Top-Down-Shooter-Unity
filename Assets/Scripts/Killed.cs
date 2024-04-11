using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Killed : MonoBehaviour
{
    public TextMeshProUGUI killedText;
    int currnentKilled = 0;
    public void UpdateKill(int score)
    {
        currnentKilled += score;
        killedText.text = currnentKilled.ToString();
    }
}
