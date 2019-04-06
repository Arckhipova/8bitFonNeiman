﻿namespace _8bitVonNeiman.Controller.View {
    public interface IComponentsFormOutput {
        void FormClosed();
        void EditorButtonClicked();
        void MemoryButtonClicked();
        void CpuButtonClicked();
        void DebugButtonClicked();
        void ExternalDevicesManagerClicked();

        void OpenAllButtonClicked();
    }
}
