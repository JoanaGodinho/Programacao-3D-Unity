using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public int fireRate = 1;
    public int damage = 10;
    public int range = 50;
    public Camera camera;
    public ParticleSystem bloodParticles;
    public ParticleSystem sparkParticles;

    private int layerMask = 1;
    private int enemyLayer;
    private int playerLayer;

	// Use this for initialization
	void Start () {
        // Add Enemy Layer
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");

        // Avoid Player Layer
        layerMask = ~(1 << playerLayer);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void Shoot()
    {
        RaycastHit hit;
        Player player = GetComponent<Player>();
        // If hit
        print(player);
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, layerMask))
        {
            if (hit.transform.gameObject.layer == enemyLayer)
            {
                Instantiate(bloodParticles, hit.point, Quaternion.identity);
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy.getHit(10) == 1)
                    player.addScore(1);
            }
            else
            {
                Instantiate(sparkParticles, hit.point, Quaternion.identity);
                Debug.Log(LayerMask.LayerToName(hit.transform.gameObject.layer));
            }

        }
    }
}
