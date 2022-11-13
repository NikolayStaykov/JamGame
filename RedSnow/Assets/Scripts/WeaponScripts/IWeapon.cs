using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    public string laserSightTag;
    public Transform laserOrigin;
    private LineRenderer laserSight;
    private RaycastHit lasersightHit;
    void Awake()
    {
        laserSight = this.gameObject.GetComponentInChildren<LineRenderer>();
    }

    public void renderLaser()
    {
        Physics.Raycast(laserOrigin.position, laserOrigin.forward, out lasersightHit,1000);
        laserSight.SetPosition(0,laserOrigin.position);
        laserSight.SetPosition(1, lasersightHit.point);
    }

    public abstract void fireWeapon();
}
