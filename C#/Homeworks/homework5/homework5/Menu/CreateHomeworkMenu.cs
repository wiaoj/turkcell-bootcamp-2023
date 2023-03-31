using homework5.Entities;
using homework5.Extensions;

namespace homework5.Menu;
public partial class Menu {
    private ConsoleMenu CreateHomeworkMenu() {
        ConsoleMenu operationHomeworkMenu = new(Messages.Homework.OperationTitle, ConsoleKey.D1);

        operationHomeworkMenu.AddRangeSubMenu(this.CreateHomeworkOperationMenus());

        ConsoleMenu[] classSubMenus = {
            operationHomeworkMenu,
        };

        ConsoleMenu classMenu = this.CreateSubMenu(new(Messages.Homework.Title, ConsoleKey.D4), classSubMenus);

        return classMenu;
    }

    private ConsoleMenu[] CreateHomeworkOperationMenus() {
        void AddHomework() {

            String classId = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Class.GetId, Messages.Class.IdIsEmpty);

            String homeworkName = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Homework.Name, Messages.Homework.NameIsEmpty);

            String homeworkDescription = this.ReadConsoleLine(ConsoleColor.Yellow, Messages.Homework.Description, Messages.Homework.DescriptionIsEmpty);

            HomeworkEntity homework = this.homeworkService.AddHomework(classId, homeworkName, homeworkDescription);
            this.WriteConsoleLine(ConsoleColor.Green, Messages.EntityAddIsSuccess(homework));
        }


        ConsoleMenu addHomeworkMenu = new(Messages.Homework.AddMenuTitle, ConsoleKey.D1);
        addHomeworkMenu.SetProcess(AddHomework);

        ConsoleMenu[] classOperationMenus = {
            addHomeworkMenu,
        };

        return classOperationMenus;
    }
}