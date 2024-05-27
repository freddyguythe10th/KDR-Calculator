using System;
using System.Windows.Forms;

namespace KDR_Calculator
{
    public partial class Form1 : Form
    {
        public int kills;
        public int deaths;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup the keyboard hook
            GlobalKeyboardHook.HookKeyboard();
            GlobalKeyboardHook.keyPressed += OnGlobalKeyPressed;

            //Setup the notification window
            Notification.Instance = new Notification(this);
        }

        /// <summary>
        /// Runs when a key is pressed on the pc
        /// </summary>
        /// <param name="sender">What sent this event?</param>
        /// <param name="e">Event parameters</param>
        private void OnGlobalKeyPressed(object sender, KeyPressedEventArgs e)
        {
            //Verify the user clicked the control key
            if(Control.ModifierKeys == Keys.Control)
            {
                if (e.keyPressed == Keys.Insert)
                {
                    e.ShouldSupressKey = true;
                    OnUserKilledAnother();
                    UpdateDisplayedKDR();
                }
                else if (e.keyPressed == Keys.Delete)
                {
                    e.ShouldSupressKey = true;
                    OnUserDeath();
                    UpdateDisplayedKDR();
                }
                else if (e.keyPressed == Keys.Home)
                {
                    e.ShouldSupressKey = true;
                    UpdateDisplayedKDR();
                    Notification.Instance.ToggleWindow(GetCurrentKDR());
                }
                else if (e.keyPressed == Keys.End)
                {
                    e.ShouldSupressKey = true;
                    var result = MessageBox.Show("Are you sure you want to delete the current KDR?", "Are you sure?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        kills = 0;
                        deaths = 0;
                    }
                    UpdateDisplayedKDR();
                }
            }
        }

        /// <summary>
        /// Updates the displayed KDR from the values
        /// </summary>
        public void UpdateDisplayedKDR()
        {
            KDROutput.Text = GetCurrentKDR();
            killsOutput.Text = kills.ToString();
            deathsOutput.Text = deaths.ToString();
            Notification.Instance.UpdateKDR(KDROutput.Text);
        }

        /// <summary>
        /// Calculate the current KDR
        /// </summary>
        /// <returns>A formatted string</returns>
        public string GetCurrentKDR()
        {
            if(deaths == 0) { return $"{kills}:0"; }
            double divided = (double)kills / (double)deaths;
            return divided.ToString("#.##") + ":1";
        }

        /// <summary>
        /// Runs when the user dies
        /// </summary>
        public void OnUserDeath()
        {
            deaths++;
        }

        /// <summary>
        /// Runs when the user kills a player
        /// </summary>
        public void OnUserKilledAnother()
        {
            kills++;
        }

        /// <summary>
        /// Runs when the user clicks a key on a textbox
        /// </summary>
        /// <param name="sender">the textbox</param>
        /// <param name="e">key event args</param>
        public void ModifySavedData(object sender, KeyEventArgs e)
        {
            e.Handled = false;
            e.SuppressKeyPress = false;
            //Detect if the user clicks enter
            if (e.KeyCode == Keys.Enter)
            {
                TextBox thisTextbox = ((TextBox)sender);
                TryChangeData(thisTextbox);
            }
        }
        /// <summary>
        /// Trys to change the kills or deaths based on the textbox input
        /// </summary>
        /// <param name="toChange">Textbox that we clicked enter on</param>
        public void TryChangeData(TextBox toChange)
        {
            try
            {
                if (toChange == killsOutput)
                {
                    kills = int.Parse(toChange.Text);
                }
                else if (toChange == deathsOutput)
                {
                    deaths = int.Parse(toChange.Text);
                }
                UpdateDisplayedKDR();
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
            finally
            {
                UpdateDisplayedKDR();
            }
        }

        //Runs when the program is closing to ensure the hooks are sucessfully discarded
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalKeyboardHook.UnhookKeyboard();
        }
    }

    public class KeyPressedEventArgs
    {
        public Keys keyPressed = Keys.None;
        public bool ShouldSupressKey = false;
    }
}
