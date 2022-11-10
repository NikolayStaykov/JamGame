using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    //aim controls 
    private Ray mouseToWorldRay;
    private Vector3 toLookAt;

    void Start()
    {

    }

    void Update()
    {
        mouseToWorldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseToWorldRay, out RaycastHit raycastHit))
        {
            toLookAt = raycastHit.point;
            toLookAt.y = 1;
            this.gameObject.transform.LookAt(toLookAt);
        }
    }
}
