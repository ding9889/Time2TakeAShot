using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    // 移动参数
    public float downwardSpeed = 1f;  // 向下移动的速度
    public float horizontalStep = 0.1f;  // 水平漂移的距离
    public float driftProbability = 0.5f;  // 向左漂移的概率
    public int movesPerSecond = 5;  // 每秒移动次数

    private float moveInterval;  // 每次移动的时间间隔
    private float timeSinceLastMove = 0f;  // 距离上次移动的时间累计

    private void Start()
    {
        // 计算每次移动的时间间隔
        moveInterval = 1f / movesPerSecond;
    }

    private void Update()
    {
        // 累积时间
        timeSinceLastMove += Time.deltaTime;

        // 如果累计时间达到移动间隔，则触发移动
        if (timeSinceLastMove >= moveInterval)
        {
            MoveTarget();
            timeSinceLastMove = 0f;  // 重置计时器
        }
    }

    private void MoveTarget()
    {
        // 基本向下移动
        transform.position += new Vector3(0, -downwardSpeed, 0);

        // 随机漂移逻辑
        float randomValue = Random.value; // 生成一个[0, 1]的随机数
        if (randomValue < driftProbability)
        {
            // 向左漂移
            transform.position += new Vector3(-horizontalStep, 0, 0);
        }
        else
        {
            // 向右漂移
            transform.position += new Vector3(horizontalStep, 0, 0);
        }
    }
}

