using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f;
    [SerializeField] bool _hasPowerup;
    [SerializeField] GameObject _powerupIndicator;
    float _powerupStrength = 15.0f;
    Rigidbody playerRb;
    GameObject focalPoint;
    
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * _speed * forwardInput);
        _powerupIndicator.transform.position = transform.position+ new Vector3(0,-0.5f,0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            _powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowrupContdownRoutine());
        }
    }

    IEnumerator PowrupContdownRoutine()
    {

        yield return new WaitForSeconds(7);
        _hasPowerup = false;
        _powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&&_hasPowerup)
        {
            Rigidbody _enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + "with Powerup set to" + _hasPowerup);
            _enemyRigidbody.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
        }
    }
}
