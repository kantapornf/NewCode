using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : Stuff, Idestoryable, IInteractable
{
    public Box() {
        Name = "Box";
    }
    public GameObject DropItem;
    public bool isInteractable { get => CanUse; set => CanUse=value; }
    public int health { get => _health; set =>_health = Mathf.Clamp(value,0,maxHealth); }
    public int maxHealth { get => _maxHealth; set => _maxHealth = value; }

    private int _health;
    private int _maxHealth = 25;

    public event Action<Idestoryable> OnDestory;
    Rigidbody _rb;
    public override void SetUP()
    {
        base.SetUP();
        _rb = GetComponent<Rigidbody>();
    }
    public void Interact(Player player)
    {
        _rb.isKinematic = !_rb.isKinematic;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GameObject gameObject = Instantiate(DropItem, transform.position, transform.rotation);
            OnDestory?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
