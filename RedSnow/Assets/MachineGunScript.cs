using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : IWeapon
{
    public override void fireWeapon()
    {
        if(fireAllowed)
        {
            fireAllowed = false;
            GameObject bullet = Instantiate(Resources.Load<GameObject>($"Weapons/SnowBall"), laserOrigin.position + laserOrigin.forward, laserOrigin.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * 100, ForceMode.Impulse);
            resetFireAllowed();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        fireRate = 5.6f;
    }

    // Update is called once per frame
    void Update()
    {
        renderLaser();
    }
}
