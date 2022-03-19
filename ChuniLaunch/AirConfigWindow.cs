using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class AirConfigWindow : Form {
        private const int BUTTON_WIDTH = 45;
        private const int BUTTON_HEIGHT = 49;

        private bool chusan;
        private IniFile segatools;
        private List<Keys> keyMappings = new List<Keys>();
        private int currAir = -1;
        private Button currButton;
        public AirConfigWindow(bool _chusan) {
            InitializeComponent();
            chusan = _chusan;
        }

        private void bSave_Click(object sender, EventArgs e) {
            for (int i = 0; i <= 5; i++) {
                var hexkey = $"0x{keyMappings[i]:X}";
                segatools.Write("ir" + (i + 1), hexkey, "io3");
            }
        }
        private void AirConfigWindow_KeyDown(object sender, KeyEventArgs e) {
            for (int i = 0; i <= 5; i++) {
                if (keyMappings[i] == e.KeyCode) {
                    ((Button)pIndicators.Controls[i]).BackColor = Color.LightGreen;
                }
            }
        }

        private void AirConfigWindow_KeyUp(object sender, KeyEventArgs e) {
            for (int i = 0; i <= 5; i++) {
                if (keyMappings[i] == e.KeyCode) {
                    ((Button)pIndicators.Controls[i]).BackColor = Color.LightCoral;
                }
            }
        }

        private string GetKeyName(Keys key) {
            var keyName = key.ToString();
            if (keyName.Length == 1) return key.ToString();
            else {
                if (keyName.StartsWith("D", StringComparison.InvariantCultureIgnoreCase) && keyName.Length == 2)
                    return keyName.Substring(1); //number row keys.
                if (keyName.StartsWith("Oem", StringComparison.InvariantCultureIgnoreCase)) {
                    //god here we go
                    if (keyName.Equals("OemBackslash", StringComparison.InvariantCultureIgnoreCase))
                        return "\\";
                    else if (keyName.Equals("OemCloseBrackets", StringComparison.InvariantCultureIgnoreCase) || keyName.Equals("Oem6", StringComparison.InvariantCultureIgnoreCase))
                        return "}";
                    else if (keyName.Equals("Oemcomma", StringComparison.InvariantCultureIgnoreCase))
                        return ",";
                    else if (keyName.Equals("OemMinus", StringComparison.InvariantCultureIgnoreCase))
                        return "-";
                    else if (keyName.Equals("OemOpenBrackets", StringComparison.InvariantCultureIgnoreCase))
                        return "{";
                    else if (keyName.Equals("OemPeriod", StringComparison.InvariantCultureIgnoreCase))
                        return ".";
                    else if (keyName.Equals("OemPipe", StringComparison.InvariantCultureIgnoreCase))
                        return "|";
                    else if (keyName.Equals("Oemplus", StringComparison.InvariantCultureIgnoreCase))
                        return "=";
                    else if (keyName.Equals("OemQuestion", StringComparison.InvariantCultureIgnoreCase))
                        return "/";
                    else if (keyName.Equals("OemQuotes", StringComparison.InvariantCultureIgnoreCase) || keyName.Equals("Oem7", StringComparison.InvariantCultureIgnoreCase))
                        return "'";
                    else if (keyName.Equals("OemSemicolon", StringComparison.InvariantCultureIgnoreCase) || keyName.Equals("Oem1", StringComparison.InvariantCultureIgnoreCase))
                        return ";";
                    else if (keyName.Equals("Oemtilde", StringComparison.InvariantCultureIgnoreCase))
                        return "~";
                }
                return keyName; //it could be something else but I can't be bothered
            }
        }

        private void RebindKeyHandler(object s, KeyEventArgs ev) {
            if (ev.KeyCode != Keys.Escape) {
                //escape cancels, otherwise set the key.
                keyMappings[currAir - 1] = ev.KeyCode;
                currButton.Text = $"{currAir}\n{GetKeyName(ev.KeyCode)}";
            }
            currButton.KeyDown -= RebindKeyHandler;
            lInfo.Text = $"Click each button to bind a key";
        }

        private void bKeyButton_Click(object sender, EventArgs e) {
            currAir = Convert.ToInt32(((Control)sender).Name.Substring(10));
            if (currButton != null) currButton.KeyDown -= RebindKeyHandler;
            currButton = ((Button)sender);
            var padsKey = keyMappings[currAir];
            lInfo.Text = $"Press a key to bind pad {currAir} (Esc to cancel)";
            currButton.KeyDown += RebindKeyHandler;
        }

        private void AirConfigWindow_Load(object sender, EventArgs e) {
            //generate the buttons on load
            segatools = new IniFile("segatools.ini");
            var currLocX = 0;
            var currLocY = 0;            
            for (int i = 1; i <= 6; i++) {
                Keys currMapping;
                var keyStr = segatools.Read("ir" + i, "io3");
                if (String.IsNullOrWhiteSpace(keyStr)) {
                    switch (i) {
                        case 1: currMapping = Keys.OemQuestion; break;
                        case 2: currMapping = Keys.OemPeriod; break;
                        case 3: currMapping = Keys.OemQuotes; break;
                        case 4: currMapping = Keys.Oem1; break;
                        case 5: currMapping = Keys.OemOpenBrackets; break;
                        default: currMapping = Keys.Oem6; break;
                    }
                } else {
                    var keyInt = Convert.ToInt32(keyStr, 16);
                    currMapping = (Keys)keyInt;
                }
                keyMappings.Add(currMapping);
                var newB = new Button();
                newB.Name = "bAirButton" + i;
                newB.BackColor = Color.LightCoral;
                newB.FlatStyle = FlatStyle.Standard;
                newB.Font = new Font(newB.Font.FontFamily, 10, FontStyle.Bold);
                newB.Text = $"{i}\n{GetKeyName(currMapping)}";
                newB.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                newB.Parent = pIndicators;
                newB.Location = new Point(currLocX, currLocY);
                newB.Click += bKeyButton_Click;
                newB.KeyDown += AirConfigWindow_KeyDown;
                newB.KeyUp += AirConfigWindow_KeyUp;
                currLocX += BUTTON_WIDTH;

            }
        }
    }
}
