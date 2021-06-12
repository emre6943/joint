using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragJoint : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void onMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        mOffset.z = 0;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 pose = GetMouseWorldPos();
        pose.z = 0;
        transform.position = pose + mOffset;
    }

}
