using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    
    private Animator _animator;
	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Use"))
        {
            print("used");
            _animator.SetBool("open", _animator.GetBool("open") ? false : true);
        }
    }

	// Update is called once per frame
	void Update () {
    }
}
