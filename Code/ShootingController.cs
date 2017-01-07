using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ShootingController : MonoBehaviour
{
    private Transform m_bulletsContainer;
    private Transform m_shooter;
    public AudioSource m_player;

	// Use this for initialization
	void Start ()
    {
        m_bulletsContainer = this.transform;        ;
	}


    public void Init(Transform shooter)
    {
        m_shooter = shooter;
    }

	
	// Update is called once per frame
	void Update ()
    {
        if (m_bulletsContainer == null || m_shooter == null )
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate (
                Resources.Load ( "bullet 2" ) ,
                m_shooter.position + m_shooter.forward,
                m_shooter.rotation ,
                m_bulletsContainer ) as GameObject;

            if (newBullet == null)
            {
                Debug.LogWarning ( this.name + " Could not instnatiate bullet prefab" );
                return;
            }

            newBullet.GetComponent<Rigidbody> ( ).AddForce ( m_shooter.TransformDirection ( Vector3.forward ) * 1000f );
            Bullet.OnBulletHit += BulletHitHandler;

            m_player.Play();
        }
	
	}


    private void BulletHitHandler ( Bullet bullet , Collision collision )
    {
        if ( collision.collider.name.ToLower ( ).Contains ( "enemy" ) )
        {
            Debug.Log ( "Hit enemy." );

            // Kill Bullet
            Destroy ( bullet.gameObject );


            // Kill enemy
            AICharacterControl enemy = collision.gameObject.GetComponent<AICharacterControl> ( );
            if (enemy != null)
            {
                Destroy ( enemy );
                Destroy ( enemy.gameObject );
            }
        }
    }
}
