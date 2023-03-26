namespace OpenClosed;
public abstract class Shape {
    public abstract Double Area();
    protected virtual Type ShapeType => typeof(Shape);

    public void Print() {
        String shapeName = this.ShapeType.Name.EndsWith(nameof(Shape), StringComparison.InvariantCultureIgnoreCase)
            && this.ShapeType.Name is not nameof(Shape)
            ? this.ShapeType.Name[..^nameof(Shape).Length]
            : this.ShapeType.Name;

        Console.WriteLine($"Area of the {shapeName}: {this.Area():.##}");
    }
}

public class SquareShape : Shape {
    public Edge Edge { get; init; }
    protected override Type ShapeType => typeof(SquareShape);

    public SquareShape(Edge edge) {
        this.Edge = edge;
    }

    public override Double Area() {
        return Math.Pow(this.Edge.Value, 2);
    }
}

public class RectangleShape : Shape {
    public Width Width { get; init; }
    public Height Height { get; init; }
    protected override Type ShapeType => typeof(RectangleShape);

    public RectangleShape(Width width, Height height) {
        this.Width = width;
        this.Height = height;
    }

    public override Double Area() {
        return this.Width.Value * this.Height.Value;
    }
}

public class CircleShape : Shape {
    public Radius Radius { get; init; }
    protected override Type ShapeType => typeof(CircleShape);

    public CircleShape(Radius radius) {
        this.Radius = radius;
    }

    public override Double Area() {
        return Math.PI * Math.Pow(this.Radius.Value, 2);
    }
}

public class TriangleShape : Shape {
    public Base Base { get; init; }
    public Height Height { get; init; }
    protected override Type ShapeType => typeof(TriangleShape);

    public TriangleShape(Base @base, Height height) {
        this.Base = @base;
        this.Height = height;
    }

    public override Double Area() {
        return this.Base.Value * this.Height.Value * .5;
    }
}

public record Edge(Double Value);
public record Width(Double Value);
public record Height(Double Value);
public record Radius(Double Value);
public record Base(Double Value);