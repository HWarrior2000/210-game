using Raylib_cs;

public class Player : GameObject
{
    private int _health;
    private int _score;
    public Player(int x, int y, int width, int height) : base(x, y, width, height)
    {
        _health = 3;
        _score = 0;
        _speed = 8;
    }
    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, Color.Blue);
        Raylib.DrawText($"Score: {_score}\nLives: {_health}", GetLeftEdge(), GetBottomEdge() + 2, 12, Color.Black);
    }

    public override void Move()
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            _x -= _speed;
            if (GetLeftEdge() < 0)
            {
                _x = 0;
            }
        }
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            _x += _speed; 
            if (GetRightEdge() > GameManager.SCREEN_WIDTH)
            {
                _x = GameManager.SCREEN_WIDTH - _width;
            }
        }
    }

    public override void CollideWith(GameObject thing)
    {
        if (thing is Treasure treasure) // this is checking the type of object it is and then casting it to that type I could just make a private variable of what type all the gameObjeccts are but this is eayer and built in.
        {
            _score += treasure.GetPoints();
        }
        if (thing is Bomb bomb)
        {
            _health -= bomb.GetDamage();
            if (_health == 0)
            {
                _alive = false;
            }
        }
    }
}