using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectBase : MonoBehaviour
{
    public Vector3 direction;

    public float timetTODestroy = 2f;

    public float side = 1;

    public int damageAmout = 1;

    private void Awake()
    {
        Destroy(gameObject, timetTODestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(damageAmout);
            Destroy(gameObject);
        }
    }


}
  