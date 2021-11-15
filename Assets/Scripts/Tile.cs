using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    //Core Values
    [SerializeField] int value = 1;
    [SerializeField] bool isRandom = true;
    [SerializeField] public bool isEndTile = false;

    //Gameobject References
    GameObject textObject;
    GameObject tileLeft;
    GameObject tileUp;
    GameObject tileRight;

    //Components References
    SpriteRenderer sprite;
    TextMesh text;
    RectTransform rect;
    Collider2D ownCollider;

    //Dirty Flags
    bool dirtyGraphics = true;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        textObject = gameObject.transform.GetChild(0).gameObject;
        text = textObject.GetComponent<TextMesh>();
        rect = gameObject.GetComponent<RectTransform>();
        ownCollider = gameObject.GetComponent<PolygonCollider2D>();

        InitializeAdjacentTiles();

        if(isRandom)
        {
            value = Random.Range(1, 5);
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpriteGraphics();
    }

    //Tile Functions

    void UpdateSpriteGraphics()
    {
        if (dirtyGraphics)
        {
            switch (value)
            {
                case -1:
                    sprite.color = Color.red;
                    text.text = "";
                    break;

                case 0:
                    sprite.color = Color.grey;
                    text.text = "";
                    break;

                case 1:
                    sprite.color = Color.white;
                    text.text = "1";
                    break;

                case 2:
                    sprite.color = Color.white;
                    text.text = "2";
                    break;

                case 3:
                    sprite.color = Color.white;
                    text.text = "3";
                    break;

                case 4:
                    sprite.color = Color.white;
                    text.text = "4";
                    break;

                case 5:
                    sprite.color = Color.white;
                    text.text = "5";
                    break;

                default:
                    break;

            }
            dirtyGraphics = false;
        }
    }

    void UpdateSpriteValue(int value)
    {
        this.value = value;
        dirtyGraphics = true;
    }

    void InitializeAdjacentTiles()
    {
        //Debug.Log("Intizliaing " + gameObject.name + "'s Adjacent Tiles... ");
        Vector2 curPos2D = new Vector2(transform.position.x, transform.position.y);
        float upDist = (float)rect.sizeDelta.y * 0.6f;
        float sideDist = (float)rect.sizeDelta.x * 0.8f;

        Vector2 diagonal = new Vector2(sideDist, upDist);
        float distance = diagonal.magnitude * .6f;

        RaycastHit2D[] upHit = Physics2D.RaycastAll(curPos2D, Vector2.up, upDist);
        RaycastHit2D[] leftHit = Physics2D.RaycastAll(curPos2D, new Vector2(-1 * sideDist, upDist), distance);
        RaycastHit2D[] rightHit = Physics2D.RaycastAll(curPos2D, new Vector2(sideDist, upDist), distance);

        for(int i = 0; i < leftHit.Length; i++)
        {
            if (leftHit[i].collider != null && leftHit[i].collider != ownCollider)
            {
                if (leftHit[i].transform.CompareTag("Tiles"))
                {
                    tileLeft = leftHit[i].transform.gameObject;
                    //Debug.Log(gameObject.name + "'s tileLeft: " + tileLeft.name);
                }
            }
        }

        for (int i = 0; i < upHit.Length; i++)
        {
            if (upHit[i].collider != null && upHit[i].collider != ownCollider)
            {
                if (upHit[i].transform.CompareTag("Tiles"))
                {
                    tileUp = upHit[i].transform.gameObject;
                    //Debug.Log(gameObject.name + "'s tileUp: " + tileUp.name);
                }
            }
        }

        for (int i = 0; i < rightHit.Length; i++)
        {
            if (rightHit[i].collider != null && rightHit[i].collider != ownCollider)
            {
                if (rightHit[i].transform.CompareTag("Tiles"))
                {
                    tileRight = rightHit[i].transform.gameObject;
                    //Debug.Log(gameObject.name + "'s tileRight: " + tileRight.name);
                }
            }
        }

    }

    public int getValue()
    {
        return value;
    }

    public bool validTile(GameObject tile)
    {
        if (tile == tileLeft || tile == tileRight || tile == tileUp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
