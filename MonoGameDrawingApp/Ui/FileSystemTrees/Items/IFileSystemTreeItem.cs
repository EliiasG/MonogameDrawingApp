﻿using MonoGameDrawingApp.Ui.Base.Popup;
using MonoGameDrawingApp.Ui.Base.Tree.TreeItems;

namespace MonoGameDrawingApp.Ui.FileSystemTrees.Items
{
    public interface IFileSystemTreeItem : ITreeItem
    {
        string Path { get; }

        PopupEnvironment PopupEnvironment { get; }

        FileTypeManager FileTypeManager { get; }
    }
}
