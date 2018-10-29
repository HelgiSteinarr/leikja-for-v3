using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

    private Rigidbody rb;
    private bool hit = false;
    private int arrowBaseNum;
    private int arrowNum;
    private Shooting shootingScript;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        shootingScript = transform.parent.GetComponent<Shooting>();
        arrowBaseNum = shootingScript.CurrentArrowNum();
        arrowNum = arrowBaseNum += 1;

        shootingScript.AddToCurrentArrowNum();
    }

    // Update is called once per frame
    private void Update () {
        if (transform.parent == null && !hit)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 15);
            /*float yVelocity = rb.velocity.y;
            float zVelocity = rb.velocity.z;
            float xVelocity = rb.velocity.x;
            float combinedVelocity = Mathf.Sqrt(xVelocity * xVelocity + zVelocity * zVelocity);
            float fallAngle = Mathf.Atan2(yVelocity, combinedVelocity) * 180 / Mathf.PI;

            transform.eulerAngles = new Vector3(fallAngle, transform.eulerAngles.y, transform.eulerAngles.x);
            */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent == null)
        {
            rb.isKinematic = true;
            hit = true;
        }     
    }

    public int arrowId()
    {
        return arrowNum;
    }
}
