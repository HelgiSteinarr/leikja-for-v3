using System.Collections.Generic;
using UnityEngine;

public class PointAdder : MonoBehaviour {

    public int pointAmount;  // Svo hægt er að breyta stigafjölda hvert target gefur innan editorsins
    public GameObject pointManager;
    private List<int> arrowIds = new List<int>();  // Örvar sem hafa snert skotmarkið áður

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arrow")
        {
            var arrowId = other.transform.GetComponent<arrow>().arrowId();
            if (!arrowIds.Contains(arrowId))
            {
                pointManager.GetComponent<PointManager>().AddPoints(pointAmount);
                arrowIds.Add(arrowId);
            }
        }
    }

}
