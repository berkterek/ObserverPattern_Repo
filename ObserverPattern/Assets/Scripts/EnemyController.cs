using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;

    public Health Health { get; private set; }

    void Awake()
    {
        Health = new Health(_maxHealth);
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }
}