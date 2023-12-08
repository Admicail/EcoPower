using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Vector3 respawnPosition;
    public GameObject deathEffect;
    public int currentCoins;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
        AddCoins(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

    }

    public void Respawn()
    {
        StartCoroutine(RespawnTimer());
        HealtManager.instance.PlayerKilled();
    }

    public IEnumerator RespawnTimer() 
    {
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.CineCamera.enabled = false;
        UIManager.instance.fadeToBlack = true;
        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f,2f,0f), PlayerController.instance.transform.rotation);
        yield return new WaitForSeconds(2f);
        UIManager.instance.fadeFromBlack = true;
        PlayerController.instance.transform.position = respawnPosition;
        CameraController.instance.CineCamera.enabled = true;
        PlayerController.instance.gameObject.SetActive(true);
        HealtManager.instance.ResetHeatl();
    }   

    public void setSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        UIManager.instance.coinText.text = "" + currentCoins;
    }

    public void PauseMenu()
    {
        if (UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UIManager.instance.pauseScreen.SetActive(true);
            UIManager.instance.CloseOption();
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
