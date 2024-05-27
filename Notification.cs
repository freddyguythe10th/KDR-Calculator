using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDR_Calculator
{
    public enum AnimationState
    {
        MovingUp,
        MovingDown,
        Static
    }
    public partial class Notification : Form
    {
        //Static instances
        public static Notification Instance;

        //The notification timer
        private Timer HideNotificationTimer;

        //Animation tools
        private Timer AnimationTimer;
        private int animationTimeRan = 0;
        private AnimationState currentAnimState;

        //Window settings
        private int notificationSpeed = 100;
        public static bool isShown = false;

        private Form1 MainForm;
        public Notification(Form1 parent)
        {
            Instance = this;

            InitializeComponent();

            MainForm = parent;

            ResetLocation();

            this.TopMost = true;
            this.ShowInTaskbar = false;

            // Create and configure the timer
            HideNotificationTimer = new System.Windows.Forms.Timer();
            HideNotificationTimer.Interval = 5000; // 5000 milliseconds = 5 seconds
            HideNotificationTimer.Tick += ReadyCloseNotification;

            AnimationTimer = new Timer();
            AnimationTimer.Interval = 10;
            AnimationTimer.Tick += CalculateAnimation;
            AnimationTimer.Start();
        }

        private void ResetLocation()
        {
            var workingArea = Screen.GetWorkingArea(MainForm);
            this.Location = new System.Drawing.Point(workingArea.Right - this.Width, workingArea.Bottom + this.Height);
        }

        private void CalculateAnimation(object sender, EventArgs e)
        {
            switch(currentAnimState)
            {
                case AnimationState.MovingUp:
                    if(animationTimeRan >= notificationSpeed / AnimationTimer.Interval) { ChangeAnimationState(AnimationState.Static); return; }
                    Point targetUpLocatoin = Location;
                    targetUpLocatoin.Y -= (1000 / notificationSpeed);
                    Location = targetUpLocatoin;
                    break;
                case AnimationState.MovingDown:
                    if (animationTimeRan >= notificationSpeed / AnimationTimer.Interval) { OnHideAnimComplete(); return; }
                    Point targetDownLocation = Location;
                    targetDownLocation.Y += (1000 / notificationSpeed);
                    Location = targetDownLocation;
                    break;
                case AnimationState.Static:
                    return;
            }
            animationTimeRan++;
        }
        public void UpdateKDR(string updatedKDR)
        {
            KDROutput.Text = updatedKDR;
        }
        public void ChangeAnimationState(AnimationState toChange)
        {
            currentAnimState = toChange;
            animationTimeRan = 0;
        }
        public void ToggleWindow(string KDR)
        {
            if (isShown)
            {
                HideWindow();
            }
            else
            {
                ShowWindow(KDR);
            }
        }

        private void ShowWindow(string KDR)
        {
            ResetLocation();

            ChangeAnimationState(AnimationState.MovingUp);
            AnimationTimer.Start();

            UpdateKDR(KDR);

            HideNotificationTimer.Start();
            this.Show();
            isShown = true;
        }

        private void HideWindow()
        {
            ChangeAnimationState(AnimationState.MovingDown);
            isShown = false;
            this.HideNotificationTimer.Stop();
        }

        private void OnHideAnimComplete()
        {
            AnimationTimer.Stop();
            this.Hide();
        }

        private void ReadyCloseNotification(object sender, EventArgs e)
        {
            this.HideWindow();
        }

        #region Chat GPT Generated Code for Showing without window being focused
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;
                baseParams.ExStyle |= WS_EX_TOPMOST | WS_EX_NOACTIVATE;
                return baseParams;
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint TOPMOST_FLAGS = SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
        #endregion
    }
}
