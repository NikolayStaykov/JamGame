using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SnowBallScript : MonoBehaviour
{
    private bool destroyed = false;
    public void Awake()
    {
        expire();   
    }
    public void OnCollisionEnter(Collision collision)
    {
        destroyed= true;
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }

    private async void expire()
    {
        await Task.Delay(5000);
        if(!destroyed)
        {
            Destroy(this.gameObject);
        }
    }
}
