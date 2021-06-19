using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform center;
    [SerializeField] private Ui _ui;
    public bool _isDeath { set; get;}
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var pos = transform.position - center.position;
        var z = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -z);
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    public void botton()
    {
        _speed *= -1;
        _rigidbody.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyMove>(out EnemyMove enemyMove))
        {
            _isDeath = true;
            _ui.ConditionGame(true, 0.05f);
        }
        if(collision.TryGetComponent<Bonus>(out Bonus bonus))
        {
            if(_isDeath == false)
            _ui.ScoreCount(1);
        }
       
    }
   
}
