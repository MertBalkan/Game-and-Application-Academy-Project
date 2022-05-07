using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcademyProject.Controllers
{
    public class BaseCharacterController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float _movespeed = default;
        [SerializeField] private float _turnspeed = default;
        
        public float TurnSpeed { get => _turnspeed; set => value = _turnspeed; }
        public float MoveSpeed{ get => _movespeed; set => value = _movespeed; }
    }
}