using homework5.Entities;
using homework5.Extensions;

namespace homework5.Menu;
public partial class Menu {
    private ConsoleMenu CreateClassMenu() {
        ConsoleMenu operationClassMenu = new(Messages.Class.OperationTitle, ConsoleKey.D1);
        ConsoleMenu listClassMenu = new(Messages.Class.ListTitle, ConsoleKey.D2);
        ConsoleMenu searchClassMenu = new(Messages.Class.SearchTitle, ConsoleKey.D3);

        operationClassMenu.AddRangeSubMenu(this.CreateClassOperationMenus());
        listClassMenu.AddRangeSubMenu(this.CreateClassListMenus());
        searchClassMenu.AddRangeSubMenu(this.CreateClassSearchMenus());

        ConsoleMenu[] classSubMenus = {
            operationClassMenu,
            listClassMenu,
            searchClassMenu,
        };

        ConsoleMenu classMenu = this.CreateSubMenu(new(Messages.Class.Title, ConsoleKey.D3), classSubMenus);

        return classMenu;
    }

    private ConsoleMenu[] CreateClassOperationMenus() {
        void AddClass() {
            String className = this.ReadConsoleLine(ConsoleColor.Blue, Messages.Class.Name, Messages.Class.NameIsEmpty);

            String teacherId = this.ReadConsoleLine(ConsoleColor.Blue, Messages.Class.TeacherId, Messages.Class.TeacherIdIsEmpty);

            ClassEntity @class = this.classService.AddClass(className, teacherId);

            this.WriteConsoleLine(ConsoleColor.Green, Messages.EntityAddIsSuccess(@class));
        }

        String[] addClassMenuInfos = {
            Messages.Class.AddMenuFirstInfo,
            Messages.Class.AddMenuSecondInfo,
            Messages.Class.AddMenuThirdInfo,
        };

        ConsoleMenu addClassMenu = new(Messages.Class.AddMenuTitle, ConsoleKey.D1);

        addClassMenu.AddInfo(addClassMenuInfos);


        addClassMenu.SetProcess(AddClass);

        ConsoleMenu[] classOperationMenus = {
            addClassMenu,
        };

        return classOperationMenus;
    }

    private ConsoleMenu[] CreateClassListMenus() {
        void ListClass() {
            IEnumerable<ClassEntity> classs = this.CreateClassListMenusProcessGetClasss();
            classs.PrintInConsole();
        }

        void ListClassOrderedByName() {
            IEnumerable<ClassEntity> classs = this.CreateClassListMenusProcessGetClasss();
            classs.OrderBy(x => x.Name).PrintInConsole();
        }

        ConsoleMenu searchClassByIdMenu = new(Messages.Class.ListMenuTitle, ConsoleKey.D1);

        searchClassByIdMenu.SetProcess(ListClass);

        ConsoleMenu searchClassByNameAndMenu = new(Messages.Class.ListSearchMenuTitle, ConsoleKey.D2);

        searchClassByNameAndMenu.SetProcess(ListClassOrderedByName);

        ConsoleMenu[] classListMenus = {
            searchClassByIdMenu,
            searchClassByNameAndMenu
        };

        return classListMenus;
    }

    private IEnumerable<ClassEntity> CreateClassListMenusProcessGetClasss() {
        this.WriteConsoleLine(ConsoleColor.Cyan, Messages.Class.ListedTitle);
        return this.classService.GetAllClasses();
    }

    private ConsoleMenu[] CreateClassSearchMenus() {
        void SearchClassById() {
            String id = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Class.GetId, Messages.Class.IdIsEmpty);
            ClassEntity @class = this.classService.GetClassById(id);

            this.WriteConsoleLine(ConsoleColor.Magenta, @class);
        }

        void SearchClassByName() {
            String className = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Class.Name, Messages.Class.NameIsEmpty);
            IEnumerable<ClassEntity> @class = this.classService.GetClassesByName(className);

            @class.PrintInConsole();
        }

        String[] searchClassSubMenusClassIdInfos = {
            new(Messages.Class.SearchByIdFirstInfo)
        };

        ConsoleMenu searchClassByIdMenu = new(Messages.Class.SearchByIdTitle, ConsoleKey.D1, searchClassSubMenusClassIdInfos);

        searchClassByIdMenu.SetProcess(SearchClassById);


        String[] searchClassSubMenusClassNameInfos = {
            new(Messages.Class.SearchByNameFirstInfo),
            new(Messages.Class.SearchByNameSecondInfo),
            new(Messages.Class.SearchByNameThirdInfo),
        };

        ConsoleMenu searchClassByNameAndMenu = new(Messages.Class.SearchByNameTitle, ConsoleKey.D2);
        searchClassByNameAndMenu.AddInfo(searchClassSubMenusClassNameInfos);

        searchClassByNameAndMenu.SetProcess(SearchClassByName);

        ConsoleMenu[] searchClassSubMenus = {
            searchClassByIdMenu,
            searchClassByNameAndMenu
        };

        return searchClassSubMenus;
    }
}