using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    GameObject scoreTextUIGO;
    float speed;
    public GameObject Explosion;
    void Start()
    {
        speed = 2f;

        scoreTextUIGO = GameObject.FindGameObjectWithTag("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShip" || collision.tag == "PlayerBullet")
        {
            PlayExplosion();

            scoreTextUIGO.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject);


        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}
