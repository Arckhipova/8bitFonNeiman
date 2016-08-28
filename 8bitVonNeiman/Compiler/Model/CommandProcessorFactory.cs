﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using _8bitVonNeiman.Core;

namespace _8bitVonNeiman.Compiler.Model {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class CommandProcessorFactory {

        public delegate BitArray CommandProcessor(string[] args, CompilerEnvironment env);

        public static Dictionary<string, CommandProcessor> GetCommandProcessors() {
            return NoAddressCommandsFactory.GetCommands()
                .Concat(CycleCommandsFactory.GetCommands())
                .Concat(ConditionalJumpCommandsFactory.GetCommands())
                .Concat(UnconditionalJumpCommandsFactory.GetCommands())
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private static class NoAddressCommandsFactory {
            public static Dictionary<string, CommandProcessor> GetCommands() {
                return new Dictionary<string, CommandProcessor> {
                    ["nop"] = NOP,
                    ["ret"] = RET,
                    ["iret"] = IRET,
                    ["ei"] = EI,
                    ["di"] = DI,
                    ["rr"] = RR,
                    ["rl"] = RL,
                    ["rrc"] = RRC,
                    ["rlc"] = RLC,
                    ["hlt"] = HLT,
                    ["inca"] = INCA,
                    ["deca"] = DECA,
                    ["swapa"] = SWAPA,
                    ["daa"] = DAA,
                    ["dsa"] = DSA,
                    ["in"] = IN,
                    ["out"] = OUT,
                    ["es"] = ES,
                    ["movasr"] = MOVASR,
                    ["movsra"] = MOVSRA
                };
            }

            private static BitArray NOP(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "NOP", env.GitCurrentLine());
                return new BitArray(16) { [0] = true };
            }

            private static BitArray RET(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "RET", env.GitCurrentLine());
                return new BitArray(16) { [1] = true };
            }

            private static BitArray IRET(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "IRET", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [1] = true
                };
            }

