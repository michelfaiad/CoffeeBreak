using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    [SerializeField] GameObject destroyEffect;
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayPowerupShowSound();
        rb.AddForce(Vector3.up * force);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.9f)
        {            
            Destroy(this.gameObject);
        }

    }

    public void HitMe()
    {
        Instantiate(destroyEffect, transform.position, transform.rotation);

        SoundManager.instance.PlayPowerupHitSound();

        GameController.instance.SlowDown();
        
        Destroy(gameObject);
    }
}
