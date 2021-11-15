using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Components
    SpriteRenderer sprite;

    //values
    private bool canMove;
    private bool dirtyColor = true;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    void UpdateSprite()
    {
        if (dirtyColor)
        {
            if (canMove)
            {
                sprite.color = Color.black;
            }
            else
            {
                sprite.color = Color.red;
            }
            dirtyColor = false;
        }
    }

    public void Move(Vector3 pos, int cooldown)
    {
        if (cooldown != 0)
        {
            gameObject.transform.position = pos;
            StartCoroutine(CooldownCo(cooldown));
        }
    }

    public bool CanMove()
    {
        return canMove;
    }

    IEnumerator CooldownCo(int cooldown)
    {
        canMove = false;
        dirtyColor = true;
        yield return new WaitForSeconds(cooldown);
        canMove = true;
        dirtyColor = true;
    }
}
