using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _rotationObj;
    [SerializeField] private Transform _center;
    private Animator _animator;
    private bool isDeath = false;
    private Vector3 _rotaionSpeed;
    private void Start()
    {
        _rotaionSpeed = rotation();
        _animator = GetComponent<Animator>();
        _center = FindObjectOfType<Spacner>().transform;
    }
    public int OnThisObject(int rotation)
    {
        var x = Random.Range(0, 360);
       
       
        if ( x > rotation - 10 && x < rotation + 10)
        {
            x += Random.Range(20, 40);
        }
        Quaternion R = Quaternion.Euler(Vector3.forward * x);
        gameObject.SetActive(true);
        transform.rotation = R;
        return x;
       
    }

    public void AnimationDeath()
    { 
        isDeath = true;
        _animator.SetTrigger("Active");
    }
    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, _center.position) > 2)
        {
            AnimationDeath();
        }
    }
    private Vector3 rotation()
    {
        var z = Vector3.forward * 180 * Time.deltaTime;
        return z * Random.Range(1, -1);
    }
    public void OffThisObject()
    {
        transform.position = Vector2.zero;
        transform.localScale = new Vector3(1,1,1);
        isDeath = false;
        gameObject.SetActive(false);
    }
}
