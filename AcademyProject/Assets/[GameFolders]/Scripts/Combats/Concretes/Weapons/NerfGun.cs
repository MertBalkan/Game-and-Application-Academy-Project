using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NerfGun : MonoBehaviour
{
    [SerializeField] Transform _player;
    public Transform top, namlu, mermi, nokta;

    public bool AlreadyAttack;
    public float timeBetweenAttacks;
    public LayerMask ground, player;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,player);//playerim yan�nda
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange,player);//yan�ndaysa sald�r
        if (playerInSightRange && playerInAttackRange) 
        {
            
          
                attackRangePlayer();
         

            
        }
        

    }
    void attackRangePlayer()
    {
      
        transform.LookAt(_player);
        top.Rotate(0, Input.GetAxis("Horizontal"), 0);
        namlu.Rotate(Input.GetAxis("Horizontal"), 0, 0);
        if (!AlreadyAttack)
        {
 //Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            Rigidbody rb = Instantiate(mermi, nokta.position, namlu.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f,ForceMode.Impulse);//ileri   
            rb.AddForce(transform.up * 7f, ForceMode.Impulse);//yukar�

            AlreadyAttack = true;
             Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
        
    }
    void resetAttack()
    {
        AlreadyAttack = false;
    }
}
