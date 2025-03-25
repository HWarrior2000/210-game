using Raylib_cs;
public class Bomb : GameObject
{
     public Bomb(int x, int y) : base(x, y)
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