using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spacner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private EnemyMove[] _bonuses;
    private List<EnemyMove> enemy = new List<EnemyMove>();
    private int R;
    private void Awake()
    {
        for (int i = 0; i < 50; i++)
        {
            enemy.Add(Instantiate(_prefabEnemy, transform.position, Quaternion.identity).GetComponent<EnemyMove>());
            enemy[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
       
        InvokeRepeating("OnActiveEnemy", 0.2f, 0.2f);
    }
    private void OnActiveEnemy()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            if (!enemy[i].gameObject.activeInHierarchy)
            {
                R = enemy[i].OnThisObject(R);
                break;
            }
        }
    }
    public void OffAllActiveObject()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i].gameObject.activeInHierarchy)
            {
                enemy[i].AnimationDeath();
            }
        }
    }
}
