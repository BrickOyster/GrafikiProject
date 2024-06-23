using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class GuardLogic : MonoBehaviour
{
    public bool playerInRange;
    private float roamCooldown, rc, attackCooldown, ac, atkAnimTimer, at;
    private NavMeshAgent _agent;
    private AudioSource _hit;
    private Animator _animator;
    private GameObject pc;
    public GameObject DestoyPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        atkAnimTimer = 3f; 
        at = 0f;
        attackCooldown = 5f;
        ac = attackCooldown;
        roamCooldown = 0.5f;
        rc = roamCooldown;
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponent<Animator>();
        _hit = GetComponent<AudioSource>();
        pc = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rc -= Time.deltaTime;
        ac -= Time.deltaTime;
        at -= Time.deltaTime;

        if(rc < 0 && !playerInRange)
        {
            rc = roamCooldown;
            roamAround();
        }
        float speedP = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("speed",speedP);
        

        if(at < 0)
        {
            _animator.SetBool("atk",false);
            playerInRange = false;
        }

        if(gameObject.transform.position.x > DestoyPoint.transform.position.x)
        {
            Debug.Log("DESTROOOOOY");
            Destroy(gameObject);
        }
    }

    private void roamAround()
    {
        Vector3 dest = gameObject.transform.position;

        dest += 1*(new Vector3(1,0,0));
        
        _agent.SetDestination(dest);
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
        {
            _agent.ResetPath();
            if(ac < 0)
            {
                _animator.SetBool("atk",true);
                pc.GetComponent<PcLogic>().Damage(10);
                _hit.Play();
                playerInRange = true;
                at = atkAnimTimer;
                ac = attackCooldown;
            }        
        }
    }
}
