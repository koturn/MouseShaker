using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseShaker.Inputs;


namespace MouseShaker
{
    /// <summary>
    /// User code of <see cref="MouseShakerForm"/>.
    /// </summary>
    public partial class MouseShakerForm : Form
    {
        /// <summary>
        /// ID of <see cref="NativeMethods.RegisterHotKey(IntPtr, int, ModifierKey, Keys)"/>.
        /// </summary>
        private int _id = -1;
        /// <summary>
        /// Click burst task.
        /// </summary>
        private Task? _task;
        /// <summary>
        /// <see cref="CancellationTokenSource"/> for <see cref="_task"/>.
        /// </summary>
        private CancellationTokenSource? _cts;

        /// <summary>
        /// Initialize components.
        /// </summary>
        public MouseShakerForm()
        {
            InitializeComponent();
            _comboBoxHotKey.SelectedIndex = 9;
        }

        /// <summary>
        /// Windows message reciever to start/stop <see cref="_task"/>.
        /// </summary>
        /// <param name="m">Windows message.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == (int)WindowMessages.HotKey)
            {
                if ((int)m.WParam == _id)
                {
                    ToggleTask();
                }
            }
        }

        /// <summary>
        /// Start/Stop <see cref="_task"/>.
        /// </summary>
        private void ToggleTask()
        {
            if (_task != null)
            {
                _labelStatus.Text = "Stopping...";
                _labelStatus.ForeColor = SystemColors.ControlText;
                Text = "MouseShaker: Stopping...";
                if (_cts != null)
                {
                    _cts.Cancel();
                }
                _task.Wait();
                _task = null;
                _labelStatus.Text = "Inactive";
                _labelStatus.ForeColor = SystemColors.ControlText;
                Text = "MouseShaker: Inactive";
            }
            else
            {
                var offsetX = (int)_numericUpDownOffsetX.Value;
                var offsetY = (int)_numericUpDownOffsetY.Value;
                var framerate = _numericUpDownFramerate.Value;
                _task = Task.Factory.StartNew(
                    () =>
                    {
                        var cts = _cts;
                        if (cts == null)
                        {
                            return;
                        }

                        var intervalMs = (int)(1000.0 / (double)framerate);

                        var mouseInputs = new[]
                        {
                            Input.CreateMouseInput(MouseEventF.Move, offsetX, offsetY),
                            Input.CreateMouseInput(MouseEventF.Move, -offsetX, -offsetY)
                        };

                        while (!cts.IsCancellationRequested)
                        {
                            for (int i = 0; i < mouseInputs.Length; i++)
                            {
                                InputUtil.SendInput(ref mouseInputs[i]);
                                Thread.Sleep(intervalMs);
                                if (cts.IsCancellationRequested)
                                {
                                    break;
                                }
                            }
                        }
                    },
                    (_cts = new CancellationTokenSource()).Token,
                    TaskCreationOptions.LongRunning,
                    TaskScheduler.Default);
                _labelStatus.Text = "Active";
                _labelStatus.ForeColor = Color.Red;
                Text = "MouseShaker: Active";
                TopMost = true;
                TopMost = false;
            }
        }

        /// <summary>
        /// Called then this form loaded.
        /// </summary>
        /// <param name="sender">Instance of the <see cref="MouseShakerForm"/>.</param>
        /// <param name="e">An object that contains no event data.</param>
        private void BurstClickForm_Load(object sender, EventArgs e)
        {
            ComboBoxHotKey_SelectedIndexChanged(_comboBoxHotKey, EventArgs.Empty);
        }

        /// <summary>
        /// Called then before closing this form.
        /// </summary>
        /// <param name="sender">Instance of the <see cref="MouseShakerForm"/>.</param>
        /// <param name="e">An object that contains no event data.</param>
        private void BurstClickForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HotKeyManager.UnregisterAll();
        }

        /// <summary>
        /// Callback method when selected index of <see cref="_comboBoxHotKey"/> is changed.
        /// </summary>
        /// <param name="sender"><see cref="_comboBoxHotKey"/>.</param>
        /// <param name="e">A value which has no event data.</param>
        private void ComboBoxHotKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated)
            {
                return;
            }

            var selectedItem = ((ComboBox)sender).SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            var hotKey = Enum.Parse<Keys>((string)selectedItem);

            HotKeyManager.Unregister(Handle, _id);
            var id = HotKeyManager.Register(Handle, hotKey);
            if (id != -1)
            {
                _id = id;
            }
        }
    }
}
