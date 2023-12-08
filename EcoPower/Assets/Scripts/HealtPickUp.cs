using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPickUp : MonoBehaviour
{
    public int vidaExtra;
    public bool isFullHeal;
    public GameObject heartEffect;
    public int soundToPlay;

    void Update()
    {
        transform.Rotate(0f, 0f , 64f * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(soundToPlay);
            Instantiate(heartEffect, PlayerController.instance.transform.position + new Vector3(0f, 5f, 0f), PlayerController.instance.transform.rotation);
            if (isFullHeal)
            {
                HealtManager.instance.ResetHeatl();
            }
            else
            {
                HealtManager.instance.AddHealth(vidaExtra);
            }
        }
    }
}
