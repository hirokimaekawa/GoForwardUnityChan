using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour
{
    // キューブのPrefab
    public GameObject cubePrefab;

    // 時間計測用の変数
    //最初に入れておく数
    private float delta = 0;

    // キューブの生成間隔
    private float span = 1.0f;

    // キューブの生成位置：X座標
    private float genPosX = 12;

    // キューブの生成位置オフセット
    private float offsetY = 0.3f;
    // キューブの縦方向の間隔
    private float spaceY = 6.9f;

    // キューブの生成位置オフセット
    private float offsetX = 0.5f;
    // キューブの横方向の間隔
    private float spaceX = 0.4f;

    // キューブの生成個数の上限
    private int maxBlockNum = 4;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //「Time.deltaTime」でフレーム間の時間の差分を取得できます。
        //メンバ変数は、クラスに定義してある変数 クラスのインスタンスが生成、生まれてから消失するまで、データを保持する
        //1秒に60回　１秒に何回更新されるかは変わっていく
        this.delta += Time.deltaTime;
        //deltaにdeltaTimeに足して、代入している。
        //1秒間に６０回アップデートが呼び出される
        //１フレーム、一コマ　1/60 これが平均0.0167これがdeltaTimeに入ってくる
        //

        // span秒以上の時間が経過したかを調べる
        if (this.delta > this.span)
        {
            this.delta = 0;
            // 生成するキューブ数をランダムに決める
            // nがローカル変数　限られたスコープの中でしか使えない
			//スコープ{}とは、47-60のこと、関数の範囲、if文の範囲　変数の有効範囲をしている。
            int n = Random.Range(1, maxBlockNum + 1);

			//for(変数初期化; ループ条件式; 変数の更新)
			//{
			//	繰り返したい処理;
			//}
            // 指定した数だけキューブを生成する
            //
			for (int i = 0; i < n; i++)
            {
                // キューブの生成
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            // 次のキューブまでの生成時間を決める
            this.span = this.offsetX + this.spaceX * n;



        }
    }
}