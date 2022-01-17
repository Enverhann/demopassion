using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GunValues", menuName = "Values")]

[System.Serializable]
public class Scriptable : ScriptableObject
{
    public string gunName;
    public float reloadTime;
    public float gunCd;
    public float reloadCd;
    public AudioClip firingSound;
    public AudioClip reloadSound;
    public bool isAuto;
    public AudioClip weaponChangeSound;
    public float recoilX;
    public float recoilY;
    public float recoilZ;
    public int pellets;
}