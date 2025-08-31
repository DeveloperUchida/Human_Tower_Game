using UnityEngine;
using TMPro;
using System.Data.Common;
using System.Collections;

[RequireComponent(typeof(AudioSource))] //AudioSorceコンポーネントが必要

public class GameManagerScripts : MonoBehaviour
{
    [SerializeField] GameObject[] characters; //生成するキャラクターの参照
    bool isGene = false; //キャラクターの生成フラグ判定
    GameObject GebeCamera; //生成されたキャラクター
    bool isInterval = false; //キャラクター生成の間隔を調整を制御するフラグ
    bool isButtonHover = false; //ボタンがホバーざれているかどうかの判定
    bool isButtonReleasedOnButton = false; //ボタンから指を離した直後
    public static bool isGameOver = false; //ゲームオーバー状態を管理
    int score; //スコアを管理
    [SerializeField] TextMeshProUGUI scoreText; //スコア表示TextMeshProUGUI

    [SerializeField] AudioClip fallSE; //ゲームオーバー時の効果音
    [SerializeField] AudioClip rotateSE; //画像回転時の効果音
    AudioSource audioSource; //AudioSourceの変数宣言
    bool isGameStarted = false; //ゲーム開始状態を管理
    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始時の初期化
        isGameOver = false; //ゲームオーバーフラグを無効へ
        isGene = false; //キャラクター生成フラグを無効へ
        isInterval = false; //間隔制御フラグを無効へ
        isButtonHover = false; //ボタンのホバー状態を無効へ

        audioSource = GetComponent<AudioSource>();

        score = 0;

        isGameStarted = false; //ゲーム開始かどうかの判定フラグの初期化

        scoreText.text = score.ToString(); //スコアテキストのアップデート初期化
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーの時はこれ以上ゲームを進行させない
        if (isGameOver)
        {
            return;
        }
        //キャラクターが生成されていないかつキャラが静止している場合
        if (!isGene && !isInterval && !CheckMove())
        {
            CreateCaractor();
            isGene = true;
            if (isGameStarted)
            {
                UpdateScore();
            }
            else
            {
                isGameStarted = true;
            }
        }
        //マウスの左クリックが離された時、かつキャラクターが生成されている場合
        else if (Input.GetMouseButtonUp(0) && isGene && !isButtonHover)
        {
            if (isButtonReleasedOnButton)
            {
                isButtonReleasedOnButton = false; //ボタンから離した時のフラグをリセット
                return; //ボタンを離した直後は何もしない
            }

            //物理挙動を有効へ
            GebeCamera.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            isGene = false; //キャラクター生成フラグをリセットして無効へ
            audioSource.PlayOneShot(fallSE);//ここで落下音を再生
            StartCoroutine(IntervalCoroutine());//キャラクター生成の間隔を調整

        }
        else if (Input.GetMouseButton(0) && isGene && !isButtonHover)
        {
            //マウスの左ボタンが押されている間、キャラクターを移動させる(これはx座標のみ)
            float mousePossitionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            GebeCamera.transform.position = new Vector2(mousePossitionX, transform.position.y);
        }

    }

    public void RotateChactor()
    {
        if (isGene)
        {
            GebeCamera.transform.Rotate(0, 0, -30);//30度ずつ回転
            audioSource.PlayOneShot(rotateSE);//回転時効果音
            isButtonReleasedOnButton = true; //ボタンから離した直後のフラグを有効
        }
    }
    //マウスカーソルの場所を更新
    public void isButtonchange(bool isX)
    {
        isButtonHover = isX; //ボタンの状態を変更
    }
    void CreateCaractor()
    {
        
    }

    iEnumerator IntervalCoroutine()
    {

    }

    bool CheckMove()
    {

    }
    void UpdateScore()
    {

    }
}
