using homework5.Entities;
using homework5.Extensions;

namespace homework5.Menu;
public partial class Menu {
    private ConsoleMenu CreateTeacherMenu() {
        ConsoleMenu operationTeacherMenu = new(Messages.Teacher.OperationTitle, ConsoleKey.D1);
        ConsoleMenu listTeacherMenu = new(Messages.Teacher.ListTitle, ConsoleKey.D2);
        ConsoleMenu searchTeacherMenu = new(Messages.Teacher.SearchTitle, ConsoleKey.D3);

        operationTeacherMenu.AddRangeSubMenu(this.CreateTeacherOperationMenus());
        listTeacherMenu.AddRangeSubMenu(this.CreateTeacherListMenus());
        searchTeacherMenu.AddRangeSubMenu(this.CreateTeacherSearchMenus());

        ConsoleMenu[] teacherSubMenus = {
            operationTeacherMenu,
            listTeacherMenu,
            searchTeacherMenu,
        };

        ConsoleMenu teacherMenu = this.CreateSubMenu(new(Messages.Teacher.Title, ConsoleKey.D2), teacherSubMenus);

        return teacherMenu;
    }

    private ConsoleMenu[] CreateTeacherOperationMenus() {
        void AddTeacher() {
            String teacherName = this.ReadConsoleLine(ConsoleColor.Blue, Messages.Teacher.Name, Messages.Teacher.NameIsEmpty);

            String teacherLastName = this.ReadConsoleLine(ConsoleColor.Blue, Messages.Teacher.LastName, Messages.Teacher.LastNameIsEmpty);

            TeacherEntity teacher = new(teacherName, teacherLastName);
            this.teacherService.AddTeacher(teacher);

            this.WriteConsoleLine(ConsoleColor.Green, Messages.EntityAddIsSuccess(teacher));
        }

        ConsoleMenu addteacherMenu = new(Messages.Teacher.AddMenuTitle, ConsoleKey.D1);

        addteacherMenu.SetProcess(AddTeacher);

        ConsoleMenu[] teacherOperationMenus = {
            addteacherMenu,
        };

        return teacherOperationMenus;
    }

    private ConsoleMenu[] CreateTeacherListMenus() {
        void ListTeacher() {
            IEnumerable<TeacherEntity> teachers = this.CreateTeacherListMenusProcessGetTeachers();
            teachers.PrintInConsole();
        }

        void ListTeacherOrderedByName() {
            IEnumerable<TeacherEntity> teachers = this.CreateTeacherListMenusProcessGetTeachers();
            teachers.OrderBy(x => x.Name).PrintInConsole();
        }

        ConsoleMenu searchTeacherByIdMenu = new(Messages.Teacher.ListMenuTitle, ConsoleKey.D1);

        searchTeacherByIdMenu.SetProcess(ListTeacher);

        ConsoleMenu searchTeacherByNameAndLastNameMenu = new(Messages.Teacher.ListSearchMenuTitle, ConsoleKey.D2);

        searchTeacherByNameAndLastNameMenu.SetProcess(ListTeacherOrderedByName);

        ConsoleMenu[] teacherListMenus = {
            searchTeacherByIdMenu,
            searchTeacherByNameAndLastNameMenu
        };

        return teacherListMenus;
    }

    private IEnumerable<TeacherEntity> CreateTeacherListMenusProcessGetTeachers() {
        this.WriteConsoleLine(ConsoleColor.Cyan, Messages.Teacher.ListedTitle);
        return this.teacherService.GetAllTeachers();
    }

    private ConsoleMenu[] CreateTeacherSearchMenus() {
        void SearchTeacherById() {
            String id = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Teacher.GetId, Messages.Teacher.IdIsEmpty);
            TeacherEntity teacher = this.teacherService.GetTeacherById(id);

            this.WriteConsoleLine(ConsoleColor.Magenta, teacher);
        }

        void SearchTeacherByNameAndLastName() {
            String teacherName = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Teacher.NameLastName, Messages.Teacher.NameLastNameIsEmpty);
            IEnumerable<TeacherEntity> teachers = this.teacherService.GetTeachersByNameLastName(teacherName);

            teachers.PrintInConsole();
        }

        String[] searchTeacherSubMenusTeacherIdInfos = {
            new(Messages.Teacher.SearchByIdFirstInfo)
        };

        ConsoleMenu searchTeacherByIdMenu = new(Messages.Teacher.SearchByIdTitle, ConsoleKey.D1, searchTeacherSubMenusTeacherIdInfos);

        searchTeacherByIdMenu.SetProcess(SearchTeacherById);


        String[] searchTeacherSubMenusTeacherNameLastNameInfos = {
            new(Messages.Teacher.SearchByNameLastNameFirstInfo),
            new(Messages.Teacher.SearchByNameLastNameSecondInfo),
            new(Messages.Teacher.SearchByNameLastNameThirdInfo),
        };

        ConsoleMenu searchTeacherByNameAndLastNameMenu = new(Messages.Teacher.SearchByNameLastNameTitle, ConsoleKey.D2);
        searchTeacherByNameAndLastNameMenu.AddInfo(searchTeacherSubMenusTeacherNameLastNameInfos);

        searchTeacherByNameAndLastNameMenu.SetProcess(SearchTeacherByNameAndLastName);

        ConsoleMenu[] searchTeacherSubMenus = {
            searchTeacherByIdMenu,
            searchTeacherByNameAndLastNameMenu
        };

        return searchTeacherSubMenus;
    }
}