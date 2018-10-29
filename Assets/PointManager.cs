using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

    public Text pointCountText;
    public Text scoredText;
    private int pointCount = 0;

	// Use this for initialization
	private void Start () {
        scoredText.enabled = false;
	}
	
	public void AddPoints(int points)
    {
        pointCount += points;
        if(points == 1)
        {
            scoredText.text = "Scored " + points + " point!";
        }else
        {
            scoredText.text = "Scored " + points + " points!";
        }
        pointCountText.text = "Points: " + pointCount;

        StartCoroutine("ShowScoredPoints");
    }

    private IEnumerator ShowScoredPoints()
    {
        scoredText.enabled = true;
        yield return new WaitForSeconds(2);
        scoredText.enabled = false;
    }
}
