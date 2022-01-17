using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Scriptable scriptableM4;
    public Scriptable scriptableM9;

    //Rotations
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    //Recoil
    [SerializeField] private float snappy;
    [SerializeField] private float returnSpeed;

    void Start()
    {

    }

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappy * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        targetRotation += new Vector3(scriptableM4.recoilX, Random.Range(-scriptableM4.recoilY, scriptableM4.recoilY), Random.Range(-scriptableM4.recoilZ, scriptableM4.recoilZ));
    }
    public void RecoilFire2()
    {
        targetRotation += new Vector3(scriptableM9.recoilX, Random.Range(-scriptableM9.recoilY, scriptableM9.recoilY), Random.Range(-scriptableM9.recoilZ, scriptableM9.recoilZ));
    }
}
