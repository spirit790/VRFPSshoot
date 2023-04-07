using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzlPlash : MonoBehaviour
{
    public GameObject muzzl;

    public 
    void Start()
    {
        
    }

    public void OnMuzzl()
    {
        Instantiate(muzzl, transform.position, transform.rotation);
    }
    void Update()
    {
        
    }
}
