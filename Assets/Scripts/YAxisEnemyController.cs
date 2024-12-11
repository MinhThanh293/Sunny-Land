using UnityEngine;

public class YAxisEnemyController : EnemyControllerScript
{
    [SerializeField] private float yVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveY(0f, yVelocity);
    }
}
