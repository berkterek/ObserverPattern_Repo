using UnityEngine;

public class FireHandler
{
    readonly BulletController _bulletController;
    readonly Transform _fireTransform;
    readonly float _maxFireRate;

    float _currentFireRate = 0f;
    
    public FireHandler(FireModel model)
    {
        _bulletController = model.BulletController;
        _fireTransform = model.FireTransform;
        _maxFireRate = model.FireRate;
    }

    public void Tick()
    {
        _currentFireRate += Time.deltaTime;
        if (_currentFireRate > _maxFireRate)
        {
            _currentFireRate = 0f;
            GameObject.Instantiate(_bulletController, _fireTransform.position, Quaternion.identity);
        }
    }
}