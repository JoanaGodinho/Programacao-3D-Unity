using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    // Use this for initialization
    GameObject[] weapons = new GameObject[2];
    GameObject possibleWeapons;
    int activeWeapon = 0;

	void Start () {
        weapons[0] = transform.Find("Weapon01").gameObject;
        weapons[1] = transform.Find("Weapon02").gameObject;
        possibleWeapons = transform.Find("PossibleWeapons").gameObject;
        
        GameObject clone = Instantiate(possibleWeapons.transform.Find("Pistol").gameObject);
        clone.transform.parent = weapons[activeWeapon].transform;
        clone.transform.localPosition = weapons[activeWeapon].transform.localPosition;
        clone.transform.localRotation = weapons[activeWeapon].transform.localRotation;
        weapons[activeWeapon].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SwitchWeapon"));

    }

    public void switchWeapon()
    {
        weapons[activeWeapon].SetActive(false);
        activeWeapon = activeWeapon == 1 ? 0 : 1;
        weapons[activeWeapon].SetActive(false);
    }

    public void replaceWeapon(string weaponName)
    {

    }
}
