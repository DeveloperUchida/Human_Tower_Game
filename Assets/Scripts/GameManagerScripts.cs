using UnityEngine;
using TMPro;
using System.Data.Common;

public class GameManagerScripts : MonoBehaviour
{
    [SerializeField] GameObject[] Characters; //生成するキャラクターの参照
    bool isGene = false; //キャラクターの生成フラグ判定
    GameObject GebeCamera; //生成されたキャラクター
    bool isInterval = false; //キャラクター生成の間隔を調整を制御するフラグ
    bool isButtonHover = false; //ボタンがホバーざれているかどうかの判定
    bool isButtonReleasedOnButton = false; //ボタンから指を離した直後
    public static bool isGameOver = false; //ゲームオーバー状態を管理
    int score; //スコアを管理
    [SerializeField] TextMeshProUGUI scoreText; //スコア表示TextMeshProUGUI
    bool isGameStarted = false; //ゲーム開始状態を管理
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
