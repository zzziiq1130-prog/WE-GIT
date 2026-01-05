using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // 每个金币分值

    private void OnTriggerEnter(Collider other)
    {
        // 检查碰撞的是不是玩家
        if (other.CompareTag("Player"))
        {
            // 调用玩家身上的得分方法
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(scoreValue);
            }

            // 可以在这里播放一个拾取音效或特效
            // AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // 销毁金币
            Destroy(gameObject);
        }
    }

    // 让金币转动的小效果（可选）
    void Update()
    {
        transform.Rotate(Vector3.up * 100f * Time.deltaTime);
    }
}