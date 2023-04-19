using UnityEngine;
using UnityEngine.UI;

public class HealthBarFillerController : MonoBehaviour
{
    [SerializeField] Image _image;
    
    public void HandleOnDamage(float currentHealth, float maxHealth)
    {
        _image.fillAmount = currentHealth / maxHealth;
    }
}