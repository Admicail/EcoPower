using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemPickUp : MonoBehaviour
{
    public int value;
    public GameObject coinEffect;
    public int soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 64f * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.AddCoins(value);
            Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
