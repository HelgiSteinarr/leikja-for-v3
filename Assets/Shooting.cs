using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    public GameObject arrowPrefab;
    public float baseForce = 100;
    public float pullSpeed = 2;
    public LineRenderer lineRenderer;
    public Text reloadText;

    private bool loaded = false;
    private float pullAmount = 0.0f;
    private Transform arrow;
    private int currentArrowNum = 0;

    private Vector3 bowStringPointPosLoaded;
    private Vector3 bowStringPointPosUnloaded;

    private void Start()
    {
        bowStringPointPosLoaded = lineRenderer.GetPosition(1);
        bowStringPointPosUnloaded = lineRenderer.GetPosition(1) + new Vector3(0.2f, 0.2f, 0);

        lineRenderer.SetPosition(1, bowStringPointPosUnloaded);
    }

    private void Update () {
		if (transform.childCount == 0)
        {
            loaded = false;
            reloadText.enabled = true;
        }else
        {
            loaded = true;
            arrow = transform.GetChild(0);
            reloadText.enabled = false;
        }
        if (Input.GetKeyDown("r"))
        {
            Reload();
        }

        if (loaded && Input.GetMouseButton(0))  // Ef haldinn niðri
        {
            if (pullAmount < 8)
            {
                pullAmount += Time.deltaTime * pullSpeed;
                arrow.transform.Translate(Vector3.down * Time.deltaTime / 2);
                var pointPos = lineRenderer.GetPosition(1);

                lineRenderer.SetPosition(1, new Vector3(pointPos.x - 0.012f, pointPos.y - 0.009f, pointPos.z));
            }
            
        }
        if (loaded && Input.GetMouseButtonUp(0))
        {
            arrow.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * (pullAmount * baseForce));
            arrow.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            arrow.transform.parent = null;

            pullAmount = 0;
            lineRenderer.SetPosition(1, bowStringPointPosUnloaded);
        }

	}

    private void Reload()
    {
        if(!loaded)
        {
            var _arrow = Instantiate(arrowPrefab, transform.position,
                transform.rotation) as GameObject;
            _arrow.transform.parent = transform;

            _arrow.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

            lineRenderer.SetPosition(1, bowStringPointPosLoaded);
        }
    }

    public int CurrentArrowNum()        // Notað í arrow.cs
    {
        return currentArrowNum;
    }

    public void AddToCurrentArrowNum()  // Notað í arrow.cs
    {
        currentArrowNum += 1;
    }
}

