namespace LiskovSubstution;
public static class GeometryLibrary {
    //public static Rectangle RectangleFactory() {
    //    // bir biçimde, Square döndürmeye karar verdik.
    //    return new Square();
    //}

    public static IAreaCalcutable RectangleFactory(Int32 unit1, Int32? unit2 = null) {
        if(unit2.HasValue) {
            return new Rectangle() { With = unit1, Height = unit2.Value };
        }

        return new Square() { EdgeLength = unit1 };
    }
}

public interface IAreaCalcutable {
    public Double GetArea();
}

public class Rectangle : IAreaCalcutable {
    public Int32 With { get; set; }
    public Int32 Height { get; set; }

    public Double GetArea() {
        //if(this is Square) { bu gibi işlemler miras içinde yapılamaz
        //    throw new Exception("");
        //}
        return this.With * this.Height;
    }
}

public class Square : IAreaCalcutable { //: Rectangle {
                                        //    public override Int32 With { get => base.With; set { base.With = value; base.Height = value; } }
                                        //    public override Int32 Height { get => base.With; set { base.With = value; base.Height = value; } }
    public Int32 EdgeLength { get; set; }

    public Double GetArea() {
        return this.EdgeLength * this.EdgeLength;
    }
}