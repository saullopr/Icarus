using UnityEngine;

public class BossMissile : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _targetThreshold = .1f;

    [SerializeField] private float _initialTargetHeight;
    [SerializeField] private float _initialTargetVariance;

    [SerializeField] private string _targetTag;

    private Vector3 _initialTarget;
    private Transform _target;

    private bool _hasReachedInitialTarget;

    private void Start() {
        SetInitialTargets();
    }

    private void Update() {
        UpdateTarget();
        MoveToTarget();
    }

    private void SetInitialTargets() {
        _initialTarget = transform.position;
        _initialTarget.y = _initialTargetHeight;

        _initialTarget += Random.insideUnitSphere * _initialTargetVariance;

        _target = GameObject.FindWithTag(_targetTag)
           .transform;
    }

    private void UpdateTarget() {
        if (Vector3.Distance(transform.position, _initialTarget) < _targetThreshold) {
            _hasReachedInitialTarget = true;
        }
    }

    private void MoveToTarget() {
        var target = _hasReachedInitialTarget ? _target.position : _initialTarget;
    
        transform.LookAt(target);

        transform.position = Vector3.MoveTowards(transform.position, target, _moveSpeed);
    }
}
