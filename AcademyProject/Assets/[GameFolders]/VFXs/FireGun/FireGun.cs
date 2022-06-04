using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    //private GameObject _FireParticle;
    private ParticleSystem _fireControl;
    
    [SerializeField]
    private ParticleSystem _smokeControl;

    private Material _Material;

    private void Awake()
    {
        //_FireParticle = GameObject.FindGameObjectWithTag("Fire");
        _fireControl = this.gameObject.GetComponent<ParticleSystem>();
    }

    void Start()
    {
        
    }

    [System.Obsolete]
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            //_fireControl.Play(true);
            _fireControl.enableEmission = true;

        }
        else
        {
            _fireControl.enableEmission = false;
            _smokeControl.enableEmission = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.gameObject.CompareTag("Environment"))
        {
            _Material = other.GetComponent<Renderer>().material;
            _Material.SetColor("_Color", new Color(0, 0, 0, 0.25f));
            _smokeControl.enableEmission = true;
        }

    }

}
