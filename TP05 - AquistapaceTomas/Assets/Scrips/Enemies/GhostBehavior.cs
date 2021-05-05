using UnityEngine;
using UnityEngine.AI;

public class GhostBehavior : MonoBehaviour
{
    public float damage = 10f;
    public float rangeRadius = 40f;
    public float newMaxPosition = 20f;

    Transform target;
    NavMeshAgent agent;

    bool goARandomPos;
    Vector3 randomPos;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        goARandomPos = false;
        randomPos = Vector3.zero;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= rangeRadius)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            if (!goARandomPos)
            {
                randomPos = SetNewDestination();
                agent.SetDestination(randomPos);

                goARandomPos = true;
            }
            else if (transform.position.x == randomPos.x && transform.position.z == randomPos.z)
            {
                goARandomPos = false;
            }
        }
    }

    Vector3 SetNewDestination()
    {
        float x = Random.Range(transform.position.x - newMaxPosition, transform.position.x + newMaxPosition);
        float z = Random.Range(transform.position.z - newMaxPosition, transform.position.z + newMaxPosition);

        Vector3 newPos = new Vector3(x, transform.position.y, z);

        if (Physics.Raycast(newPos, -transform.up, 2f))
        {
            return newPos;
        }

        return transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        PlayerStats player = other.transform.GetComponent<PlayerStats>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }
}
