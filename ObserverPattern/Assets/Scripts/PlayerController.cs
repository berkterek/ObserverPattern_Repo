using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BulletController _bullet;
    [SerializeField] Transform _fireTransform;
    [SerializeField] float _fireRate = 0.3f;
    
    InputReader _input;
    IMover _mover;
    FireHandler _fireHandler;
    
    void Awake()
    {
        _input = new InputReader();
        _mover = new MoveWithTranslate(this.transform, Vector2.up);
        _fireHandler = new FireHandler(new FireModel { BulletController = _bullet, FireTransform = _fireTransform,FireRate = _fireRate});
    }

    void Update()
    {
        _mover.Tick(_input.UpDown);
        _fireHandler.Tick();
    }

    void FixedUpdate()
    {
        _mover.FixedTick();
    }
}