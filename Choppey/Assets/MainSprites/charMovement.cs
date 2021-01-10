using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 charPos;
    private Vector3 faceAngle;
    public Camera daCamera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        charPos = this.transform.localPosition;
        var mPos = Input.mousePosition;
        mPos.z = this.transform.position.z - daCamera.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mPos);
        faceAngle = mousePos - charPos;
        Debug.Log(mousePos);
        faceAngle = Vector3.Normalize(faceAngle);
        //Debug.Log(faceAngle);
        //Debug.Log(Mathf.Rad2Deg * Mathf.Atan(faceAngle.x / faceAngle.y));
        if (faceAngle.y >= 0)
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -(Mathf.Rad2Deg * Mathf.Atan(faceAngle.x / faceAngle.y)));
        else
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180 - (Mathf.Rad2Deg * Mathf.Atan(faceAngle.x / faceAngle.y)));
    }
}
