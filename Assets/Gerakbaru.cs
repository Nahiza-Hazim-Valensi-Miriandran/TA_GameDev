using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gerakbaru : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float rentangkanan = 4.46f;
    public float rentangkiri = -4.46f;
    public float respawnHeight = 17.4f;
    public float speedIncreaseRate = 0.1f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < -5.6)
        {
            RespawnObstacle();
        }timer += Time.deltaTime;
        if (timer >=1  && fallSpeed <=10){
            fallSpeed += speedIncreaseRate;
            timer = 0;
        }
    
    }
    void RespawnObstacle()
    {
        float randomX = Random.Range(rentangkiri, rentangkanan); // Atur sesuai dengan lebar layar atau batasan tempat munculnya obstacle
        Vector3 newPosition = new Vector3(randomX, respawnHeight, 0f);
        transform.position = newPosition;
    }
}
