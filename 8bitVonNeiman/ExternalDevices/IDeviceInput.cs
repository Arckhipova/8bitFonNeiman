﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices {
    public interface IDeviceInput {
        void OpenForm();
        void ExitThread();
        bool HasMemory(int address);
        void SetMemory(ExtendedBitArray memory, int address);
        ExtendedBitArray GetMemory(int address);

        void UpdateUI();
    }
}
