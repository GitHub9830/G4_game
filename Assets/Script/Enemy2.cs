using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy2 : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float movespeed;
    private Rigidbody2D rigidBody;
// Start is called before the first frame update
void Start()
{
    rigidBody = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update()
{
    if (rigidBody.velocity.magnitude < 10.0f)
    {
        rigidBody.AddForce(new Vector2(-30, 0)); // 力を加える
    }
}
private void Move()
{
    rigidBody.velocity = new Vector2(Vector2.left.x * movespeed, rigidBody.velocity.y);
    {
        transform.Translate(new Vector3(movespeed * Time.deltaTime, 0, 0));
    }

}
}