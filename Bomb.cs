using Raylib_cs;
public class Bomb : GameObject
{
    private int _damage;
    private Random _random;
     public Bomb(int x, int y) : base(x, y, 20, 20)
    {
        _damage = 1;
        _random = new Random();
        _speed = _random.Next(5, 10);
    }
     public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, Color.Red);
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
        if (thing is Player)
        {
            _alive = false;
        }
    }

    public int GetDamage()
    {
        return _damage;
    }
}