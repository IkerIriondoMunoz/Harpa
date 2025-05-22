using UnityEngine;
using UnityEngine.AI;

public class EnemiesMovement : MonoBehaviour
{
    public NavMeshAgent _agent;
    public GameObject[] _routePoints;
    public float _speed = 3f;
    public float _runSpeed = 5f;
    private float _currentSpeed;

    private int _actualPoint = 0;
    private bool _patrol;

    public float _detectionRadius = 10f;
    public float _detectionAngle = 90f;

    public Transform _player;

    public float _atackRange = 2f;
    public float _atackCooldown = 1f;
    private float _lastAtackTime = 1f;

    public GameObject _damageTrigger;
    public float _damageTriggerDuration = 1f;
    private float _damageTriggerTimer = 0f;
    private bool _isAttacking = false;

    public Animator _animator;

    void Start()
    {
        if (_routePoints.Length > 0)
        {
            _agent.SetDestination(_routePoints[_actualPoint].transform.position);
        }

        _animator.SetFloat("Speed", _currentSpeed);

        _currentSpeed = _speed;
        _agent.speed = _currentSpeed;
        _patrol = true;

        Patrol();
        _damageTrigger.SetActive(false);
    }

    private void Update()
    {
        if (_patrol && !_agent.pathPending && _agent.remainingDistance <= 0.1f)
        {
            Patrol();
        }

        Vector3 playerDirection = (_player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, _player.position);
        float angleToPlayer = Vector3.Angle(transform.forward, playerDirection);

        if (distance <= _detectionRadius && angleToPlayer <= _detectionAngle)
        {
            Alert();
            _patrol = false;

            if (distance <= _atackRange && Time.time >= _lastAtackTime + _atackCooldown && !_isAttacking)
            {
                Atack();
                _lastAtackTime = Time.time;
            }
        }
        else
        {
            _patrol = true;
        }

        if (_isAttacking)
        {
            _damageTriggerTimer += Time.deltaTime;
            if (_damageTriggerTimer >= _damageTriggerDuration)
            {
                _damageTrigger.SetActive(false);
                _isAttacking = false;
                _damageTriggerTimer = 0f;
                Debug.Log("Fin del ataque");
                _agent.speed = _currentSpeed;
            }
        }
    }

    public void Patrol()
    {
        _actualPoint++;
        if (_actualPoint >= _routePoints.Length)
        {
            _actualPoint = 0;
        }

        _currentSpeed = _speed;
        _agent.SetDestination(_routePoints[_actualPoint].transform.position);
    }

    public void Alert()
    {
        _agent.SetDestination(_player.transform.position);
        _currentSpeed = _runSpeed;
    }

    public void Atack()
    {
        _damageTrigger.SetActive(true);
        _isAttacking = true;
        _damageTriggerTimer = 0f;
        Debug.Log("Ataque ejecutado");
        _lastAtackTime = Time.time;
    }
}
