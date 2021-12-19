using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 0.1f;
    private Vector2 screenCenter;

    private void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        Vector2 relativeToNull = -(screenCenter - (Vector2)Input.mousePosition);

        if (relativeToNull.x > 0)
        {
            transform.Translate(Vector2.right * relativeToNull.x * Time.deltaTime * moveSpeed);
        } else if (relativeToNull.x < 0)
        {
            transform.Translate(Vector2.left * -(relativeToNull.x) * Time.deltaTime * moveSpeed);
        }
        if (relativeToNull.y > 0)
        {
            transform.Translate(Vector2.up * relativeToNull.y * Time.deltaTime * moveSpeed);
        }
        else if (relativeToNull.y < 0)
        {
            transform.Translate(Vector2.down * -(relativeToNull.y) * Time.deltaTime * moveSpeed);
        }
    }

}
