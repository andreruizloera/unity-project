
using UnityEngine;

public class ArenaTargetDemo : MonoBehaviour
{
    // Field that can be modified in the Unity Inspector.
    public int shotDamage = 30;

    // Requirement 1: Start runs when the game begins.
    void Start()
    {
        Debug.Log("Welcome to the arena!");

        Target normal = new Target("Normal Target", 100);
        Target armored = new ArmoredTarget("Armored Target", 100);

        // Requirement 2: Observable results in the Console.
        FireAt(normal, shotDamage);
        FireAt(armored, shotDamage);

        Debug.Log("Shooting test completed!");
    }

    // Requirement 3a: Custom method with two parameters.
    void FireAt(Target target, int damage)
    {
        // Requirement 3b: Polymorphism.
        // The correct TakeDamage method is called for each target.
        target.TakeDamage(damage);

        // Requirement 3c: Accessing the Health property.
        Debug.Log(target.Name + " has " + target.Health + " HP left.");
    }
}

public class Target
{
    public string Name { get; private set; }
    public int Health { get; protected set; }

    public Target(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public virtual void TakeDamage(int damage)
    {
        // Requirement 3c: Modifying the Health property.
        Health = Mathf.Max(0, Health - damage);
    }
}

// Requirement 3b: Polymorphism through inheritance.
public class ArmoredTarget : Target
{
    public ArmoredTarget(string name, int health)
        : base(name, health)
    {
    }

    public override void TakeDamage(int damage)
    {
        // Armored targets take half damage.
        base.TakeDamage(damage / 2);
    }
}
