using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] float _maxSpeed = 2f;
    [SerializeField] float _minSpeed = 0.3f;
    [SerializeField] float _maxLifeTime = 8f;
    [SerializeField] HealthBarFillerController _healthBarFiller;

    IMover _mover;
    DestroyHandler _destroyHandler;
    float _currentSpeed;
    SoundManager _soundManager;

    public Health Health { get; private set; }
    
    void Awake()
    {
        Health = new Health(_maxHealth);
        _mover = new MoveWithTranslate(this.transform,Vector2.right);
        _destroyHandler = new DestroyHandler(this.gameObject,_maxLifeTime);
        _soundManager = new SoundManager();
    }

    void OnEnable()
    {
        Health.OnTookDamage += HandleOnTookDamage;
        Health.OnDead += HandleOnDead;
    }

    void OnDisable()
    {
        Health.OnTookDamage -= HandleOnTookDamage;
        Health.OnDead -= HandleOnDead;
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
    
    void HandleOnTookDamage(float currentHealth, float maxHealth)
    {
        Debug.Log($"Enemy Took Damage Current:{currentHealth} Max:{maxHealth} Filler:{currentHealth/maxHealth}");
        _healthBarFiller.HandleOnDamage(currentHealth, maxHealth);
        _soundManager.PlaySound(SoundType.EnemyTookDamage);
    }

    void HandleOnDead(float currentHealth, float maxHealth)
    {
        Debug.Log($"Enemy Took Damage Current:{currentHealth} Max:{maxHealth} Filler:{currentHealth/maxHealth}");
        _healthBarFiller.HandleOnDamage(currentHealth, maxHealth);
        _destroyHandler.DestroyGameObject();
        _soundManager.PlaySound(SoundType.EnemyDying);
    }
}

public class SoundManager
{
    public void PlaySound(SoundType soundType)
    {
        Debug.Log($"{soundType} Played");
    }
}

public enum SoundType : byte
{
    EnemyTookDamage,
    EnemyDying
}


