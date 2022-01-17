using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Bullets : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject bullet;
    public bool biggerBullet;
    public Buttons buttons;

    void Start()
    {

        GameObject.Find("ButtonObj").GetComponent<Buttons>();
    }

    public void Update()
    {
        if (biggerBullet == false)
        {
            bullet.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (biggerBullet == true)
        {
            bullet.transform.localScale = new Vector3(3, 3, 3);
        }
    }

    public void OnMouseDown()
    {
        if (biggerBullet==true)
        {
            biggerBullet = false;
            Debug.Log("Normal bullets selected");
        }
        else if (biggerBullet == false )
        {
            biggerBullet = true;
            Debug.Log("Bigger bullets selected");
        }
    }
}
