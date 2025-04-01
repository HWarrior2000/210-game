using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;
    private List<GameObject> _gameObjects = new List<GameObject>();
    private double _spawnTimer = 0;
    private double _nextSpawnTime;
    Random _random = new Random();

    public GameManager()
    {
        _title = "CSE 210 Game";
    }

    /// <summary>
    /// The overall loop that controls the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();

        InitializeGame();

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawElements();

            Raylib.EndDrawing();
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        Player player1 = new Player(SCREEN_WIDTH / 2, 550, 60, 10);
        _gameObjects.Add(player1);
        SetNextSpawnTime();
    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {

    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {
        //handle movement
        foreach(GameObject item in _gameObjects)
        {
            item.Move();
        }

        // handle collision
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            for (int j = i +1; j < _gameObjects.Count; j++)
            {
                GameObject first = _gameObjects[i];
                GameObject second = _gameObjects[j];

                if (IsCollision(first, second))
                {
                    first.CollideWith(second);
                    second.CollideWith(first);
                }
            }
        }
        //remove object from list if no longer alive
        _gameObjects.RemoveAll(e => !e.IsAlive());
        //this is not good for reasons
        // for (int i = 0; i < _gameObjects.Count; i++)
        // {
        //     GameObject item = _gameObjects[i];
        //     if (!item.IsAlive())
        //     {
        //         _gameObjects.RemoveAt(i); 
        //     }
        // }

        //handle object spawning
        _spawnTimer += Raylib.GetFrameTime();
        if (_spawnTimer >= _nextSpawnTime)
        {
            _gameObjects.Add(SpawnRandomObject());
            _spawnTimer = 0;
            SetNextSpawnTime();
        }
    }

    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        foreach(GameObject item in _gameObjects)
        {
            item.Draw();
        }
    }

    //this checks collision
    private bool IsCollision(GameObject first, GameObject second)
    {
        bool isTouching = false;
        if (first.GetRightEdge() >= second.GetLeftEdge() && first.GetLeftEdge() <= second.GetRightEdge() && first.GetBottomEdge() >= second.GetTopEdge() && first.GetTopEdge() <= second.GetBottomEdge())
        {
            isTouching = true;
        }
        return isTouching;
    }

    // sets time before next object should spawn
    private void SetNextSpawnTime()
    {
        _nextSpawnTime = _random.NextDouble();
    }

    private GameObject SpawnRandomObject()
    {
        int i = _random.Next(2);
        if (i == 0)
        {
            Treasure thing = new Treasure(_random.Next(SCREEN_WIDTH + 1), 0);
            return thing;
        }
        else
        {
            Bomb thing = new Bomb(_random.Next(SCREEN_WIDTH + 1), 0);
            return thing;
        }
    }
}