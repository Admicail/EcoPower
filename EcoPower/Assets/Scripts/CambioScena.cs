using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{
    public int escena;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CambiarEscena();
    }
    public void CambiarEscena()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(escena);
        }
    }
}
