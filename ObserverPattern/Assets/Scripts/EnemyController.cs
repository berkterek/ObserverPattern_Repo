using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] float _maxSpeed = 2f;
    [SerializeField] float _minSpeed = 0.3f;
    [SerializeField] HealthBarFillerController _healthBarFiller;

    IMover _mover;
    DestroyHandler _destroyHandler;
    float _currentSpeed;

    public Health Health { get; private set; }
    
    void Awake()
    {
        Health = new Health(_maxHealth);
        _mover = new MoveWithTranslate(this.transform,Vector2.right);
    }

    void Start()
    {
        _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
    }

    void Update()
    {
        _mover.Tick(-_currentSpeed);
        _destroyHandler.Tick();
    }

    void FixedUpdate()
    {
        _mover.FixedTick();
    }
}