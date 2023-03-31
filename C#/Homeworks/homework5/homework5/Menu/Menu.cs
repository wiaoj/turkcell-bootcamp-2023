using homework5.Extensions;
using homework5.Services.Abstracts;

namespace homework5.Menu;
public partial class Menu {
    private readonly IStudentService studentService;
    private readonly ITeacherService teacherService;
    private readonly IClassService classService;
    private readonly IHomeworkService homeworkService;

    private Menu(IStudentService studentService,
                 ITeacherService teacherService,
                 IClassService classService,
                 IHomeworkService homeworkService) {
        this.studentService = studentService;
        this.teacherService = teacherService;
        this.classService = classService;
        this.homeworkService = homeworkService;
    }

    private ConsoleMenu CreateMainMenu() {
        ConsoleMenu rootMenu = new(Messages.Root.Title, ConsoleKey.Spacebar);

        String[] rootMenuInfos = {
            new(Messages.Root.FirstInfo),
            new(Messages.Root.SecondInfo),
            new(Messages.Root.ThirdInfo),
        };

        rootMenu.AddInfo(rootMenuInfos);
        return rootMenu;
    }

    private ConsoleMenu CreateMenus() {
        ConsoleMenu rootMenu = this.CreateMainMenu();

        rootMenu.AddSubMenu(this.CreateStudentMenu());
        rootMenu.AddSubMenu(this.CreateTeacherMenu());
        rootMenu.AddSubMenu(this.CreateClassMenu());
        rootMenu.AddSubMenu(this.CreateHomeworkMenu());

        return rootMenu;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="root"></param>
    /// <param name="menus"></param>
    /// <returns>root menu</returns>
    private ConsoleMenu CreateSubMenu(ConsoleMenu root, params ConsoleMenu[] menus) {
        menus.ToList().ForEach(root.AddSubMenu);
        return root;
    }

    public static Menu Create(IStudentService studentService, ITeacherService teacherService, IClassService classService, IHomeworkService homeworkService) {
        return new(studentService, teacherService, classService, homeworkService);
    }

    public void Print(ref Boolean isQuit) {
        ConsoleMenu rootMenu = this.CreateMenus();

        ConsoleMenu selectedMenu = rootMenu;
        ConsoleMenu? previousMenu = null;

        this.WriteConsoleLine(rootMenu.Info);
        this.WriteConsoleLine(rootMenu.ToString());

        do {
            this.WriteConsole(ConsoleColor.Red, Messages.ProcessWaiting);
            ConsoleKeyInfo selectedKey = Console.ReadKey();

            MenuState.State(selectedKey, ref isQuit, rootMenu, ref selectedMenu, ref previousMenu);
        } while(isQuit is false);
    }
}