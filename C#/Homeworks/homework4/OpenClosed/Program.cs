// O - Open/Closed Principle

using OpenClosed;


SquareShape square = new(new Edge(10));
square.Print();

RectangleShape rectangle = new(new Width(10), new Height(7));
rectangle.Print();

CircleShape circle = new(new Radius(10));
circle.Print();

TriangleShape triangle = new(new Base(10), new Height(5));
triangle.Print();

// Bir kare kutu olduğunu düşünürsek, bu kutunun 6 tane karesi vardır
SquareShape boxSurface = new(new Edge(17));
SquareBox box = new(boxSurface);
box.Print();

/*
 * Area of the Square: 100
 * Area of the Rectangle: 70
 * Area of the Circle: 314,16
 * Area of the Triangle: 25
 * Area of the Shape: 1734
*/

public class SquareBox : Shape {
    public const Int32 SURFACE_COUNT = 6;
    public SquareShape SquareShape { get; init; }

    public SquareBox(SquareShape squareShape) {
        this.SquareShape = squareShape;
    }

    public override Double Area() {
        return this.SquareShape.Area() * SURFACE_COUNT;
    }
}