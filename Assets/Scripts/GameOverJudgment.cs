using UnityEngine;

public class GameOverJudgment : MonoBehaviour
{
    [SerializeField] GameObject resultPanel;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caractor"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            
            // デバッグ情報を出力
            Debug.Log($"キャラクター '{collision.name}' がトリガーに接触");
            Debug.Log($"現在のゲーム状態 - isGameOver: {GameManagerScripts.isGameOver}");
            Debug.Log($"キャラクター状態 - BodyType: {rb.bodyType}, Velocity: {rb.linearVelocity.magnitude}");
            
            // ゲームオーバーでない場合のみ処理
            if (!GameManagerScripts.isGameOver)
            {
                // キャラクターが静止している場合のみゲームオーバー
                if (rb.bodyType == RigidbodyType2D.Dynamic && rb.linearVelocity.magnitude < 0.1f)
                {
                    Debug.Log("ゲームオーバー条件を満たしました");
                    GameOver();
                }
                else
                {
                    Debug.Log("キャラクターは落下中のため、ゲームオーバーにしません");
                    return; // 落下中のキャラクターは削除しない
                }
            }
            
            // キャラクター削除
            Debug.Log($"キャラクター '{collision.name}' を削除します");
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        Debug.Log("ゲームオーバー処理を開始");
        GameManagerScripts.isGameOver = true;
        resultPanel.SetActive(true);
    }
}