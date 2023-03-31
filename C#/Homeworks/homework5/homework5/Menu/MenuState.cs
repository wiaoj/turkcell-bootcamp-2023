namespace homework5.Menu;
public static class MenuState {
    public static void State(ConsoleKeyInfo consoleKeyInfo, ref Boolean isQuit, ConsoleMenu rootMenu, ref ConsoleMenu activeMenu, ref ConsoleMenu? previousMenu) {
        Console.Clear();
        Console.WriteLine(rootMenu.Info);
        switch(consoleKeyInfo.Key) {
            case ConsoleKey.Backspace:
                if(previousMenu is null) {
                    Console.WriteLine("Zaten ana menüdesiniz.");
                    Console.WriteLine(activeMenu);
                    return;
                }

                (activeMenu, previousMenu) = (previousMenu, activeMenu);
                if(activeMenu.Id == rootMenu.Id)
                    previousMenu = null;

                Console.WriteLine(activeMenu);
                return;

            case ConsoleKey.Spacebar:
                //Console.Clear();
                Console.WriteLine(rootMenu);
                activeMenu = rootMenu;
                previousMenu = null;
                return;

            case ConsoleKey.Escape:
                isQuit = true;
                Console.Write("Uygulamadan çıkış yapıldı, ");
                Console.WriteLine("Bir tuşa basarak konsolu kapatabilirsiniz.");
                return;
        }

        Boolean isMenuSelected = default;
        //Console.Clear();
        foreach(ConsoleMenu? subMenu in activeMenu.SubMenus) {
            if(subMenu.MenuKey == consoleKeyInfo.Key && subMenu.SubMenus.Count is default(Int32)) {
                Console.WriteLine(subMenu.Info);
                subMenu.InvokeProcess();
                activeMenu = previousMenu;
                activeMenu = subMenu;
                return;
            }

            if(subMenu.MenuKey == consoleKeyInfo.Key) {
                Console.WriteLine(subMenu.Info);
                Console.WriteLine(subMenu);
                isMenuSelected = true;
                previousMenu = activeMenu;
                activeMenu = subMenu;
                return;
            }
        }

        if(isMenuSelected)
            return;

        Console.WriteLine("Geçersiz bir tuşa bastınız.");
        Console.WriteLine(activeMenu);
    }
}