using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Game : MonoBehaviour
{
    private RigidbodyFirstPersonController m_player;
    private EnemiesController m_enemiesController;

    // Use this for initialization
    void Start ()
    {
        m_player = GetComponentInChildren<RigidbodyFirstPersonController> ( );
        GetComponentInChildren<ShootingController> ( ).Init ( m_player.GetComponentInChildren<Camera> ( ).transform );

        m_enemiesController = GetComponentInChildren<EnemiesController> ( );
        m_enemiesController.Init ( m_player.transform );
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
