using System.Text;

namespace homework5.Menu;
public sealed class ConsoleMenu {
    private Action? MenuProcess;
    private readonly List<String?> info = new();

    public Guid Id { get; }
    public String Name { get; private set; }
    public ConsoleKey MenuKey { get; private set; }
    public List<ConsoleMenu> SubMenus { get; private set; }
    private Int32 parentCount { get; set; }

    public String? Info {
        get {
            if(this.info.Count is default(Int32))
                return String.Empty;

            StringBuilder stringBuilder = new();
            String line = new('-', 25);
            stringBuilder.AppendLine(line);
            this.info.ForEach(item => stringBuilder.AppendLine(item));
            stringBuilder.AppendLine(line);

            return stringBuilder.ToString();
        }
    }

    public ConsoleMenu(String name, ConsoleKey menuKey) {
        this.Id = Guid.NewGuid();
        this.SubMenus = new();
        this.Name = name;
        this.MenuKey = menuKey;
    }

    public ConsoleMenu(String name, ConsoleKey menuKey, String[] infos) : this(name, menuKey) {
        this.AddInfo(infos);
    }

    public void AddSubMenu(ConsoleMenu menu) {
        this.SubMenus.Add(menu);
        menu.parentCount += this.parentCount + 1;

        if(menu.SubMenus.Count is not default(Int32))
            menu.SubMenus.ForEach(subMenu => subMenu.parentCount++);
    }

    public void AddRangeSubMenu(params ConsoleMenu[] menu) {
        menu.ToList().ForEach(this.AddSubMenu);
    }

    public void AddInfo(params String[] values) {
        values.ToList().ForEach(this.info.Add);
    }

    public override String ToString() {
        return $"""
                    {this.Name}
                    {this.PrintSubMenus(this.parentCount)}
                    """;
    }

    public String PrintSubMenus(Int32 tabCount) {
        if(this.SubMenus.Count is default(Int32))
            return String.Empty;

        String subMenus = String.Empty;
        String tabValue = new(' ', tabCount * 2);

        this.SubMenus.ForEach(value => subMenus += $"{tabValue}{value}");

        return $"{subMenus}";
    }

    public void SetProcess(Action action) {
        this.MenuProcess = action;
    }

    public void InvokeProcess() {
        this.MenuProcess?.Invoke();
    }
}