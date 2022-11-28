using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flyForce;
    [SerializeField] private float mass;
    [SerializeField] private float gravity;
    private Rigidbody _rigidbody;
    
    private bool collectScore;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.useGravity = false;
    }

    public void Initialize()
    {
       // _rigidbody.mass = mass;
        _rigidbody.useGravity = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.gameState == GameManager.GameState.Start)
        {
            Fly();
        }
    }

    private void Fly()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe") )
        {
            GameManager.Instance.Lose();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collectScore = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score") && !collectScore && GameManager.Instance.gameState == GameManager.GameState.Start)
        {
            collectScore = true;
            GameManager.Instance.IncreaseScore();
        }
    }
}
