using Raylib_cs;

public class Treasure : GameObject
{
    private int _points;
    private Random _random;
     public Treasure(int x, int y) : base(x, y, 20, 20)
    {
        _random = new Random();
        _points = _random.Next(1, 6);
        _speed = _random.Next(5, 10);
    }
     public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, Color.Green);
        Raylib.DrawText($"{_points}", _x + (int)(_width * .375), _y + (_width/3), _width / 2, Color.Black);
    }

    public override void Move()
    {
        _y += _speed;
        if (GetTopEdge() > GameManager.SCREEN_HEIGHT)
        {
            _alive = false;
        }
        if (GetRightEdge() > GameManager.SCREEN_WIDTH)
        {
            _x = GameManager.SCREEN_WIDTH - _width;
        }
        if (GetLeftEdge() < 0)
        {
            _x = 0;
        }
    }
    public override void CollideWith(GameObject thing)
    {
        if(thing is Player)
        {
            _alive = false;
        }
    }

    public int GetPoints()
    {
        return _points;
    }
}