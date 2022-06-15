using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected int _healthPonts;

    public virtual int TakeDamage(int damage)
    {
        return _healthPonts-damage;
    }

    
}
