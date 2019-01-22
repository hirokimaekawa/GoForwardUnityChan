using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    //Animatorクラスのanimator変数を宣言
    Animator animator;
    // 地面の位置
    private float groundLevel = -3.0f;

    //Unityちゃんを移動させるコンポーネントを”入れる”
    //Rigidbody2Dクラスのインスタンスを変数に格納する。箱に入れておく。箱を作るだけ。
    Rigidbody2D rigid2D;

    // ジャンプの速度の減衰
    private float dump = 0.8f;

    // ジャンプの速度
    float jumpVelocity = 20;

	// ゲームオーバになる位置（追加）
	private float deadLine = -9;
    
    // Use this for initialization
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを”取得する”
        //実際に格納するのはここ。
        //＜＞普通はつけない。普通関数は戻り値は同じだが、
        //GetComponent関数はその中で行われる処理が違う。ゆえに戻り値も違う。だから＜＞を使っている。
        //＜＞を付けて同じ名前の関数でも行われる処理がちがうこと、Genericsという。
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        //public void SetFloat (string name, float value);
        //
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        //y軸が地面の-3.0のgroundlevelよりも大きかったら、地面と触れていない、falseである。
        //条件式が真 (true) ならば : の左側が、条件式が偽 (false) ならば : 
		//の右側が左辺（ここでは bool 型の変数 isGround）に代入される。
        //この条件式があっていたら？の隣false、間違っていたらtrueにする。
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        //このbool値は変動しうるため、true or falseを直接入れず、条件によって変化する変数
        this.animator.SetBool("isGround", isGround);

		// ジャンプ状態のときにはボリュームを0にする（追加）
		GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;


        // 着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

		// デッドラインを超えた場合ゲームオーバにする（追加）
		if (transform.position.x < this.deadLine){
			// UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する（追加）
			GameObject.Find("Canvas").GetComponent<UIController> ().GameOver ();

			// ユニティちゃんを破棄する（追加）
			Destroy (gameObject);
		}
    }
}