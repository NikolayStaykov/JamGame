using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SawedOffShotGun : IWeapon
{
    public override void fireWeapon()
    {
        if (fireAllowed)
        {
            fireAllowed = false;
            sawedOffFire();
            resetFireAllowed();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        fireRate = 0.35f;
    }

    // Update is called once per frame
    void Update()
    {
        renderLaser();
    }

    private async void sawedOffFire()
    {
        int flag = 0;
        do
        {
            GameObject shotgunBlast = Instantiate(Resources.Load<GameObject>($"Weapons/SnowballBlast"), laserOrigin.position + laserOrigin.forward, laserOrigin.rotation);
            foreach (Rigidbody rb in shotgunBlast.GetComponentsInChildren<Rigidbody>())
            {
                rb.AddForce(this.transform.forward * 50, ForceMode.Impulse);
            }
            flag++;
            await Task.Delay(250);
        } while (flag < 2);
    }
}
