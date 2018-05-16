using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;

    private Spawner spawner;
    private Seek seek;
    private GameObject target;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        if (seek != null)
        {
            seek.Update();
        }
	}

    private void OnDestroy()
    {
        spawner.OnObjectDestroyed();
    }

    public void setSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }

    public void setTarget(GameObject target)
    {  
        this.target = target;
        seek = new Seek(transform, this.target.transform, speed);
    }
}
