using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebHookTesting
{
    public partial class Form1 : Form
    {
        private bool isDark = true;

        [DllImport("Gdi32.dll")]
        static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int w, int h);

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMethod.SelectedIndex = 0;
            StyleButton(btnSend, Color.FromArgb(0, 120, 215));
            ApplyTheme();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            txtResponse.Clear();
            progressBar.Value = 0;
            lblStatusBadge.Visible = false;

            // Validate URL
            if (!Uri.TryCreate(txtUrl.Text.Trim(), UriKind.Absolute, out var uri))
            {
                MessageBox.Show("Please enter a valid webhook URL.", "Invalid URL",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            btnSend.Enabled = false;
            lblStatus.Text = "Sending request...";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                string jsonPayload = "{\"text\": \"" + EscapeJsonString(txtRequest.Text) + "\"}";
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonPayload);
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                // Write request body (ASYNC)
              
                // Simulated progress
                await SimulateProgress();

                // Get response (ASYNC)
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string body = await reader.ReadToEndAsync();

                    progressBar.Value = 100;
                    ShowStatus((int)response.StatusCode);

                    txtResponse.Text = IsJson(body) ? Pretty(body) : body;
                    lblStatus.Text = "Request completed";

                   
                }
            }
            catch (WebException ex) when (ex.Response is HttpWebResponse errorResponse)
            {
                using var reader = new StreamReader(errorResponse.GetResponseStream());
                string errorBody = reader.ReadToEnd();

                txtResponse.Text = errorBody;
                ShowStatus((int)errorResponse.StatusCode);
                lblStatus.Text = $"Webhook failed {errorResponse.StatusCode}: {errorBody}";

               
            }
            catch (Exception ex)
            {
                txtResponse.Text = ex.ToString();
                lblStatus.Text = "Unexpected error: {ex}";
                ShowStatus(500);

              
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }



        private void ShowStatus(int code)
        {
            lblStatusBadge.Visible = true;
            lblStatusBadge.Text = $"HTTP {code}";
            lblStatusBadge.ForeColor = Color.White;

            lblStatusBadge.BackColor =
                code >= 200 && code < 300 ? Color.ForestGreen :
                code >= 400 ? Color.Firebrick : Color.Goldenrod;
        }

        private async Task SimulateProgress()
        {
            for (int i = 0; i <= 90; i += 5)
            {
                progressBar.Value = i;
                await Task.Delay(30);
            }
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            isDark = !isDark;
            btnTheme.Text = isDark ? "🌙" : "☀️";
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            Color bg = isDark ? Color.FromArgb(30, 30, 30) : Color.White;
            Color box = isDark ? Color.FromArgb(45, 45, 48) : Color.WhiteSmoke;
            Color fg = isDark ? Color.White : Color.Black;

            BackColor = bg;

            foreach (Control c in Controls)
                ApplyThemeRecursive(c, bg, box, fg);
        }

        private void ApplyThemeRecursive(Control c, Color bg, Color box, Color fg)
        {
            c.ForeColor = fg;

            if (c is TextBox || c is RichTextBox)
                c.BackColor = box;
            else
                c.BackColor = bg;

            foreach (Control child in c.Controls)
                ApplyThemeRecursive(child, bg, box, fg);
        }
        private static string EscapeJsonString(string input)
        {
            return input.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 10, 10));
        }

        private bool IsJson(string s)
        {
            try { JsonDocument.Parse(s); return true; }
            catch { return false; }
        }

        private string Pretty(string json)
        {
            using var doc = JsonDocument.Parse(json);
            return JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
