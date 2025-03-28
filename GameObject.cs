using System.Dynamic;

public abstract class GameObject
{
    protected int _x;
    protected int _y;
    protected int _width;
    protected int _height;
    protected int _speed;
    protected bool _alive;

    public GameObject(int x, int y, int width, int height)
    {
        _x = x; 
        _y = y;
        _width = width;
        _height = height;
        _alive = true;
    }

    public virtual int GetLeftEdge()
    {
        return _x;
    }
    public virtual int GetRightEdge()
    {
        return _x + _width;
    }
    public virtual int GetTopEdge()
    {
        return _y;
    }
    public virtual int GetBottomEdge()
    {
        return _y + _height;
    }
    public bool IsAlive()
    {
        return _alive;
    }
    public abstract void Draw();
    public abstract void Move();
    public abstract void CollideWith(GameObject thing);
}