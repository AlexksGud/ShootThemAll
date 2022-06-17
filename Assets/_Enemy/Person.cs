using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected int _healthPonts;

    public virtual void TakeDamage(int damage)
    {
         _healthPonts=-damage;
    }

    
}
