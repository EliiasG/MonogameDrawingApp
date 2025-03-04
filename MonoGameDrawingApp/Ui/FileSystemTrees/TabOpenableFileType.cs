﻿using MonoGameDrawingApp.Ui.Base.Tabs;

namespace MonoGameDrawingApp.Ui.FileSystemTrees
{
    public abstract class TabOpenableFileType : IOpenableFileType
    {
        public abstract string[] Extentions { get; }

        protected abstract FileTab MakeTab(string path, TabEnvironment tabEnvironment);

        public void Open(string path, TabEnvironment tabEnvironment)
        {
            foreach (FileTab fileTab in tabEnvironment.TabBar.GetTabsOfType<FileTab>())
            {
                if (fileTab.Path == path)
                {
                    tabEnvironment.TabBar.SelectedTab = fileTab;
                    return;
                }
            }

            tabEnvironment.TabBar.OpenTab(MakeTab(path, tabEnvironment), true);
        }
    }
}
