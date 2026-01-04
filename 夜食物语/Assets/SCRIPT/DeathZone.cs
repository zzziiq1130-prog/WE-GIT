using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // 当有物体进入触发器时调用
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入的物体是不是玩家
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}