﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointforPlayer : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    private float _x;
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,_speed * Time.deltaTime));
        if (Input.GetKeyDown(KeyCode.E))
        {
            position();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (player._isDeath == false)
            {
                position();

            }
        }
    }
    private void position()
    {
        _x = Random.Range(0, 260);
        transform.position = new Vector2(Mathf.Cos(_x), Mathf.Sin(_x)) * _distance;
    }
}
