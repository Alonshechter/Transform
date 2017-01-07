using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemiesController : MonoBehaviour
{
    private List<AICharacterControl> m_enemies;
    private Transform  m_sharedTarget;
    public int m_enemyPoolSize = 5;

    private const int RANGE_TO_SPAWN_ENEMIES = 70;

    // Use this for initialization
    void Start ()
    {
        m_enemies = new List<AICharacterControl> ( );
	}


    public void Init ( Transform target )
    {
        m_sharedTarget = target;
    }


    // Update is called once per frame
    void Update ( )
    {
        if ( m_enemies == null || m_sharedTarget == null )
        {
            return;
        }

        List<AICharacterControl> toRemove = new List<AICharacterControl> ( );

        foreach ( AICharacterControl enemy in m_enemies )
        {
            if ( enemy == null )
            {
                toRemove.Add ( enemy );
            }
            else
            {
                enemy.target = m_sharedTarget;
            }
        }

        foreach ( AICharacterControl enemy in toRemove )
        {
            m_enemies.Remove ( enemy );
        }

        if ( m_enemies.Count < m_enemyPoolSize )
        {
            GameObject newEnemyObject = Instantiate (
                Resources.Load ( "enemy" ) ,
                m_sharedTarget.transform.position + new Vector3 ( Random.Range ( -RANGE_TO_SPAWN_ENEMIES , RANGE_TO_SPAWN_ENEMIES ) , m_sharedTarget.transform.position.y , Random.Range ( -RANGE_TO_SPAWN_ENEMIES , RANGE_TO_SPAWN_ENEMIES ) ) ,
                m_sharedTarget.transform.rotation ,
                this.transform ) as GameObject;

            if ( newEnemyObject == null )
            {
                Debug.LogWarning ( this.name + " could not instantiate enemy." );
                return;
            }


            UnityEngine.AI.NavMeshAgent newEnemyAI = newEnemyObject.GetComponent<UnityEngine.AI.NavMeshAgent> ( );

            newEnemyAI.speed = Random.Range ( 0.5f , 1.5f );           

            m_enemies.Add ( newEnemyObject.GetComponent<AICharacterControl> ( ) );
        }
    }
}