public class Health
{
    readonly int _maxHealth;
    int _currentHealth;

    public event System.Action<float, float> OnTookDamage;
    public event System.Action<float, float> OnDead;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth > 0)
        {
            OnTookDamage?.Invoke(_currentHealth, _maxHealth);
        }
        else
        {
            OnDead?.Invoke(_currentHealth, _maxHealth);
        }
    }
}