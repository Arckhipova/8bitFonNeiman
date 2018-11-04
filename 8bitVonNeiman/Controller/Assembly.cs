﻿using _8bitVonNeiman.Compiler;
using _8bitVonNeiman.Compiler.Model;
using _8bitVonNeiman.Cpu;
using _8bitVonNeiman.Cpu.View;
using _8bitVonNeiman.Debug;
using _8bitVonNeiman.Memory;
using _8bitVonNeiman.ExternalDevicesManager;

namespace _8bitVonNeiman.Controller {
    public static class Assembly {
        public static CompilerController GetCompilerController(ICompilerControllerOutput output) {
            var compilerController = new CompilerController(output);

            var compilerModel = new CompilerModel(compilerController.CompilationComplete, compilerController.CompilationError);
            compilerController.SetCompiler(compilerModel);

            return compilerController;
        }

        public static MemoryController GetMemoryController() {
            var memoryController = new MemoryController();
            return memoryController;
        }

        public static ICpuModelInput GetCpu(ICpuModelOutput output) {
            return new CpuModel(output);
        }

        public static IDebugModuleInput GetDebugController(IDebugModuleOutput output) {
            return new DebugController(output);
        }

        public static IExternalDevicesControllerInput GetExternalDevicesController() {
            return new ExternalDevicesController();
        }
    }
}
