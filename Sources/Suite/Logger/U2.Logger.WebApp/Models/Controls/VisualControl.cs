namespace U2.Logger.WebApp;

#nullable disable

public abstract class VisualControl
{
    public string ViewName { get; set; }

    public string Name { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }
    
    public string Style { get; set; }
}
