using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _maxLifeTime = 10f;
    [SerializeField] int _damage = 50;

    IMover _mover;
    DestroyHandler _destroyHandler;
    
    void Awake()
    {
        _mover = new MoveWithTranslate(this.transform, Vector2.right);
        _destroyHandler = new DestroyHandler(this.gameObject,_maxLifeTime);
    }

    void Update()
    {
        _mover.Tick(10f);
    }

    void FixedUpdate()
    {
        _mover.FixedTick();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyController enemyController))
        {
            enemyController.Health.TakeDamage(_damage);
            _destroyHandler.DestroyGameObject();
        }
    }
}