using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

    public string weaponName;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Use"))
        {
            WeaponManager wm = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponManager>();
            wm.replaceWeapon(weaponName);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
