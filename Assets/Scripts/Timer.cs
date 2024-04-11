using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Start()
    {
        StartCoroutine(StartTime());
    }

    IEnumerator StartTime()
    {
        int showTime = 0;
        int second, minute;

        while (true)
        {
            showTime++;

            second = showTime % 60;
            minute = (showTime / 60) % 60;

            timerText.text = minute.ToString() + ":" + second.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
