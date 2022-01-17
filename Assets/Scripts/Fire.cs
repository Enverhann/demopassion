using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    //Guns/Shooting
    RaycastHit hit;
    public GameObject rayPointer;
    public bool canFire;
    float gunTimer;
    public ParticleSystem muzzle;
    public float range;
    public GameObject impact;
    public bool isAuto;
    public GameObject anims;
    public Scriptable scriptableGun;

    //Ammo
    public float ammoInGun;
    public float ammoInPocket;
    public float maxAmmo;
    float addableAmmo;
    public Text ammoCount;
    public Text pocketAmmoCount;

    //Reload
    float reloadTimer;

    //Recoil
    private Recoil recoilScript;

    //Sound Effects
    AudioSource audioSource;
    Animator gunAnim;

    private static bool delayBullet;
  
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gunAnim = GetComponent<Animator>();
        recoilScript = GameObject.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();      
    }

    public void Update()
    {
        ammoCount.text = ammoInGun.ToString();
        pocketAmmoCount.text = ammoInPocket.ToString();
        addableAmmo = maxAmmo - ammoInGun;

        if(addableAmmo > ammoInPocket)
        {
            addableAmmo = ammoInPocket;
        }

        if (Input.GetKey(KeyCode.Mouse0) && isAuto && canFire && Time.time > gunTimer && ammoInGun > 0&&!delayBullet)
        {
            Firing();
            recoilScript.RecoilFire();
            gunTimer = Time.time + scriptableGun.gunCd;
        }else if(Input.GetKey(KeyCode.Mouse0) && isAuto && canFire && Time.time > gunTimer && ammoInGun > 0 && delayBullet)
        {
            Invoke("Firing", 1f);
            recoilScript.RecoilFire();
            gunTimer = Time.time + scriptableGun.gunCd;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAuto && canFire && Time.time > gunTimer && ammoInGun > 0 && !delayBullet)
        {
            Firing();
            recoilScript.RecoilFire2();
            gunTimer = Time.time + scriptableGun.gunCd;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && !isAuto && canFire && Time.time > gunTimer && ammoInGun > 0 && delayBullet)
        {
            Invoke("Firing", 1f);
            recoilScript.RecoilFire2();
            gunTimer = Time.time + scriptableGun.gunCd;
        }
        
        if (Input.GetKeyDown(KeyCode.R) && addableAmmo > 0 && ammoInPocket > 0)
        {
            if(Time.time > reloadTimer)
            {
                StartCoroutine(Reload());
                reloadTimer = Time.time + scriptableGun.reloadCd;
            }
        }  
    }

    public void OnMouseDown()
    {
        if (delayBullet == true)
        {
            delayBullet = false;
            Debug.Log("Normal bullets selected");
        }
        else if (delayBullet == false)
        {
            delayBullet = true;
            Debug.Log("Delay bullets selected");
        }
    }
    private void Firing()
    {
        for (int i = 0; i < Mathf.Max(1, scriptableGun.pellets); i++)
        {
            ammoInGun--;

        if (!Physics.Raycast(rayPointer.transform.position, rayPointer.transform.forward, out hit, range))
        {
            audioSource.clip = scriptableGun.firingSound;
            muzzle.Play();
            audioSource.Play();
            gunAnim.Play("Fire", -1, 0f);
        }
        else
        {
            audioSource.clip = scriptableGun.firingSound;
            muzzle.Play();
            audioSource.Play();

            Debug.Log("Shot Fired");
            Debug.Log((hit.transform.name) + "Got Hit");
            gunAnim.Play("Fire", -1, 0f);
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
        }
    }

    IEnumerator Reload()
    {
        canFire = false;
        gunAnim.SetBool("isReloading", true);

        audioSource.clip = scriptableGun.reloadSound;
        audioSource.Play();
        Debug.Log("Reloading");
        yield return new WaitForSeconds(1.5f);
        gunAnim.SetBool("isReloading", false);
       
        yield return new WaitForSeconds(scriptableGun.reloadTime);
        ammoInGun = ammoInGun + addableAmmo;
        ammoInPocket = ammoInPocket - addableAmmo;
        canFire = true;      
    }

    public void ResetAnim()
    {
        anims.GetComponent<Animator>().Rebind();
        canFire = true;
    }
}
