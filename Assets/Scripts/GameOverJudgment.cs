using UnityEngine;

public class GameOverJudgment : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caractor"))
        {
            if (GameManagerScripts.isGameOver)
            {
                GameOver();
            }
            Destroy(collision.gameObject); //キャラクター削除
        }
    }

    void GameOver()
    {
        //ゲームオーバー処理を走らせる処理
        resultPanel.SetActive(true); //結果パネルを表示
        GameManagerScripts.isGameOver = true;

    }
}