            private static BitArray EI(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "EI", env.GitCurrentLine());
                return new BitArray(16) { [2] = true };
            }

            private static BitArray DI(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "DI", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [2] = true
                };
            }

            private static BitArray RR(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "RR", env.GitCurrentLine());
                return new BitArray(16) {
                    [1] = true,
                    [2] = true
                };
            }

            private static BitArray RL(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "RL", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [1] = true,
                    [2] = true
                };
            }

            private static BitArray RRC(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "RRC", env.GitCurrentLine());
                return new BitArray(16) { [3] = true };
            }

            private static BitArray RLC(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "RLC", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [3] = true
                };
            }

            private static BitArray HLT(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "HLT", env.GitCurrentLine());
                return new BitArray(16) {
                    [1] = true,
                    [3] = true
                };
            }

            private static BitArray INCA(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "INCA", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [1] = true,
                    [3] = true
                };
            }

            private static BitArray DECA(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "DECA", env.GitCurrentLine());
                return new BitArray(16) {
                    [2] = true,
                    [3] = true
                };
            }

            private static BitArray SWAPA(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "SWAPA", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [2] = true,
                    [3] = true
                };
            }

            private static BitArray DAA(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "DAA", env.GitCurrentLine());
                return new BitArray(16) {
                    [1] = true,
                    [2] = true,
                    [3] = true
                };
            }

            private static BitArray DSA(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "DSA", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [1] = true,
                    [2] = true,
                    [3] = true
                };
            }

            private static BitArray IN(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "IN", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [4] = true
                };
            }

            private static BitArray OUT(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "OUT", env.GitCurrentLine());
                return new BitArray(16) {
                    [1] = true,
                    [4] = true
                };
            }

            private static BitArray ES(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "ES", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [1] = true,
                    [4] = true
                };
            }

            private static BitArray MOVASR(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "MOVASR", env.GitCurrentLine());
                return new BitArray(16) {
                    [2] = true,
                    [4] = true
                };
            }

            private static BitArray MOVSRA(string[] args, CompilerEnvironment env) {
                ValidateNoAddressCommand(args, "MOVSRA", env.GitCurrentLine());
                return new BitArray(16) {
                    [0] = true,
                    [2] = true,
                    [4] = true
                };
            }

            private static void ValidateNoAddressCommand(string[] args, string op, int line) {
                if (args.Length != 0) {
                    throw new CompileErrorExcepton($"Оператор {op} не должен принимать никаких аргументов", line);
                }
            }
        }

        private static class CycleCommandsFactory {
            public static Dictionary<string, CommandProcessor> GetCommands() {
                return new Dictionary<string, CommandProcessor> {["djrnz"] = DJRNZ};
            }

            private static BitArray DJRNZ(string[] args, CompilerEnvironment env) {
                if (args.Length != 2) {
                    throw new CompileErrorExcepton("Оператор DJRNZ должен принимать ровно 2 аргумента", env.GitCurrentLine());
                }

                string R = args[0];
                if (R.Length != 2 || R[0] != 'R' || R[1] < '0' || R[1] > '4') {
                    throw new CompileErrorExcepton("У оператора DJRNZ первым аргументом должен выступать регистр R*", env.GitCurrentLine());
                }

                string L = args[1];
                short address = CompilerSupport.ConvertToFarAddress(L, env);

                BitArray bitArray = new BitArray(16);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);
                bitArray[10] = (R[1] - '0' & 1) == 1;
                bitArray[11] = (R[1] - '0' & 2) == 1;
                bitArray[12] = true;
                return bitArray;
            }
        }

        private static class ConditionalJumpCommandsFactory {
            public static Dictionary<string, CommandProcessor> GetCommands() {
                return new Dictionary<string, CommandProcessor> {
                    ["jnz"] = JNZ,
                    ["jnc"] = JNC,
                    ["jns"] = JNS,
                    ["jno"] = JNO,
                    ["jz"] = JZ,
                    ["jc"] = JC,
                    ["js"] = JS,
                    ["jo"] = JO,
                };
            }

            private static BitArray JNZ(string[] args, CompilerEnvironment env) {
                Validate(args, "JNZ", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JNC(string[] args, CompilerEnvironment env) {
                Validate(args, "JNC", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[10] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JNS(string[] args, CompilerEnvironment env) {
                Validate(args, "JNS", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[11] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JNO(string[] args, CompilerEnvironment env) {
                Validate(args, "JNO", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[10] = true;
                bitArray[11] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JZ(string[] args, CompilerEnvironment env) {
                Validate(args, "JZ", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[12] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JC(string[] args, CompilerEnvironment env) {
                Validate(args, "JC", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[10] = true;
                bitArray[12] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JS(string[] args, CompilerEnvironment env) {
                Validate(args, "JS", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[11] = true;
                bitArray[12] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static BitArray JO(string[] args, CompilerEnvironment env) {
                Validate(args, "JO", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[10] = true;
                bitArray[11] = true;
                bitArray[12] = true;
                bitArray[13] = true;

                return bitArray;
            }

            private static void Validate(string[] args, string op, int line) {
                if (args.Length != 1) {
                    throw new CompileErrorExcepton($"Оператор {op} должен принимать 1 аргумент.", line);
                }
            }
        }

        private static class UnconditionalJumpCommandsFactory {
            public static Dictionary<string, CommandProcessor> GetCommands() {
                return new Dictionary<string, CommandProcessor> {
                    ["jmp"] = JMP,
                    ["call"] = CALL,
                    ["int"] = INT
                };
            }

            private static BitArray JMP(string[] args, CompilerEnvironment env) {
                Validate(args, "JMP", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[14] = true;

                return bitArray;
            }

            private static BitArray CALL(string[] args, CompilerEnvironment env) {
                Validate(args, "CALL", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[10] = true;
                bitArray[14] = true;

                return bitArray;
            }

            private static BitArray INT(string[] args, CompilerEnvironment env) {
                Validate(args, "INT", env.GitCurrentLine());

                var bitArray = new BitArray(16);

                short address = CompilerSupport.ConvertToFarAddress(args[0], env);
                CompilerSupport.FillBitArray(bitArray, address, Constants.FarAddressBitsCount);

                bitArray[11] = true;
                bitArray[14] = true;

                return bitArray;
            }

            private static void Validate(string[] args, string op, int line) {
                if (args.Length != 1) {
                    throw new CompileErrorExcepton($"Оператор {op} должен принимать 1 аргумент.", line);
                }
            }
        }
    }
}
