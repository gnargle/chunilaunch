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
    public partial class SliderConfigWindow : Form {

        private const int BUTTON_WIDTH = 45;
        private const int BUTTON_HEIGHT = 49;

        private bool chusan;
        private IniFile segatools;
        private List<Keys> keyMappings = new List<Keys>();
        private int currPad = -1;
        private Button currButton;

        public SliderConfigWindow(bool _chusan) {
            InitializeComponent();
            chusan = _chusan; //not needed for slider currently but might as well add it in case.
        }

        private void RebindKeyHandler (object s, KeyEventArgs ev) {
            if (ev.KeyCode != Keys.Escape) {
                //escape cancels, otherwise set the key.
                keyMappings[currPad-1] = ev.KeyCode;
                currButton.Text = $"{currPad}\n{GetKeyName(ev.KeyCode)}";
            }
            currButton.KeyDown -= RebindKeyHandler;
            lInfo.Text = $"Click each button to bind a key";
        }

        private void bKeyButton_Click(object sender, EventArgs e) {
            currPad = Convert.ToInt32(((Control)sender).Name.Substring(10));
            if (currButton != null) currButton.KeyDown -= RebindKeyHandler;
            currButton = ((Button)sender);
            lInfo.Text = $"Press a key to bind pad {currPad} (Esc to cancel)";
            currButton.KeyDown += RebindKeyHandler;
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

        private void SliderConfigWindow_Load(object sender, EventArgs e) {
            //generate the buttons on load
            segatools = new IniFile("segatools.ini"); 
            var currLocX = 0;
            var currLocY = 0;
            for (int i = 32; i > 0; i--) {
                Keys currMapping;

                var keyStr = segatools.Read("cell" + i, "slider");
                if (String.IsNullOrWhiteSpace(keyStr)) {
                    if (i >= 1 && i <= 4) 
                        currMapping = Keys.L;
                    else if (i >= 5 && i <= 8)
                        currMapping = Keys.K;
                    else if (i >= 9 && i <= 12)
                        currMapping = Keys.J;
                    else if (i >= 13 && i <= 16)
                        currMapping = Keys.H;
                    else if (i >= 17 && i <= 20)
                        currMapping = Keys.G;
                    else if (i >= 21 && i <= 24)
                        currMapping = Keys.F;
                    else if (i >= 25 && i <= 28)
                        currMapping = Keys.D;
                    else
                        currMapping = Keys.S;
                } else {
                    var keyInt = Convert.ToInt32(keyStr, 16);
                    currMapping = (Keys)keyInt;
                }
                keyMappings.Add(currMapping);

                var newB = new Button();
                newB.Name = "bKeyButton" + i;
                newB.BackColor = Color.LightCoral;
                newB.FlatStyle = FlatStyle.Standard;
                newB.Font = new Font(newB.Font.FontFamily, 10, FontStyle.Bold);
                newB.Text = $"{i}\n{GetKeyName(currMapping)}";
                newB.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                newB.Parent = pIndicators;
                newB.Location = new Point(currLocX, currLocY);
                newB.Click += bKeyButton_Click;
                newB.KeyDown += SliderConfigWindow_KeyDown;
                newB.KeyUp += SliderConfigWindow_KeyUp;
                if (i % 2 == 0) { //top row
                    currLocY = BUTTON_HEIGHT;
                } else {
                    currLocX += BUTTON_WIDTH;
                    currLocY = 0;
                }
            }
            keyMappings.Reverse(); //we put them in starting at 0, so let's reverse the list to match up with the actual order.
        }

        private void bDone_Click(object sender, EventArgs e) {
            for(int i = 0; i <= 31; i++) {
                var hexkey = $"0x{keyMappings[i]:X}";
                segatools.Write("cell" + (i+1), hexkey, "slider");
            }
        }

        private void SliderConfigWindow_KeyDown(object sender, KeyEventArgs e) {
            for (int i = 0; i <= 31; i++) {
                if (keyMappings[i] == e.KeyCode) {
                    ((Button)pIndicators.Controls[31 - i]).BackColor = Color.LightGreen;
                }
            }
        }

        private void SliderConfigWindow_KeyUp(object sender, KeyEventArgs e) {
            for (int i = 0; i <= 31; i++) {
                if (keyMappings[i] == e.KeyCode) {
                    ((Button)pIndicators.Controls[31 - i]).BackColor = Color.LightCoral;
                }
            }
        }
    }
}
