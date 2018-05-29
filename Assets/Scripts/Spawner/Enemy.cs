using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float speed;
    public int damage = 10;
    public int seekDistance = 10;
    public int HP = 50;

    NavMeshAgent nav;
    private Spawner spawner;
    private Seek seek;
    private GameObject target;
    Animator anim;
    
    // Use this for initialization
    void Awake ()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(target.transform.position);
	}

   
    private void OnDestroy()
    {
        spawner.OnObjectDestroyed();
    }


    public int getHit(int dmg)
    {
        HP -= dmg;
        if (HP <= 0) {
            nav.isStopped = true;
            anim.SetBool("isDead", true);
            GetComponent<CapsuleCollider>().isTrigger = true;
            Destroy(this.gameObject, 4);
            return 1;
        }
        return 0;
    }
    public void setSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }

    public void setTarget(GameObject target)
    {  
        this.target = target;
        seek = new Seek(transform, this.target.transform, speed, seekDistance);
    }
}
