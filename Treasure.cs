using Raylib_cs;

public class Treasure : GameObject
{
     public Treasure(int x, int y) : base(x, y)
    {

    }
     public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, 50, 10, Color.Blue);
    }

    public override void Move()
    {
        throw new NotImplementedException();
    }
}