﻿using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.Cpu {
    public interface ICpuModelOutput {
        /// <summary>
        /// Возвращает память, содержащуюся по переданному адресу.
        /// </summary>
        /// <param name="address">Адрес, по которому запрашивается память.</param>
        /// <returns>Память, содержащаяся по переданному адресу.</returns>
        ExtendedBitArray GetMemory(int address);

        /// <summary>
        /// Устанавливает значение конкретной ячейки памяти.
        /// </summary>
        /// <param name="memory">Значение ячейки памяти.</param>
        /// <param name="address">Адрес ячейки памяти.</param>
        void SetMemory(ExtendedBitArray memory, int address);

        /// <summary>
        /// Вызывается после выполнения команды. Предназначена для обеспечения работы отладчика.
        /// </summary>
        /// <param name="pcl">Новый адрес памяти</param>
        /// <param name="cs">Новый сегмент памяти</param>
        /// <param name="isAutomatic">true если команда выполнена в автоматическом режиме, false - если через "шаг"</param>
        void CommandHasRun(int pcl, int cs, bool isAutomatic);

        /// <summary>
        /// Возвращает память, содержащуюся по переданному адресу внешнего устройства.
        /// </summary>
        /// <param name="address">Адрес внешнего устройства, по которому запрашивается память.</param>
        /// <returns>Память, содержащаяся по переданному адресу.</returns>
        ExtendedBitArray GetExternalMemory(int address);

        /// <summary>
        /// Устанавливает значение конкретной ячейки памяти.
        /// </summary>
        /// <param name="memory">Значение ячейки памяти.</param>
        /// <param name="address">Адрес ячейки памяти внешнего устройства.</param>
        void SetExternalMemory(ExtendedBitArray memory, int address);
    }
}
