﻿using MonoGameDrawingApp.Ui.Base;
using MonoGameDrawingApp.Ui.Base.Popup;
using MonoGameDrawingApp.Ui.DrawingApp.Tabs.VectorSprites.Elements;
using MonoGameDrawingApp.Ui.FileSystemTrees;

namespace MonoGameDrawingApp.Ui.DrawingApp.Tabs.VectorSprites
{
    public class VectorSpriteTab : FileTab
    {
        private readonly VectorSpriteTabRoot _spriteTabView;
        private readonly PopupEnvironment _popupEnvironment;

        public VectorSpriteTab(UiEnvironment environment, string path, PopupEnvironment popupEnvironment) : base(path)
        {
            _popupEnvironment = popupEnvironment;


            _spriteTabView = new VectorSpriteTabRoot(environment, path, popupEnvironment);
        }

        public override IUiElement Child => _spriteTabView;

        public override bool HasCloseButton => true;

        public override string Title => OriginalTitle + (_spriteTabView.IsSaving ? "..." : (_spriteTabView.IsSaved ? "" : "*"));

        private string OriginalTitle => System.IO.Path.GetFileName(Path);

        public override void Close()
        {
            if (_spriteTabView.IsSaved)
            {
                ForceClose();
            }
            else
            {
                string message = "Close '" + OriginalTitle + "'?";
                ChoicePopup popup = new(_spriteTabView.Environment, message, _popupEnvironment, new ChoicePopupOption[]
                {
                    new ChoicePopupOption("Save", () =>
                    {
                        _spriteTabView.Save();
                        ForceClose();
                    }),
                    new ChoicePopupOption("Don't save", ForceClose),
                    new ChoicePopupOption("Cancel", () => { }),
                });
                _popupEnvironment.OpenCentered(popup);
            }
        }
    }
}
