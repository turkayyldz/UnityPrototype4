using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed=3.0f;
    Rigidbody _enemyRb;
    GameObject _player;
    private void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }
    private void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * _speed);
        if (transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
