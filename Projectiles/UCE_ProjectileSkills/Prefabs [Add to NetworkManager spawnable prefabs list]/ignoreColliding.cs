using UnityEngine;
using System.Collections;

public class ignoreColliding : MonoBehaviour
{
    public string TagToIgnore = "IgnoreCollision";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagToIgnore)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
