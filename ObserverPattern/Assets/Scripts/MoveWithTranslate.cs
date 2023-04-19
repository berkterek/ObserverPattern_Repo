using UnityEngine;

public class MoveWithTranslate : IMover
{
    readonly Transform _transform;
    readonly Vector2 _direction;
    float _speed = 5f;
    float _minMax = 5f;
    float _value;
    
    public MoveWithTranslate(Transform transform, Vector2 direction)
    {
        _transform = transform;
        _direction = direction;
    }

    public void Tick(float value)
    {
        _value = value;
    }

    public void FixedTick()
    {
        _transform.Translate(Time.deltaTime*_value*_speed*_direction);
        Vector3 currentPosition = _transform.position;
        float newYPosition = Mathf.Clamp(currentPosition.y, -_minMax, _minMax);
        _transform.position = new Vector3(currentPosition.x, newYPosition, 0f);
    }
}