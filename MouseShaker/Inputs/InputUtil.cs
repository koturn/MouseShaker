using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;


namespace MouseShaker.Inputs
{
    /// <summary>
    /// Utility class of SendInput().
    /// </summary>
    public static class InputUtil
    {
        /// <summary>
        /// Size of <see cref="Input"/>.
        /// </summary>
        private static readonly int SizeOfInput;


        /// <summary>
        /// Initialize static members.
        /// </summary>
        static InputUtil()
        {
            SizeOfInput = Marshal.SizeOf(typeof(Input));
        }


        /// <summary>
        /// Managed wrapper of <see cref="NativeMethods.SendInput(int, ref Input, int)"/>.
        /// </summary>
        /// <param name="input">An reference of <see cref="Input"/> structures.
        /// This structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <returns>The number of events that it successfully inserted into the keyboard or mouse input stream.</returns>
        public static int SendInput(ref Input input)
        {
            return NativeMethods.SendInput(1, ref input, SizeOfInput);
        }

        /// <summary>
        /// Managed wrapper of <see cref="NativeMethods.SendInput(int, Input[], int)"/>.
        /// </summary>
        /// <param name="inputs">An array of <see cref="Input"/> structures.
        /// Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <returns>The number of events that it successfully inserted into the keyboard or mouse input stream.</returns>
        public static int SendInput(Input[] inputs)
        {
            return NativeMethods.SendInput(inputs.Length, inputs, SizeOfInput);
        }

        /// <summary>
        /// Managed wrapper of <see cref="NativeMethods.SendInput(int, Input[], int)"/>.
        /// </summary>
        /// <param name="inputs">An <see cref="List{T}"/> of <see cref="Input"/> structures.
        /// Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <returns>The number of events that it successfully inserted into the keyboard or mouse input stream.</returns>
        public static int SendInput(List<Input> inputs)
        {
            return NativeMethods.SendInput(inputs.Count, ListUtil.GetArray(inputs), SizeOfInput);
        }

        /// <summary>
        /// <para>Managed wrapper of <see cref="NativeMethods.SendInput(int, ref Input, int)"/>.</para>
        /// <para>Create <see cref="Input"/> about mouse event and send it.</para>
        /// </summary>
        /// <param name="flags">A set of bit flags that specify various aspects of mouse motion and button clicks.</param>
        /// <param name="x">The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the <paramref name="flags"/>.</param>
        /// <param name="y">The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the <paramref name="flags"/>.</param>
        /// <param name="data">A mouse data depends on <paramref name="flags"/>.</param>
        /// <param name="time">The time stamp for the event, in milliseconds.</param>
        /// <param name="extraInfo">An additional value associated with the mouse event.</param>
        /// <returns>The number of events that it successfully inserted into the mouse input stream.</returns>
        public static int SendMouseInput(MouseEventF flags, int x = 0, int y = 0, int data = 0, int time = 0, IntPtr extraInfo = default)
        {
            var input = Input.CreateMouseInput(flags, x, y, data, time, extraInfo);
            return SendInput(ref input);
        }

        /// <summary>
        /// <para>Managed wrapper of <see cref="NativeMethods.SendInput(int, ref Input, int)"/>.</para>
        /// <para>Create <see cref="Input"/> about keyboard event and send it.</para>
        /// </summary>
        /// <param name="flags">Specifies various aspects of a keystroke.</param>
        /// <param name="virtualKey">A virtual-key code.</param>
        /// <param name="scanCode">A hardware scan code for the key.</param>
        /// <param name="time">The time stamp for the event, in milliseconds.</param>
        /// <param name="extraInfo">An additional value associated with the keystroke.</param>
        /// <returns>The number of events that it successfully inserted into the keyboard input stream.</returns>
        public static int SendKeyboardInput(KeyEventF flags, short virtualKey = 0, short scanCode = 0, int time = 0, IntPtr extraInfo = default)
        {
            var input = Input.CreateKeyboardInput(flags, virtualKey, scanCode, time, extraInfo);
            return SendInput(ref input);
        }

        /// <summary>
        /// <para>Managed wrapper of <see cref="NativeMethods.SendInput(int, ref Input, int)"/>.</para>
        /// <para>Create <see cref="Input"/> about hardware event and send it.</para>
        /// </summary>
        /// <param name="message">The message generated by the input hardware.</param>
        /// <param name="paramL">The low-order word of the lParam parameter for <see cref="Message"/>.</param>
        /// <param name="paramH">The high-order word of the lParam parameter for <see cref="Message"/>.</param>
        /// <returns>The number of events that it successfully inserted into the hardware input stream.</returns>
        public static int SendHardwareInput(int message, short paramL, short paramH)
        {
            var input = Input.CreateHardwareInput(message, paramL, paramH);
            return SendInput(ref input);
        }

