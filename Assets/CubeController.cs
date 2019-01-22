using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

	AudioSource audiosource;

    // Use this for initialization
    void Start()
    {
		this.audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
			
    }
	//型　Collision　変数名　other
	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.CompareTag ("GroundTag")) {
			this.audiosource.Play ();
		} else if (other.gameObject.CompareTag ("CubeTag")) {
			this.audiosource.Play ();
		}   
		}
}