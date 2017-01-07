using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activayeSound : MonoBehaviour {

    private AudioSource damage;

	// Use this for initialization
	void Start () {
        damage = GetComponent<AudioSource>();
        Bullet.OnBulletHit += playSound;


    }
	
	// Update is called once per frame
	public void playSound(Bullet bullet, Collision collision)
        {

        this.transform.position = collision.transform.position;
        if(collision.gameObject.CompareTag("enemy"))
        {
            damage.Play();
        }
        
    }
}
