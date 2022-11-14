using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    public Transform laserDirection;
    public Transform laserOrigin;
    private LineRenderer laserSight;
    private RaycastHit lasersightHit;
    void Awake()
    {
        laserSight = this.gameObject.GetComponentInChildren<LineRenderer>();
    }

    public void renderLaser()
    {
        laserSight.SetPosition(0, laserOrigin.position);
        if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out lasersightHit,1000))
        {
            laserSight.SetPosition(1, lasersightHit.point);
        }
        else
        {
            laserSight.SetPosition(1, laserDirection.position);
        }
        Debug.Log("Origin"+laserOrigin.position.ToString());
        Debug.Log("ray hit"+lasersightHit.point.ToString());
        Debug.Log("forward"+laserOrigin.forward.ToString());
    }

    public abstract void fireWeapon();
}
