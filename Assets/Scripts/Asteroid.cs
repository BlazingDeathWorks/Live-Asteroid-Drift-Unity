using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _fallSpeedMin = 1, _fallSpeedMax = 1;
    [SerializeField] private float _sizeMin = 1, _sizeMax = 2;
    private float _rotateSpeed = 1;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rotateSpeed = Random.Range(_fallSpeedMin, _fallSpeedMax);
        transform.localScale = Vector3.one * Random.Range(_sizeMin, _sizeMax);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed * 20 * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(0, -_rotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }

        if (collision.gameObject.CompareTag("Asteroid Destroyer"))
        {
            gameObject.SetActive(false);
            AsteroidSpawner.Instance.ReturnToPool(this);
        }
    }
}
