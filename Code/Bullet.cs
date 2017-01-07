using UnityEngine;

public class Bullet : MonoBehaviour
{
    public delegate void Bullethit ( Bullet bullet , Collision collision );
    public static event Bullethit OnBulletHit;

    private float m_timer;


    void Awake()
    {
        m_timer = 0;
    }


    void Update ( )
    {
        m_timer += Time.deltaTime;

        if ( m_timer > 2f )
        {
            Destroy ( this.gameObject );
        }
    }


    void OnCollisionEnter ( Collision collision )
    {
        if ( OnBulletHit != null )
        {
            OnBulletHit ( this , collision );
        }
       
    }

}
