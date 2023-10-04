using AppBarHelper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBarHelper
{

    public partial class CompactWindow : Form
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern long ShowWindow(System.IntPtr hWnd, long nCmdShow);
        private const long SW_RESTORE = 9;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsIconic(IntPtr hWnd);

        public bool IsShown { get; private set; }

        public List<SourceButton> Sources = new List<SourceButton>();
        public List<SourceButton> Monitor = new List<SourceButton>();

        public event EventHandler<string> SourceSelected;


        private static ToolTip ToolTip1 = new ToolTip();
        private static AppBarHelper appBarHelper;

        private Func<string, bool, string, string> CommandGetValueMethod;
        private Action<string> MonitorPidMethod;
        private Action<string> MonitorFocusApplication;

        public CompactWindow(Func<string, bool, string, string> getCommandMethod, Action<string> monitorPidMethod, Action<string> monitorFocusApplication)
        {
            InitializeComponent();

            ToolTip1.IsBalloon = true;
            CommandGetValueMethod = getCommandMethod;
            MonitorPidMethod = monitorPidMethod;
            MonitorFocusApplication = monitorFocusApplication;
        }

        public void HandleSourceSelected(string nodeName)
        {
            SourceSelected.Invoke(null, nodeName);
        }

        private void HandleSnapping(bool isClosing = false)
        {
            KeyValuePair<Size, Point> appbarLocSize = appBarHelper.ChangeFormPosition(isClosing ? AppBarHelper.AppBarEdges.Float : AppBarHelper.AppBarEdges.Left, Size, Location);
            if (!IsShown)
            {
                Size = appbarLocSize.Key;
                Location = appbarLocSize.Value;
            }
        }

        private void BtnAddConnection_MouseEnter(object sender, EventArgs e)
        {
            BtnAddConnection.ImageIndex = 1;
            BtnAddConnection.BackColor = Color.FromArgb(0, 64, 116);//AppBarHelper.ChangeColorBrightness(AppBarHelper.GetAccentColor(), (float)-0.45);
        }

        private void BtnAddConnection_MouseLeave(object sender, EventArgs e)
        {
            BtnAddConnection.ImageIndex = 0;
            BtnAddConnection.BackColor = BackColor;
        }

        private void CompactWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            HandleSnapping(true);
        }

        private void BtnAddConnection_Click(object sender, EventArgs e)
        {
            //ShowWindow(Process.GetCurrentProcess().MainWindowHandle, SW_RESTORE);
            Process currentProcess = Process.GetCurrentProcess();
            IntPtr mainWindowHandle = currentProcess.MainWindowHandle;

            if (mainWindowHandle != IntPtr.Zero)
            {
                // Získejte stav okna (minimalizované nebo ne).
                bool isMinimized = IsIconic(mainWindowHandle);

                // Pokud je okno minimalizované, obnovte ho.
                if (isMinimized)
                {
                    ShowWindow(mainWindowHandle, SW_RESTORE);
                }

                // Získejte pozornost na okno.
                SetForegroundWindow(mainWindowHandle);
            }
        }

        private void CompactWindow_Shown(object sender, EventArgs e)
        {
            this.Show();
            appBarHelper = new AppBarHelper(Handle, Size, Location);

            HandleSnapping(false);
            IsShown = true;
        }

        public void Maximize()
        {
            appBarHelper = new AppBarHelper(Handle, Size, Location);

            HandleSnapping(false);
            this.Visible = true;
            this.Focus();
        }

        public void Minimize()
        {
            this.Visible = false;
            appBarHelper = new AppBarHelper(Handle, Size, Location);

            HandleSnapping(true);
        }

        private static string GetButtonText(string NodeName)
        {
            return "          " + NodeName.Substring(0, Math.Min(23, NodeName.Length));
        }

        public struct SourceButton
        {
            public string Text { get; set; }
            public int IconListIndex { get; set; }
            public string NodeName { get; private set; }
            CompactWindow _currentCompactWindow;
            public bool IsMonitor { get; set; }

            public SourceButton(string text, int iconListIndex, CompactWindow currentCompactWindow, bool isMonitor)
            {
                Text = text;
                IconListIndex = iconListIndex;
                _currentCompactWindow = currentCompactWindow;
                NodeName =  Regex.Replace(Text, @"(\s*\[.*?\])", "");
                IsMonitor = isMonitor;
            }

            public NoFocusSourceButton Button
            {
                get
                {
                    NoFocusSourceButton myButton = new NoFocusSourceButton();
                    myButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    myButton.Dock = IsMonitor ? DockStyle.Top : DockStyle.Bottom;
                    myButton.FlatAppearance.BorderSize = 0;
                    myButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    myButton.ForeColor = System.Drawing.Color.White;
                    myButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    myButton.ImageList = IsMonitor ? _currentCompactWindow.monitorStates : _currentCompactWindow.RdmanIconsList;
                    myButton.Location = new System.Drawing.Point(0, 0);
                    myButton.Margin = new System.Windows.Forms.Padding(0);
                    myButton.UseVisualStyleBackColor = true;

                    myButton.Size = new System.Drawing.Size(160, 32);
                    myButton.Name = NodeName;
                    ToolTip1.SetToolTip(myButton, Text);

                    myButton.Text = GetButtonText(NodeName);
                    myButton.Tag = NodeName;
                    //myButton.TextAlign = ContentAlignment.MiddleRight;
                    myButton.ImageIndex = IconListIndex;

                    myButton.MouseEnter += MyButton_MouseEnter;
                    myButton.MouseLeave += MyButton_MouseLeave;
                    myButton.Click += MyButton_Click;

                    return myButton;
                }
            }

            private void MyButton_Click(object sender, EventArgs e)
            {
                if (IsMonitor)
                {
                    _currentCompactWindow.MonitorFocusApplication(((Button)sender).Tag.ToString());
                }
                else
                {
                    _currentCompactWindow.HandleSourceSelected(((Button)sender).Tag.ToString());
                }
            }

            private void MyButton_MouseLeave(object sender, EventArgs e)
            {
                if (((Button)sender).ImageList == _currentCompactWindow.monitorStates)
                {
                    ((Button)sender).ImageIndex = ((Button)sender).ImageIndex - 5;
                }
                else
                {
                    ((Button)sender).ImageIndex = ((Button)sender).ImageIndex - 7;
                }

                ((Button)sender).BackColor = Color.FromArgb(29, 29, 29);
            }

            private void MyButton_MouseEnter(object sender, EventArgs e)
            {
                ((Button)sender).BackColor = ((Button)sender).ImageList == _currentCompactWindow.monitorStates ?
                    MonitorButtonBackColor((Button)sender) :
                    AppBarHelper.ChangeColorBrightness(Color.FromArgb(29, 29, 29), (float)0.2);


                if (((Button)sender).ImageList == _currentCompactWindow.monitorStates)
                {
                    ((Button)sender).ImageIndex = ((Button)sender).ImageIndex + 5;
                }
                else
                {
                    ((Button)sender).ImageIndex = ((Button)sender).ImageIndex + 7;
                }
            }
        }

        private static Color MonitorButtonBackColor(Button button)
        {
            switch (button.ImageIndex)
            {
                case 0:
                    return Color.FromArgb(0, 152, 70);
                case 2:
                    return Color.Red;
                case 3:
                    return AppBarHelper.ChangeColorBrightness(Color.FromArgb(29, 29, 29), (float)0.2);
                case 4:
                    return Color.FromArgb(0, 64, 116);
                default:
                    return AppBarHelper.ChangeColorBrightness(Color.FromArgb(29, 29, 29), (float)0.2);
            }
        }

        public void UpdatePanelFromListView(ListView listView, bool isMonitor = false)
        {
            Panel panel = isMonitor ? this.PanelMonitored : this.PanelSources;

            // Remove non-existing items
            List<Button> buttonsToRemove = new List<Button>();
            foreach (object control in panel.Controls)
            {
                if (control is Button button)
                {
                    SourceButton inList = (isMonitor ? Monitor : Sources).FirstOrDefault(x => x.NodeName == button.Name);
                    ListViewItem matchingItem = listView.Items.Cast<ListViewItem>().FirstOrDefault(x => Regex.Replace(x.Text, @"(\s*\[.*?\])", "") == button.Name);
                    if (matchingItem == null)
                    {
                        (isMonitor ? Monitor : Sources).Remove(inList);
                        buttonsToRemove.Add(button);
                    }
                }
            }

            foreach (Button itemToRemove in buttonsToRemove)
            {
                panel.Controls.Remove(itemToRemove);
            }

            // Add or edit items
            foreach (ListViewItem listViewItem in listView.Items)
            {
                SourceButton existingSource = (isMonitor ? Monitor : Sources).FirstOrDefault(x => x.NodeName == Regex.Replace(listViewItem.Text, @"(\s*\[.*?\])", ""));
                
                if (!existingSource.Equals(new SourceButton()))
                {
                    foreach (object control in panel.Controls)
                    {
                        if (control is Button button)
                        {
                            // Pokud existuje odpovídající SourceButton, upravte ho
                            if (button != null && button.Name == listViewItem.Text)
                            {
                                button.Text = GetButtonText(listViewItem.Text);
                                if (!(isMonitor && (listViewItem.StateImageIndex == button.ImageIndex || listViewItem.StateImageIndex == button.ImageIndex - 5))) {
                                    button.ImageIndex = isMonitor ? listViewItem.StateImageIndex : listViewItem.ImageIndex;
                                }
                                
                            }
                        }
                    }
                }
                else
                {
                    // Pokud neexistuje, vytvořte nový SourceButton
                    if (listViewItem.ImageIndex != 7)
                    {
                        SourceButton monitoredSource = new SourceButton(listViewItem.Text, isMonitor ? listViewItem.StateImageIndex : listViewItem.ImageIndex, this, isMonitor);
                        panel.Controls.Add(monitoredSource.Button);
                        (isMonitor ? Monitor : Sources).Add(monitoredSource);
                    }
                }
            }

            if (!isMonitor) SortSourcesButtons(panel);
        }

        private void SortSourcesButtons(Panel panel)
        {
            // Převedeme Controls na kolekci Buttonů a provedeme řazení podle hodnoty Tag
            var buttonsToSort = panel.Controls.OfType<Button>().OrderBy(button => button.Tag?.ToString());
            List<Button> sortedButtonsToAdd = new List<Button>();
            // Odstraníme tlačítka z panelu

            foreach (Button buttonToRemove in buttonsToSort.ToList())
            {
                sortedButtonsToAdd.Add(buttonToRemove);
                panel.Controls.Remove(buttonToRemove);
            }

            // Přidáme tlačítka zpět do panelu ve správném pořadí
            foreach (Button buttonToAdd in sortedButtonsToAdd)
            {
                panel.Controls.Add(buttonToAdd);
            }
        }

        public void HandleChangesInSources(ListView sendedMonitor)
        {
            UpdatePanelFromListView(sendedMonitor);
        }

        public void HandleSourcesCleared(object sender, EventArgs e)
        {
            // Seznam pro ukládání tlačítek k odebrání
            List<Button> buttonsToRemove = new List<Button>();

            foreach (object control in this.PanelSources.Controls)
            {
                if (control is Button button)
                {
                    buttonsToRemove.Add(button);
                }
            }

            // Odeberte tlačítka ze seznamu a z this.PanelSources.Controls
            foreach (Button buttonToRemove in buttonsToRemove)
            {
                this.PanelSources.Controls.Remove(buttonToRemove);
            }
            Sources.Clear();
        }

        private void CompactWindow_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location != new Point(0, 0)) this.Location = new Point(0, 0);
        }

        public void HandleChangesInMonitor(ListView sendedMonitor)
        {
            UpdatePanelFromListView(sendedMonitor, true);
        }

        private void BtnMonitorPID_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).ImageIndex = 3;
            ((Button)sender).BackColor = AppBarHelper.ChangeColorBrightness(Color.FromArgb(29, 29, 29), (float)0.2);
        }

        private void BtnMonitorPID_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ImageIndex = 2;
            ((Button)sender).BackColor = Color.FromArgb(29, 29, 29);
        }

        private void BtnMonitorPID_Click(object sender, EventArgs e)
        {
            string pid = CommandGetValueMethod?.Invoke("Select PID Of process", false, "");
            if(pid != "") MonitorPidMethod?.Invoke(pid);
        }
    }

    public class StringChangeNotifier
    {
        private string myString;

        // Definujeme delegát pro událost. 
        public delegate void StringChangedEventHandler(object sender, EventArgs e);

        // Událost, která se vyvolá při změně obsahu string proměnné.
        public event StringChangedEventHandler StringChanged;

        public string MyString
        {
            get { return myString; }
            set
            {
                if (myString != value)
                {
                    myString = value;

                    // Pokud se obsah proměnné změní, vyvoláme událost.
                    OnStringChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnStringChanged(EventArgs e)
        {
            StringChanged?.Invoke(this, e);
        }
    }
}
