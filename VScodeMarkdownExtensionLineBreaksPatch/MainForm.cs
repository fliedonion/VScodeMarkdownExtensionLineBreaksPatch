using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VScodeMarkdownExtensionLineBreaksPatch {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            vscodePathTextBox.ReadOnly = true;
        }

        private const string vscode = @"C:\Program Files (x86)\Microsoft VS Code";
        private const string target = @"C:\Program Files (x86)\Microsoft VS Code\resources\app\extensions\markdown\out\extension.js";
        private const string package_json = @"C:\Program Files (x86)\Microsoft VS Code\resources\app\extensions\markdown\package.json";

        private Dictionary<string, string> supportedVersions = new Dictionary<string, string>{
                                                     {@"""version"": ""0.2.0""", "0.2.0"}
                                                 };


        private void MainForm_Load(object sender, EventArgs e) {
            if(Directory.Exists(vscode) && File.Exists(target)){
                vscodePathTextBox.Text = target;
            }
            else {
                MessageBox.Show("VScode not found.", "sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void AppendLog(string text) {
            logText.AppendText(text + Environment.NewLine);
        }


        private void execButton_Click(object sender, EventArgs e) {
            execButton.Visible = false;
            try {
                AppendLog("Start :" + DateTime.Now.ToString());

                AppendLog("Checking  is target file expected version.");

                if (!CheckVersion()) {
                    if(DialogResult.Yes != MessageBox.Show("vscode-markdown may not supported version. Do you want to continue ?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)){

                        AppendLog("User canceled.");
                        return;
                    }
                }
                AppendLog("Affect Patch.");

                var result = RunPatch();


                AppendLog("Display Result.");
                switch (result) {
                    case Results.Success:
                        MessageBox.Show("Complete.", "vscode-markdown patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case Results.MayBeAlreadyPatched:
                        MessageBox.Show("Targetfile may be already patched.", "vscode-markdown patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case Results.TargetLineNotFound:
                        MessageBox.Show("Target line couldn't find. Nothing to do.", "vscode-markdown patch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        MessageBox.Show("Unknown Result code("+result.ToString()+").", "vscode-markdown patch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error." + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                execButton.Visible = true; AppendLog("End :" + DateTime.Now.ToString());
            }
        }

        private bool CheckVersion() {
            using (var sr = new StreamReader(package_json)) {
                var line = "";
                while ((line = sr.ReadLine()) != null) {
                    if(supportedVersions.Keys.Any(x => line.Contains(x))){
                        // var version = supportedVersions.First(x => line.Contains(x.Key)).Value;
                        return true;
                    }
                }
            }
            return false;
        }

        public enum Results{
            None,
            Success,
            TargetLineNotFound,
            MayBeAlreadyPatched,
        }

        private Results RunPatch() {
            var lineset = GetLineSet();

            var inserted = false;
            var tmp = Path.GetTempFileName();
            AppendLog("PatchStart.");

            using(var sw = new StreamWriter(tmp, false, Encoding.UTF8))
            using (var sr = new StreamReader(target, Encoding.UTF8)) {
                var line = "";
                var beforeLineFoundIndex = 0;

                while ((line = sr.ReadLine()) != null) {
                    if (line == lineset.AfterLine && beforeLineFoundIndex == lineset.BeforeLines.Count) {
                        sw.WriteLine(lineset.Insert);
                        inserted = true;
                        AppendLog("Data Inserted.");
                    }
                    if (line == lineset.Insert && beforeLineFoundIndex == lineset.BeforeLines.Count) {
                        AppendLog("Detect `Already patched`.");
                        return Results.MayBeAlreadyPatched;
                    }
                    if (!inserted) {
                        if (beforeLineFoundIndex < lineset.BeforeLines.Count && line == lineset.BeforeLines[beforeLineFoundIndex]) {
                            beforeLineFoundIndex++;
                        }
                        else {
                            beforeLineFoundIndex = 0;
                        }
                    }
                    sw.WriteLine(line);
                }
            }
            if (!inserted) {
                AppendLog("Target line missing.");
                return Results.TargetLineNotFound;
            }

            AppendLog("Backup original file.");
            File.Move(target, target + DateTime.Now.ToString(".yyyyMMddHHmmss") + ".backup");

            AppendLog("Copy patched file to vscode-markdown directory(" + target + ").");
            File.Copy(tmp, target);

            return Results.Success;
        }

        class LineSet{
            public List<string> BeforeLines ;
            public string Insert = "            breaks: vscode.workspace.getConfiguration('markdown')['markdown-it-breaks']||false,";
            public string AfterLine;
            
        }

        private LineSet GetLineSet(){
            var ls = new LineSet();
            ls.BeforeLines = new List<string> {
                                    "    MDDocumentContentProvider.prototype.createRenderer = function () {"
                                    ,"        var hljs = require('highlight.js');"
                                    ,"        var mdnh = require('markdown-it-named-headers');"
                                    ,"        var md = require('markdown-it')({"};
            ls.AfterLine = "            html: true,";

            return ls;

    }



    }
}
