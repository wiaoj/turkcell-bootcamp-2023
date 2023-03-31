using homework5.Entities;
using homework5.Extensions;

namespace homework5.Menu;
public partial class Menu {
    private ConsoleMenu CreateStudentMenu() {
        ConsoleMenu operationStudentMenu = new(Messages.Student.OperationTitle, ConsoleKey.D1);
        ConsoleMenu listStudentMenu = new(Messages.Student.ListTitle, ConsoleKey.D2);
        ConsoleMenu searchStudentMenu = new(Messages.Student.SearchTitle, ConsoleKey.D3);

        operationStudentMenu.AddRangeSubMenu(this.CreateStudentOperationMenus());
        listStudentMenu.AddRangeSubMenu(this.CreateStudentListMenus());
        searchStudentMenu.AddRangeSubMenu(this.CreateStudentSearchMenus());

        ConsoleMenu[] studentSubMenus = {
            operationStudentMenu,
            listStudentMenu,
            searchStudentMenu,
         };

        ConsoleMenu studentMenu = this.CreateSubMenu(new(Messages.Student.Title, ConsoleKey.D1), studentSubMenus);

        return studentMenu;
    }

    private ConsoleMenu[] CreateStudentOperationMenus() {
        void AddStudent() {
            //this.WriteConsole(Messages.Student.Name);

            String studentName = this.ReadConsoleLine(ConsoleColor.Blue, Messages.Student.Name, Messages.Student.NameIsEmpty);

            //this.WriteConsole(Messages.Student.LastName);
            String studentLastName = this.ReadConsoleLine(ConsoleColor.Blue, Messages.Student.LastName, Messages.Student.LastNameIsEmpty);

            StudentEntity student = new(studentName, studentLastName);
            this.studentService.AddStudent(student);

            this.WriteConsoleLine(ConsoleColor.Green, Messages.EntityAddIsSuccess(student));
        }

        void DeleteStudent() {
            //this.WriteConsole(Messages.Student.DeleteId);

            String studentId = this.ReadConsoleLine(ConsoleColor.Red, Messages.Student.DeleteId, Messages.Student.IdIsEmpty);

            this.studentService.DeleteStudentById(studentId);

            this.WriteConsoleLine(ConsoleColor.Green, Messages.EntityDeleteIsSuccess(studentId));
        }

        ConsoleMenu addStudentMenu = new(Messages.Student.AddMenuTitle, ConsoleKey.D1);

        addStudentMenu.SetProcess(AddStudent);

        ConsoleMenu deleteStudentMenu = new(Messages.Student.DeleteMenuTitle, ConsoleKey.D2);

        deleteStudentMenu.SetProcess(DeleteStudent);

        ConsoleMenu[] studentOperationMenus = {
            addStudentMenu,
            deleteStudentMenu
        };

        return studentOperationMenus;
    }

    private ConsoleMenu[] CreateStudentListMenus() {
        void ListStudent() {
            IEnumerable<StudentEntity> students = this.CreateStudentListMenusProcessGetStudents();
            students.PrintInConsole();
        }

        void ListStudentOrderedByName() {
            IEnumerable<StudentEntity> students = this.CreateStudentListMenusProcessGetStudents();
            students.OrderBy(x => x.Name).PrintInConsole();
        }

        ConsoleMenu searchStudentByIdMenu = new(Messages.Student.ListMenuTitle, ConsoleKey.D1);

        searchStudentByIdMenu.SetProcess(ListStudent);

        ConsoleMenu searchStudentByNameAndLastNameMenu = new(Messages.Student.ListSearchMenuTitle, ConsoleKey.D2);

        searchStudentByNameAndLastNameMenu.SetProcess(ListStudentOrderedByName);

        ConsoleMenu[] studentListMenus = {
            searchStudentByIdMenu,
            searchStudentByNameAndLastNameMenu
        };

        return studentListMenus;
    }

    private IEnumerable<StudentEntity> CreateStudentListMenusProcessGetStudents() {
        this.WriteConsoleLine(ConsoleColor.Cyan, Messages.Student.ListedTitle);
        return this.studentService.GetAllStudents();
    }

    private ConsoleMenu[] CreateStudentSearchMenus() {
        void SearchStudentById() {
            String id = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Student.GetId, Messages.Student.IdIsEmpty);
            StudentEntity student = this.studentService.GetStudentById(id);

            this.WriteConsoleLine(ConsoleColor.Magenta, student);
        }

        void SearchStudentByNameAndLastName() {
            String studentName = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Student.NameLastName, Messages.Student.NameLastNameIsEmpty);
            IEnumerable<StudentEntity> students = this.studentService.GetStudentsByNameLastName(studentName);

            students.PrintInConsole();
        }

        String[] searchStudentSubMenusStudentIdInfos = {
            new(Messages.Student.SearchByIdFirstInfo),
        };

        ConsoleMenu searchStudentByIdMenu = new(Messages.Student.SearchByIdTitle, ConsoleKey.D1, searchStudentSubMenusStudentIdInfos);

        searchStudentByIdMenu.SetProcess(SearchStudentById);


        String[] searchStudentSubMenusStudentNameLastNameInfos = {
            new(Messages.Student.SearchByNameLastNameFirstInfo),
            new(Messages.Student.SearchByNameLastNameSecondInfo),
            new(Messages.Student.SearchByNameLastNameThirdInfo),
        };

        ConsoleMenu searchStudentByNameAndLastNameMenu = new(Messages.Student.SearchByNameLastNameTitle, ConsoleKey.D2);
        searchStudentByNameAndLastNameMenu.AddInfo(searchStudentSubMenusStudentNameLastNameInfos);

        searchStudentByNameAndLastNameMenu.SetProcess(SearchStudentByNameAndLastName);

        ConsoleMenu[] searchStudentSubMenus = {
            searchStudentByIdMenu,
            searchStudentByNameAndLastNameMenu
        };

        return searchStudentSubMenus;
    }
}