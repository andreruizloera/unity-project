using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    // static so every target adds to the same score, not one score per cube
    public static int score = 0;

    public int maxHealth = 100;
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    int health;
    Vector3 startPosition;
    Renderer rend;

    void Start()
    {
        health = maxHealth;
        startPosition = transform.position;
        // GetComponent<> is generic, I tell it Renderer and it gives me that back
        // need it to change the cube color
        rend = GetComponent<Renderer>();
        rend.material.color = Color.green;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPosition + new Vector3(x, 0, 0);
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            score++;
            health = maxHealth;
        }

        float percent = (float)health / maxHealth;
        rend.material.color = Color.Lerp(Color.red, Color.green, percent);
    }
}
