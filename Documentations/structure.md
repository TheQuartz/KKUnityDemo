游戏结构
========

* StartMenu(Scene)
    - Menu(GameObject)
        * StartMenuGUI(Script)
* GamePlay(Scene)
    - MainLogic(GameObject)
        * MainLogic(Script)
    - Menu(GameObject)
        * InGameMenuGUI(Script)

## StartMenu(Scene)

游戏的开始菜单场景。Menu(GameObject)为菜单实体。具体菜单绘制和逻辑由StartMenuGUI完成。

### Menu(GameObject)

菜单实体。只含有一个有效的component：StartMenuGUI(Script)。

#### StartMenuGUI(Script)

绘制开始菜单。

* LoadGame(Button): 点击该按钮则加载游戏，进入GamePlay场景。

## GamePlay(Scene)

实际游戏场景。目前只包含暂停菜单。

### MainLogic(GameObject)

虚游戏对象。没有可视化的实体。是MainLogic(Script)的容器。

#### MainLogic(Script)

游戏的主逻辑。负责控制游戏进程。目前只包含通过ESC开/关暂停菜单的功能。

### Menu(GameObject)

暂停菜单

#### InGameMenuGUI(Script)

负责绘制暂停菜单以及相应的逻辑。目前只包含一个Quit按钮。点击该按钮则退出游戏返回StartMenu场景。 