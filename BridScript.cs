using UnityEngine;

public class BridScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool BirdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
            {
                myRigidbody.linearVelocity = Vector2.up*flapStrength;

            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        BirdIsAlive = false;
    }
}
