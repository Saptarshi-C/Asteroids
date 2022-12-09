using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays text on the HUD canvas
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    float elapsedSeconds = 0;
    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedSeconds += Time.deltaTime;
            scoreText.text = ((int)elapsedSeconds).ToString();
        }
    }

    public void StopGameTimer()
    {
        isRunning = false;
    }
}
