using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour, Weapon
{
    //targetting laser 
    public Transform laserDirection;
    public Transform laserOrigin;
    public LineRenderer laserSight;
    private RaycastHit lasersightHit;
    //fire functionality
    protected bool fireAllowed = true;
    protected float fireRate;

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
    }
    public void setAsWeapon(string hand)
    {
        if (hand == "left")
        {
            GameObject.FindObjectOfType<PlayerBehaiviour>().setLeftWeapon(this);
        }
        else
        {
            GameObject.FindObjectOfType<PlayerBehaiviour>().setRightWeapon(this);
        }
    }
    protected async void resetFireAllowed()
    {
        await Task.Delay((int)(1000 / fireRate));
        fireAllowed = true;
    }

    public abstract void fireWeapon();
}
