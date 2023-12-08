using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtManager : MonoBehaviour
{
    public static HealtManager instance;
    public int currentHealt, maxHealth;
    public float invincibleLenght = 2f;
    private float invicCounter;
    public Sprite[] healtBarImages;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetHeatl();
    }

    // Update is called once per frame
    void Update()
    {
        if (invicCounter > 0)
        {
            invicCounter -= Time.deltaTime;
            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if (Mathf.Floor(invicCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }
                if (invicCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
        }
        if (PlayerController.instance.transform.position.y < -500)
        {
            PlayerKilled();
            GameManager.Instance.Respawn();
        }
    }

    public void Herida()
    {
        if (invicCounter <=  0)
        {
            currentHealt--;
            if (currentHealt <= 0)
            {
                currentHealt = 0;
                GameManager.Instance.Respawn();
            }
            else
            {
                PlayerController.instance.KnockBack();
                invicCounter = invincibleLenght;

            }
        }
        ActualizarVida();
    }

    public void ResetHeatl()
    {
        UIManager.instance.healthImage.enabled = enabled;
        currentHealt = maxHealth;
        ActualizarVida();
    }

    public void AddHealth(int vidaExtra)
    {
        currentHealt += vidaExtra;
        if (currentHealt > maxHealth)
        {
            currentHealt = maxHealth;
        }
        ActualizarVida();
    }

    public void ActualizarVida()
    {
        UIManager.instance.healthText.text = currentHealt.ToString();

        switch(currentHealt)
        {
            case 5:
                UIManager.instance.healthImage.sprite = healtBarImages[4];
                break;

            case 4:
                UIManager.instance.healthImage.sprite = healtBarImages[3];
                break;

            case 3:
                UIManager.instance.healthImage.sprite = healtBarImages[2];
                break;

            case 2:
                UIManager.instance.healthImage.sprite = healtBarImages[1];
                break;

            case 1:
                UIManager.instance.healthImage.sprite = healtBarImages[0];
                break;
            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
        }
    }
    public void PlayerKilled()
    {
        currentHealt = 0;
        ActualizarVida();
    }
}
