public class Health
{
    readonly int _maxHealth;
    int _currentHealth;
    
    public event System.Action OnTookDamage;
    public event System.Action OnDying;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_maxHealth <= 0)
        {
            OnDying?.Invoke();
        }
        else
        {
            OnTookDamage?.Invoke();
        }
    }
}