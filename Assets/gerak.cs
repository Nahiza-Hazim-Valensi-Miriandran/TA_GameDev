using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gerak : MonoBehaviour
{
    Text infoskor;
    public int score = 0;
    public float speed = 5f;
    public float leftBound; // Batas kiri
    public float rightBound; // Batas kanan
    float speedIncreaseRate;
    float timer;
    float kecepatan;
    Rigidbody2D rb;
    private bool tabrak;
    public LayerMask targetLayer;
    public Transform deteksiTabrak;
    public float jangkauan;
    public int bataskecepatan = 11;

    // Start is called before the first frame update
    void Start()
    {
        // infoskor = GameObject.Find("uiscore").GetComponent<Text>();
        // if (infoskor == null){
        //     print("uiscore tidak ditemukan");
        // }
        rb = GetComponent<Rigidbody2D>();
        speedIncreaseRate = 0.1f;
        kecepatan = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        // infoskor.text = score.ToString();
        tabrak = Physics2D.OverlapCircle(deteksiTabrak.position, jangkauan, targetLayer);
        if (tabrak){
               print("terjadi tabrakan!");

            }
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(movement.x * kecepatan, rb.velocity.y);
        float clampedX = Mathf.Clamp(rb.position.x, leftBound, rightBound);
        rb.position = new Vector2(clampedX, rb.position.y);
        timer += Time.deltaTime;
        if (timer >= 1 && kecepatan <= bataskecepatan){
            kecepatan += speedIncreaseRate;
            score++;
            timer = 0;
        }if (timer >= 1 && kecepatan >= bataskecepatan){
            score++;
            timer = 0;
        }
    }
}

