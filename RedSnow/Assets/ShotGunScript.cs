using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : IWeapon, Weapon 
{
    public void Awake()
    {
        fireRate = 0.5f;
    }
    public override void fireWeapon()
    {
        if(fireAllowed) 
        { 
            fireAllowed= false;
            GameObject shotgunBlast = Instantiate(Resources.Load<GameObject>($"Weapons/SnowballBlast"), laserOrigin.position + laserOrigin.forward, laserOrigin.rotation);
            foreach(Rigidbody rb in shotgunBlast.GetComponentsInChildren<Rigidbody>())
            {
                rb.AddForce(this.transform.forward * 50, ForceMode.Impulse);
            }
            resetFireAllowed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        renderLaser();
    }
}
