using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class Buttons : MonoBehaviour
{
    public bool redBullet;
    public GameObject bullet;
    public GameObject pauseMenu;
    private bool isPaused;

    private void Start()
    {
        
    }
    public void StartButton(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void Update()
    {
        if (redBullet == false)
        {
            bullet.GetComponent<ParticleSystem>().startColor = Color.white;
        }
        else if (redBullet == true)
        {
            bullet.GetComponent<ParticleSystem>().startColor = Color.red;
        }
    }

    public void OnMouseDown()
    {
        if (redBullet == true)
        {
            redBullet = false;
            Debug.Log("Normal bullets selected");
        }
        else if (redBullet == false)
        {
            redBullet = true;
            Debug.Log("Red bullets selected");
        }
    }
}