using UnityEngine;

public class BallBase : MonoBehaviour
{
    private Vector3 _startSpeed;
    public Vector3 speed = new Vector3(10, 15);
    public float incrementSpeed = 0.2f;
    public float yBarrier = 40;

    private Vector3 _startPosition;
    private bool _canMove = false;
    private Rigidbody2D rgb2d;

    private void Awake()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        _startPosition = rgb2d.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("colidiu com um nao player");
            speed.y *= -1;
            rgb2d.velocity = speed;
        }
        else
        {
            OnPlayerCollisionX();
        }
    }

    private void OnPlayerCollisionX()
    {
        Debug.Log("Colidiu com player");
        if (speed.x < 0)
        {
            speed.x -= incrementSpeed;
        }
        else
        {
            speed.x += incrementSpeed;
        }

        speed.x *= -1;
        rgb2d.velocity = speed;
    }

    public void ResetBall()
    {
        speed = new Vector3(0, 0);
        rgb2d.velocity = speed;
        rgb2d.position = _startPosition;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }

    public void StartBall()
    {
        _canMove = true;
        rgb2d.velocity = speed;
    }

    public void ReleaseBall()
    {
        if (_canMove)
        {
            speed = new Vector3(Random.Range(-200, 200), 50);
            rgb2d.velocity = speed;
        }
    }
}
