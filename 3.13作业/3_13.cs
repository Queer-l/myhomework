public abstract class Shape
{
    public abstract double getSquare();

    public abstract bool islegal();

    public abstract void display();
}

public enum ShapeType
{
    Circle,
    Rectangle,
    Square,
}

public class Circle : Shape
{
    public Circle(double radius)
    {
        this.radius = radius;
    }
    public double radius;
    public override double getSquare()
    {
        //计算圆的面积
        return Math.PI * radius * radius;
    }

    public  override bool islegal()
    {
        //判断圆是否合法
       if(radius > 0)
       {
           return true;
       }
       else
       {
           return false;
       }
    }

    public override void display()
    {
        Console.WriteLine("Circle with radius: " + radius);
    }
}

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }
    public double width;
    public double height;
    public override double getSquare()
    {
        //计算矩形的面积
        return width * height;
    }

    public override bool islegal()
    {
        //判断矩形是否合法
        if(width > 0 && height > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void display()
    {
        Console.WriteLine("Rectangle with width: " + width + " and height: " + height);
    }
}

public class Square : Shape
{
    public Square(double side)
    {
        this.side = side;
    }
    public double side;
    public override double getSquare()
    {
        //计算正方形的面积
        return side * side;
    }

    public override bool islegal()
    {
        //判断正方形是否合法
        if (side > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void display()
    {
        Console.WriteLine("Square with side: " + side);
    }
}




public class Worker
{

    public Shape generateShape(ShapeType type)
    {   Random random = new Random();
        switch (type)
        {
            
            case ShapeType.Circle:
                return new Circle(random.Next(1, 11));
            case ShapeType.Rectangle:
                return new Rectangle(random.Next(1, 11), random.Next(1, 11));
            case ShapeType.Square:
                return new Square(random.Next(1, 11));
            default:
                throw new ArgumentException("Invalid shape type");
        }
    }

    public static void Main( string[] args)
    {
        Worker worker = new Worker();
        Shape[] shapes = new Shape[10];
        Random random = new Random();
        for(int i =0 ; i<10 ;i++)
        {
            shapes[i] = worker.generateShape((ShapeType)random.Next(0, 3));
            shapes[i].display();
        }

        double totalArea = 0;
        foreach(var shape in shapes)        {
            if(shape.islegal())
            {
                totalArea += shape.getSquare();
            }
        }
        Console.WriteLine("Total area of legal shapes: " + totalArea);
    }
}