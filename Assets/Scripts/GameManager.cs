using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //GameObjects
    Camera camera;
    GameObject player;
    GameObject tile;
    UIController ui;
    Button button1;
    Button button2;

    //Components
    Player playerComponent;
    Tile tileComponent;

    //Other pieces
    bool gameActive = true;
    float currentTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        player = FindObjectOfType<Player>().gameObject;
        playerComponent = player.GetComponent<Player>();
        tile = FindObjectOfType<StartTile>().gameObject;
        tileComponent = tile.GetComponent<Tile>();
        ui = FindObjectOfType<UIController>();
        button1 = ui.button1;
        button2 = ui.button2;
        button1.onClick.AddListener(RestartGame);
        button2.onClick.AddListener(ExitGame);

        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameActive);
        if (gameActive)
        {
            GetMouseInput();
            currentTime += Time.deltaTime;
            ui.UpdateTimer(currentTime);

            if(tileComponent.isEndTile)
            {
                gameActive = false;
                ui.ShowWinText("Victory!\nTime Taken: " + (int)currentTime + " seconds");
                ui.ShowButtons();
                ui.hideTimer();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

    }

    void InitializeGame()
    {
        player.transform.position = tile.transform.position;
    }
    void GetMouseInput()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.CompareTag("Tiles") && tileComponent.validTile(hitObject))
                { 
                    MovePlayer(playerComponent.CanMove(), hitObject);
                }
            }
        }
    }

    void MovePlayer(bool canMove, GameObject tile)
    {
        if (canMove)
        {
            tile = tile.transform.gameObject;
            tileComponent = tile.GetComponent<Tile>();
            Debug.Log("Tile: " + tile.name);
            playerComponent.Move(tile.transform.position, tileComponent.getValue());
        }
    }

    void RestartGame()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    void ExitGame()
    {
        Application.Quit();
    }

}
