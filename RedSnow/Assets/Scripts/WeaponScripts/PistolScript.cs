using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PistolScript : IWeapon, Weapon
{
    // Start is called before the first frame update
    void Awake()
    {
        fireRate = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        renderLaser();
    }

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
}
