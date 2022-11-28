using UnityEngine;

public class ObstackesManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float minYPosition;
    [SerializeField] private float maxYPosition;
    [SerializeField] private float startXPosition;
    [SerializeField] private float timeInterval;

    private float _currentTime;
    private void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Begin)
            return;
        ;
        _currentTime += Time.deltaTime;
        if (_currentTime >= timeInterval)
        {
            _currentTime = 0;
            Vector3 instacePosition = new Vector3(startXPosition,
                Random.Range(minYPosition, maxYPosition), transform.position.z);
            Instantiate(obstaclePrefab,instacePosition,Quaternion.identity);
            
        }
    }
}