        /// <summary>
        /// Provides native methods.
        /// </summary>
        internal class NativeMethods
        {
            /// <summary>
            /// Synthesizes keystrokes, mouse motions, and button clicks.
            /// </summary>
            /// <param name="nInputs">The number of structures in the <paramref name="input"/>. Muse be 1.</param>
            /// <param name="input">An reference of <see cref="Input"/> structures.
            /// This structure represents an event to be inserted into the keyboard or mouse input stream.</param>
            /// <param name="cbSize">The size, in bytes, of an <see cref="Input"/> structure.
            /// If cbSize is not the size of an <see cref="Input"/> structure, the function fails.</param>
            /// <returns>
            /// <para>The function returns the number of events that it successfully inserted into the keyboard or mouse input stream.
            /// If the function returns zero, the input was already blocked by another thread.
            /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para>
            /// <para>This function fails when it is blocked by UIPI.
            /// Note that neither <see cref="Marshal.GetLastWin32Error"/> nor the return value will indicate the failure was caused by UIPI blocking.</para>
            /// </returns>
            /// <remarks><seealso href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput"/></remarks>
            [DllImport("user32.dll", SetLastError = true)]
            public extern static int SendInput(int nInputs, ref Input input, int cbSize);

            /// <summary>
            /// Synthesizes keystrokes, mouse motions, and button clicks.
            /// </summary>
            /// <param name="nInputs">The number of structures in the <paramref name="inputs"/>. Muse be 1.</param>
            /// <param name="inputs">An array of <see cref="Input"/> structures.
            /// Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
            /// <param name="cbSize">The size, in bytes, of an <see cref="Input"/> structure.
            /// If cbSize is not the size of an <see cref="Input"/> structure, the function fails.</param>
            /// <returns>
            /// <para>The function returns the number of events that it successfully inserted into the keyboard or mouse input stream.
            /// If the function returns zero, the input was already blocked by another thread.
            /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para>
            /// <para>This function fails when it is blocked by UIPI.
            /// Note that neither <see cref="Marshal.GetLastWin32Error"/> nor the return value will indicate the failure was caused by UIPI blocking.</para>
            /// </returns>
            /// <remarks><seealso href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput"/></remarks>
            [DllImport("user32.dll", SetLastError = true)]
            public extern static int SendInput(int nInputs, Input[] inputs, int cbSize);
        }

        /// <summary>
        /// Provides some utility methods of <see cref="List{T}"/>.
        /// </summary>
        internal static class ListUtil
        {
            /// <summary>
            /// Get internal array of <see cref="List{T}"/>.
            /// </summary>
            public static T[] GetArray<T>(List<T> list)
            {
                return ListUtil<T>.GetArray(list);
            }
        }

        /// <summary>
        /// Provides some utility methods of <see cref="List{T}"/>.
        /// </summary>
        internal static class ListUtil<T>
        {
            /// <summary>
            /// Cache of delegate of <see cref="CreateGetArrayFunc"/>.
            /// </summary>
            private static Func<List<T>, T[]>? _getArray;

            /// <summary>
            /// Get internal array of <see cref="List{T}"/>.
            /// </summary>
            /// <param name="list">Target list.</param>
            /// <returns>Internal array of <see cref="List{T}"/>.</returns>
            public static T[] GetArray(List<T> list)
            {
                return (_getArray ??= CreateGetArrayFunc())(list);
            }

            /// <summary>
            /// Create method which gets internal array of <see cref="List{T}"/>.
            /// </summary>
            /// <typeparam name="T">Element type of <see cref="List{T}"/>.</typeparam>
            private static Func<List<T>, T[]> CreateGetArrayFunc()
            {
                var dynMethod = new DynamicMethod(
                    "GetListArray",
                    typeof(T[]),
                    new[] { typeof(List<T>) },
                    true);

                var ilGen = dynMethod.GetILGenerator();
                ilGen.Emit(OpCodes.Ldarg_0);
                ilGen.Emit(
                    OpCodes.Ldfld,
                    typeof(List<T>).GetField(
                        "_items",
                        BindingFlags.GetField
                            | BindingFlags.NonPublic
                            | BindingFlags.Instance)
                    ?? throw new ArgumentException("FieldInfo not found: System.Collections.Generic.List<T>._items"));
                ilGen.Emit(OpCodes.Ret);

                return (Func<List<T>, T[]>)dynMethod.CreateDelegate(typeof(Func<List<T>, T[]>));
            }
        }
    }
}
