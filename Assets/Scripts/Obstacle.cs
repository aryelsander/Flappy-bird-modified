using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isHide;
    [SerializeField]
    private float destroyXPosition;

    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
