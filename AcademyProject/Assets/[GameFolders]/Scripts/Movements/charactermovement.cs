using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private float _movespeed = 5;//h�z
    [SerializeField] private float _turnspeed = 360;
    private Vector3 _input;
    void Update()
    {
        Gatherinput();
        Look();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Gatherinput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime);
        
    }
    void Move()
    {
        _rigibody.MovePosition(transform.position + transform.forward * _input.magnitude * _movespeed * Time.deltaTime);
    }

}
public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}

