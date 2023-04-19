using UnityEngine;

public class DestroyHandler
{
    readonly float _maxDelayTime;
    readonly GameObject _gameObject;
    
    float _currentTime = 0f;
    
    public DestroyHandler(GameObject gameObject, float delayTime)
    {
        _gameObject = gameObject;
        _maxDelayTime = delayTime;
    }

    public void Tick()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxDelayTime)
        {
            DestroyGameObject();
        }
    }

    public void DestroyGameObject()
    {
        GameObject.Destroy(_gameObject);
    }
}