using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour {

    private Spawner spawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        spawner.OnObjectDestroyed();
    }

    public void setSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }
}
