using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(FixedJoint))]

public class ItemPickUP : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    [SerializeField] private FixedJoint _Joint;
    public FixedJoint Joint => _Joint;

    private void Awake()
    {
        if (!_Joint && !TryGetComponent<FixedJoint>(out _Joint)) _Joint = gameObject.AddComponent<FixedJoint>();

        if (!_rigidbody && !TryGetComponent<Rigidbody>(out _rigidbody)) _rigidbody = gameObject.AddComponent<Rigidbody>();

        // _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        _Joint.breakForce = 11000f;
        _Joint.breakTorque = 11000f;
        _Joint.connectedMassScale = 1f;

    }

    public void AddJoint()
    {
        Awake();
    }
}
