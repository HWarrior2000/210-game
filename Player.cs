using Raylib_cs;

public class Player : GameObject
{
    public Player(int x, int y) : base(x, y)
    {

    }
    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, 50, 10, Color.Blue);
    }

    public override void Move()
    {
        if (_x - 5 > 0 && _x + 5 < 800) 
        {
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                _x -= 5;
            }
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                _x += 5; 
            }
        }
    }
        // 0-800
    
}