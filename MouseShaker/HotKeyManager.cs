﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace MouseShaker
{
    /// <summary>
    /// Hot Key Manager.
    /// </summary>
    public static class HotKeyManager
    {
        /// <summary>
        /// Dictionary of window handle and set of registered hot key IDs.
        /// </summary>
        private readonly static Dictionary<IntPtr, HashSet<int>> _registerdIdSetDict;


        /// <summary>
        /// Initialize <see cref="_registerdIdSet"/>.
        /// </summary>
        static HotKeyManager()
        {
            _registerdIdSetDict = new Dictionary<IntPtr, HashSet<int>>();
        }

        /// <summary>
        /// Defines a system-wide hot key.
        /// </summary>
        /// <param name="hWnd">A handle to the window that will receive <see cref="WindowMessages.HotKey"/> messages generated by the hot key.</param>
        /// <param name="key">The virtual-key code of the hot key. See Virtual Key Codes.</param>
        /// <returns>-1 when failed to register hotkey, otherwise registered hotkey ID.</returns>
        public static int Register(IntPtr hWnd, Keys key)
        {
            return Register(hWnd, ModifierKeys.None, key);
        }

        /// <summary>
        /// Defines a system-wide hot key.
        /// </summary>
        /// <param name="hWnd">A handle to the window that will receive <see cref="WindowMessages.HotKey"/> messages generated by the hot key.</param>
        /// <param name="modKey">The keys that must be pressed in combination with the key specified by the uVirtKey parameter in order to generate the <see cref="WindowMessages.HotKey"/> message.</param>
        /// <param name="key">The virtual-key code of the hot key. See Virtual Key Codes.</param>
        /// <returns>-1 when failed to register hotkey, otherwise registered hotkey ID.</returns>
        public static int Register(IntPtr hWnd, ModifierKeys modKey, Keys key)
        {
            var idSet = GetRegisteredIdSet(hWnd);
            for (int i = 0x0000; i <= 0xbfff; i++)
            {
                if (idSet.Contains(i))
                {
                    continue;
                }
                if (NativeMethods.RegisterHotKey(hWnd, i, modKey, key))
                {
                    idSet.Add(i);
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Frees a hot key previously registered by the calling thread.
        /// </summary>
        /// <param name="hWnd">A handle to the window associated with the hot key to be freed.</param>
        /// <param name="id">The identifier of the hot key to be freed.</param>
        public static bool Unregister(IntPtr hWnd, int id)
        {
            var result = NativeMethods.UnregisterHotKey(hWnd, id);
            if (result)
            {
                GetRegisteredIdSet(hWnd).Remove(id);
            }
            return result;
        }

        /// <summary>
        /// Frees all hot keys associated with <paramref name="hWnd"/> previously registered by the calling thread.
        /// </summary>
        /// <param name="hWnd">A handle to the window associated with the hot key to be freed.</param>
        public static void Unregister(IntPtr hWnd)
        {
            _registerdIdSetDict.TryGetValue(hWnd, out var idSet);
            if (idSet is null)
            {
                return;
            }
            foreach (var id in idSet)
            {
                NativeMethods.UnregisterHotKey(hWnd, id);
            }
            _registerdIdSetDict.Remove(hWnd);
        }

        /// <summary>
        /// Frees all hot keys previously registered by the calling thread.
        /// </summary>
        public static void UnregisterAll()
        {
            foreach (var kv in _registerdIdSetDict)
            {
                foreach (var id in kv.Value)
                {
                    NativeMethods.UnregisterHotKey(kv.Key, id);
                }
            }
            _registerdIdSetDict.Clear();
        }

        /// <summary>
        /// <para>Get registered ID set.</para>
        /// <para>If the set is not exists, create it and add to <see cref="_registerdIdSetDict"/>.</para>
        /// </summary>
        /// <param name="hWnd">Window handle.</param>
        /// <returns>Registered ID set.</returns>
        private static HashSet<int> GetRegisteredIdSet(IntPtr hWnd)
        {
            _registerdIdSetDict.TryGetValue(hWnd, out var idSet);
            if (idSet is null)
            {
                idSet = new HashSet<int>();
                _registerdIdSetDict.Add(hWnd, idSet);
            }
            return idSet;
        }

        /// <summary>
        /// Provides native methods.
        /// </summary>
        internal static class NativeMethods
        {
            /// <summary>
            /// Defines a system-wide hot key.
            /// </summary>
            /// <param name="hWnd">A handle to the window that will receive <see cref="WindowMessages.HotKey"/> messages generated by the hot key.
            /// If this parameter is NULL, <see cref="WindowMessages.HotKey"/> messages are posted to the message queue of the calling thread and must be processed in the message loop.</param>
            /// <param name="id">The identifier of the hot key.
            /// If the <paramref name="hWnd"/> parameter is <see cref="IntPtr.Zero"/>, then the hot key is associated with the current thread rather than with a particular window.
            /// If a hot key already exists with the same hWnd and id parameters, see Remarks for the action taken.</param>
            /// <param name="modKey">The keys that must be pressed in combination with the key specified by the uVirtKey parameter in order to generate the <see cref="WindowMessages.HotKey"/> message.
            /// The fsModifiers parameter can be a combination of the <see cref="ModifierKeys"/> values.</param>
            /// <param name="key">The virtual-key code of the hot key. See Virtual Key Codes.</param>
            /// <returns>
            /// <para>If the function succeeds, the return value is true.</para>
            /// <para>If the function fails, the return value is false.
            /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para>
            /// </returns>
            /// <remarks>
            /// <para><seealso href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerhotkey"/></para>
            /// <para>When a key is pressed, the system looks for a match against all hot keys.
            /// Upon finding a match, the system posts the <see cref="WindowMessages.HotKey"/> message to the message queue of the window with which the hot key is associated.
            /// If the hot key is not associated with a window, then the <see cref="WindowMessages.HotKey"/> message is posted to the thread associated with the hot key.</para>
            /// <para>This function cannot associate a hot key with a window created by another thread.</para>
            /// <para><see cref="RegisterHotKey(IntPtr, int, ModifierKeys, Keys)"/> fails if the keystrokes specified for the hot key have already been registered by another hot key.</para>
            /// <para>If a hot key already exists with the same <paramref name="hWnd"/> and id parameters, it is maintained along with the new hot key.
            /// The application must explicitly call <see cref="UnregisterHotKey(IntPtr, int)"/> to unregister the old hot key.</para>
            /// <para>Windows Server 2003: If a hot key already exists with the same hWnd and id parameters, it is replaced by the new hot key.</para>
            /// <para>The F12 key is reserved for use by the debugger at all times, so it should not be registered as a hot key.
            /// Even when you are not debugging an application, F12 is reserved in case a kernel-mode debugger or a just-in-time debugger is resident.</para>
            /// <para>An application must specify an id value in the range 0x0000 through 0xBFFF.
            /// A shared DLL must specify a value in the range 0xC000 through 0xFFFF (the range returned by the GlobalAddAtom function).
            /// To avoid conflicts with hot-key identifiers defined by other shared DLLs, a DLL should use the GlobalAddAtom function to obtain the hot-key identifier.</para>
            /// </remarks>
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKeys modKey, Keys key);

            /// <summary>
            /// Frees a hot key previously registered by the calling thread.
            /// </summary>
            /// <param name="hWnd">A handle to the window associated with the hot key to be freed.
            /// This parameter should be <see cref="IntPtr.Zero"/> if the hot key is not associated with a window.</param>
            /// <param name="id">The identifier of the hot key to be freed.</param>
            /// <returns>
            /// <para>If the function succeeds, the return value is nonzero.</para>
            /// <para>If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para>
            /// </returns>
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        }
    }
}
