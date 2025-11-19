using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Tilemap collisionTilemap; 

    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isMoving) return;

        input = Vector2.zero;

        if (Keyboard.current.rightArrowKey.isPressed) input.x = 1;
        if (Keyboard.current.leftArrowKey.isPressed) input.x = -1;
        if (Keyboard.current.upArrowKey.isPressed) input.y = 1;
        if (Keyboard.current.downArrowKey.isPressed) input.y = -1;

        if (input.x != 0) input.y = 0;

        if (input != Vector2.zero)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);

            Vector3 targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;
            
            if (IsWalkable(targetPos))
            {
                StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
   private bool IsWalkable(Vector3 targetPosition)
    {
        Vector3Int cellPosition = collisionTilemap.WorldToCell(targetPosition);
        TileBase tile = collisionTilemap.GetTile(cellPosition);
        
        return tile == null;
    }
 
  

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
}