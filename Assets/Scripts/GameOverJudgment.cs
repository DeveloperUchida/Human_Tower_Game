using UnityEngine;

public class GameOverJudgment : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character") && !GameManager.isGameOver)
        {
            GameOver();
            // オブジェクトを先に無効化してから削除
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.1f); // 少し遅延させて削除
        }
    }

    void GameOver()
    {
        // ゲームオーバー処理
        GameManager.isGameOver = true; // 先にゲームオーバー状態を更新
        resultPanel.SetActive(true); // 結果パネルを表示
    }
}