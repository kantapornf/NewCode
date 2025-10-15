using UnityEngine;

public interface Idestoryable
{
    int health { get; set; }
    int maxHealth {  get; set; }

    void TakeDamage(int damage);

    event System.Action<Idestoryable> OnDestory;
}
