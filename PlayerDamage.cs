using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerDamage : MonoBehaviour
{
    public float m_playerHealth = 100f;
    public float m_damageToInflictOnHit;
    public bool m_isDead;
    private float m_originalPlayerHealth;
    public Canvas can;
    public Slider slide;
   
        



    void Start()
    {
        m_isDead = false;
        m_originalPlayerHealth = m_playerHealth;
       
    }


    void OnCollisionStay(Collision collision)
    {
        if (m_isDead)
        {
            return;
        }

        if (collision.gameObject.name.ToLower().Contains("enemy"))
        {
            DamagePlayer ( );
            slide.value = m_playerHealth;
            
        }
    }


    void OnCollisionExit()
    {
        Camera.main.GetComponent<Fisheye>().enabled = false;
    }


    void Update()
    {
        if (m_isDead)
        {
            return;
        }

        if (m_playerHealth < 0)
        {
            KillPlayer ( );
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RevivePlayer ( );
        }

       
    }


    private void RevivePlayer ( )
    {
        m_playerHealth = m_originalPlayerHealth;
        m_isDead = false;
        GetComponent<Rigidbody> ( ).isKinematic = false;
    }


    private void KillPlayer ( )
    {
        Debug.Log ( name + " is dead." );
        m_isDead = true;
        GetComponent<Rigidbody> ( ).isKinematic = true;
        this.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        can.gameObject.SetActive(true);
;        
    }


    private void DamagePlayer ( )
    {
        Debug.Log ( name + " is being hit by enemy" );
        m_playerHealth -= m_damageToInflictOnHit;
        Camera.main.GetComponent<Fisheye>().enabled = true;
     
    }
}
