using UnityEngine;
using UnityEngine.Tilemaps;

public class ChickenNpc : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float moveSpeed = 1.5f;
    public float waitTime = 2.0f;
    public float movementRadius = 5.0f;

    private Vector2 targetPosition;
    private float waitTimer;
    private Vector2 startPosition;
    private bool isMoving = false;
    public Tilemap collisionTilemap;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startPosition = transform.position;
        waitTimer = waitTime;
        ChooseNewTargetPosition();
    }

    void Update()
    {
        if (isMoving)
        {
            Vector2 newPosition = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
            rb.MovePosition(newPosition);

            Vector2 direction = (newPosition - rb.position).normalized;

            if (direction.sqrMagnitude > 0.01f)
            {
                anim.SetFloat("moveX", direction.x);
                anim.SetFloat("moveY", direction.y);
            }

            if (Vector2.Distance(transform.position, targetPosition) < 0.05f)
            {
                StopMovement();
            }
        }
        else
        {
            anim.SetBool("isMove", false);

            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                ChooseNewTargetPosition();
            }
        }
    }

    void ChooseNewTargetPosition()
    {
        waitTimer = waitTime;

        Vector2 randomDirection = Random.insideUnitCircle * movementRadius;
        Vector2 newTarget = startPosition + randomDirection;

        targetPosition = newTarget;
        isMoving = true;

        anim.SetBool("isMove", true);
    }

    void StopMovement()
    {
        isMoving = false;
        anim.SetBool("isMove", false);
        waitTimer = waitTime;
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        Vector3Int cellPosition = collisionTilemap.WorldToCell(targetPosition);
        TileBase tile = collisionTilemap.GetTile(cellPosition);

        return tile == null;
    }
}