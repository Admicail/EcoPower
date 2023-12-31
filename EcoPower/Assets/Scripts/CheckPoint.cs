using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject cpOn, cpOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.setSpawnPoint(transform.position);

            CheckPoint[] allCP = FindObjectsOfType<CheckPoint>();
            for (int i = 0; i < allCP.Length; i++)
            {
                allCP[i].cpOff.SetActive(true);
                allCP[i].cpOn.SetActive(false);
            }
            cpOff.SetActive(false);
            cpOn.SetActive(true);
        } 
    }
}
