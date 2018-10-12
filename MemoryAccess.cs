using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace HackRR2
{
    public class MemoryAccess : IDisposable
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr handle, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern int CloseHandle(IntPtr handle);

        private readonly Process process;

        public MemoryAccess()
        {
            process = Process.GetProcessesByName("rr-tournament").FirstOrDefault();
        }

        public void WriteFloat(int[] offsets, float value)
        {
            var handle = IntPtr.Zero;
            try
            {
                handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
                var address = ReadAddress(handle, offsets);

                WriteFloat(handle, address, value);
            }
            catch { }
            finally
            {
                SafeCloseHandle(handle);
            }
        }

        public void WriteFloat(int address, float value)
        {
            var handle = IntPtr.Zero;
            try
            {
                handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
                WriteFloat(handle, address, value);
            }
            catch { }
            finally
            {
                SafeCloseHandle(handle);
            }
        }

        private void WriteFloat(IntPtr handle, int address, float value)
        {
            var val = BitConverter.GetBytes(value);
            int wtf = 0;
            WriteProcessMemory(handle, new IntPtr(address), val, (uint)val.LongLength, out wtf);
        }

        public int ReadAddress(int[] offsets)
        {
            var handle = IntPtr.Zero;
            try
            {
                handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
                return ReadAddress(handle, offsets);
            }
            catch { }
            finally
            {
                SafeCloseHandle(handle);
            }

            return 0;
        }

        private int ReadInt32(IntPtr handle, int address)
        {
            if (address <= 0)
            {
                return -1;
            }

            var buffer = new byte[4];
            int byteRead = 0;

            ReadProcessMemory(handle, address, buffer, 4, ref byteRead);
            return BitConverter.ToInt32(buffer, 0);
        }

        private int ReadAddress(IntPtr handle, int[] offsets)
        {
            var baseAddress = IntPtr.Add(process.MainModule.BaseAddress, offsets[0]);

            var address = baseAddress.ToInt32();
            for (var i = 1; i < offsets.Length; i++)
            {
                address = ReadInt32(handle, address);

                if (address == 0)
                {
                    return 0;
                }

                address += offsets[i];
            }

            return address;
        }

        public float ReadFloat(int address)
        {
            var handle = IntPtr.Zero;
            try
            {
                handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
                return ReadFloat(handle, address);
            }
            catch { }
            finally
            {
                SafeCloseHandle(handle);
            }

            return 0;
        }

        public float ReadFloat(int[] offsets)
        {
            var handle = IntPtr.Zero;
            try
            {
                handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
                var address = ReadAddress(handle, offsets);
                return ReadFloat(address);
            }
            catch { }
            finally
            {
                SafeCloseHandle(handle);
            }

            return 0;
        }


        private float ReadFloat(IntPtr handle, int address)
        {
            var buffer = new byte[4];
            int byteRead = 0;

            ReadProcessMemory(handle, address, buffer, 4, ref byteRead);
            return BitConverter.ToSingle(buffer, 0);
        }


        public void HackArmy(float range, float rate, float speed)
        {
            var handle = IntPtr.Zero;
            try
            {
                handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);

                var currentAddress = ReadAddress(handle, GameOffsets.BaseArmy);
                if (currentAddress != 0 && IsValidArmyHeader(handle, currentAddress))
                {
                    var armyType = ReadInt32(handle, currentAddress + 0x6C);
                    if (armyType == 0)
                    {
                        WriteFloat(handle, currentAddress + 0x6AC, range);
                        WriteFloat(handle, currentAddress + 0x6B0, rate);
                        WriteFloat(handle, currentAddress + 0x69C, speed);
                    }
                    else
                    {
                        WriteFloat(handle, currentAddress + 0x6AC, 0.001f);
                        WriteFloat(handle, currentAddress + 0x6B0, 0.001f);
                        WriteFloat(handle, currentAddress + 0x69C, 0.1f);
                    }
                }
            }
            catch { }
            finally
            {
                SafeCloseHandle(handle);
            }
        }

        private bool IsValidArmyHeader(IntPtr handle, int address)
        {
            if (address == 0)
            {
                return false;
            }

            var pointer1 = ReadInt32(handle, address);
            if (pointer1 == 0)
            {
                return false;
            }

            var pointer2 = ReadInt32(handle, pointer1);
            if (pointer2 == 0)
            {
                return false;
            }

            var headerValue = ReadInt32(handle, pointer2 + 8);

            return headerValue == 161;
        }


        private void SafeCloseHandle(IntPtr handle)
        {
            if (handle != IntPtr.Zero)
            {
                CloseHandle(handle);
            }
        }

        public void Dispose()
        {
            process.Dispose();
        }
    }
}
