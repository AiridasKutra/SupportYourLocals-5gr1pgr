using Common;
using GoogleMaps.LocationServices;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes;
using localhostUI.Classes.EventClasses;
using localhostUI.Classes.LocationClasses;
using localhostUI.Classes.UserInformationClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace localhostUI.UiEvent
{
    public partial class UiEventDisplayPanel : Form, IPanel
    {
        private EventFull @event;
        private ChatManager chatManager;

        private UiMain mainForm;
        private IPanel caller;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public UiEventDisplayPanel(int eventId, IPanel caller)
        {
            // Get full event data from database
            List<EventFull> events = Program.Client.SelectEventsFull(eventId);
            try
            {
                @event = events[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"ERROR: Event with id {eventId} not found");
                throw;
            }

            UserAccount acc = Program.UserDataManager.UserAccount;

            this.caller = caller;

            InitializeComponent();

            // Set return button image
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreen;

            // Enforce permissions
            if (!acc.Can((uint)Permissions.CREATE_REPORTS))
            {
                reportButton.Visible = false;
            }
            if (acc.Can((uint)Permissions.SET_EVENT_VISIBILITY))
            {
                setVisibilityButton.Visible = true;
                if (!@event.Visible)
                {
                    setVisibilityButton.BackColor = Color.FromArgb(109, 168, 135);
                    setVisibilityButton.Text = "Make visible";
                }
                else
                {
                    setVisibilityButton.BackColor = Color.Tomato;
                    setVisibilityButton.Text = "Make invisible";
                }
            }
            if (!acc.Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                if (acc.Id == -1)
                {
                    chatMessageTextBox.PlaceholderText = "Log in to comment";
                    chatMessageTextBox.Enabled = false;
                }
                else
                {
                    chatMessageTextBox.PlaceholderText = "You don't have the permission to comment";
                    chatMessageTextBox.Enabled = false;
                }
            }

            // Title
            eventName.Text = @event.Name;

            // Sports
            foreach (var sport in @event.Sports)
            {
                Label sportLabel = new Label();
                sportLabel.AutoSize = true;
                sportLabel.Text = sport;
                sportLabel.BackColor = Color.FromArgb(230, 230, 230);
                sportLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                //sportDisplayBar.Controls.Add(sportLabel);
            }

            // Distance
            UserData user = Program.UserDataManager.GetData();
            double distance = MathSupplement.Distance(@event.Latitude, @event.Longitude, user.Latitude, user.Longitude);
            if (distance < 1000.0)
            {
                distanceLabel.Text = $"{distance:0}m";
            }
            else
            {
                distanceLabel.Text = $"{distance / 1000.0:0.0}km";
            }

            // Distance and address separator
            Size distanceLabelSize = Helper.CalculateLabelSize(distanceLabel, 100);
            separatorPanel1.Location = new Point(distanceLabel.Location.X + distanceLabelSize.Width, separatorPanel1.Location.Y);

            // Address
            addressLabel.Location = new Point(distanceLabel.Location.X + distanceLabelSize.Width + 10, addressLabel.Location.Y);
            addressLabel.Text = @event.Address.ToStringNormal();

            // Show map button
            Size addressLabelSize = Helper.CalculateLabelSize(addressLabel, 500);
            showMapsButton.Location = new Point(addressLabel.Location.X + addressLabelSize.Width + 5, showMapsButton.Location.Y);
            showMapsButton.BackgroundImage = Properties.Resources.MapsButton;

            // Load images
            List<string> imageLinks = @event.Images;
            int counter = 0;
            foreach (var image in @event.Images)
            {
                int IMAGE_WIDTH = 180;
                int IMAGE_HEIGHT = 180;
                int MARGINS = 10;

                PictureBox picture = new PictureBox();
                picture.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                picture.Location = new Point((IMAGE_WIDTH + MARGINS) * counter, 0);
                picture.BorderStyle = BorderStyle.None;

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            Stream stream = client.OpenRead(image);
                            Bitmap bitmap = new Bitmap(stream);

                            picture.Image = Helper.ScaleBitmap(bitmap, IMAGE_WIDTH, IMAGE_HEIGHT, 1.0f);

                            stream.Flush();
                            stream.Close();
                        }
                    }
                    catch { }
                };
                worker.RunWorkerAsync();

                picturePanel.Controls.Add(picture);
                counter++;
            }

            picturePanel.VerticalScroll.Maximum = 0;
            picturePanel.AutoScroll = false;
            picturePanel.HorizontalScroll.Visible = false;
            picturePanel.AutoScroll = true;

            // Description
            descriptionLabel.Text = @event.Description;
            Size descriptionLabelSize = Helper.CalculateLabelSize(descriptionLabel, descriptionLabel.MaximumSize.Width);

            // Description and comment separator
            separatorPanel4.Location = new Point(separatorPanel4.Location.X, descriptionLabel.Location.Y + descriptionLabelSize.Height + 28);

            // Show reports
            List<Report> reports = Program.Client.SelectReports(eventId);

            int height = 0;
            if (reports.Count > 0)
            {
                reportsPanel.Visible = true;
                reportsPanel.Location = new Point(reportsPanel.Location.X, separatorPanel4.Location.Y + 10);
                reportsPanel.BackColor = Color.FromArgb(255, 200, 200);

                reportsPanel.HorizontalScroll.Maximum = 0;
                reportsPanel.AutoScroll = false;
                reportsPanel.VerticalScroll.Visible = false;
                reportsPanel.AutoScroll = true;

                height = 20;

                foreach (var report in reports)
                {
                    Label reportType = new Label();
                    reportType.Text = report.Type;
                    reportType.Font = new Font("Arial", 12, FontStyle.Bold);
                    reportType.ForeColor = Color.FromArgb(64, 64, 64);
                    reportType.Location = new Point(0, 0);
                    reportType.AutoSize = false;
                    reportType.Size = new Size(940, 26);
                    reportType.TextAlign = ContentAlignment.MiddleLeft;

                    Label reportComment = new Label();
                    reportComment.Text = report.Comment;
                    reportComment.Font = new Font("Arial", 12);
                    reportComment.ForeColor = Color.FromArgb(64, 64, 64);
                    reportComment.Location = new Point(0, 26);
                    reportComment.AutoSize = false;
                    Size reportSize = Helper.CalculateLabelSize(reportComment, 940);
                    reportComment.Size = new Size(940, reportSize.Height);
                    reportComment.TextAlign = ContentAlignment.MiddleLeft;

                    Panel reportPanel = new Panel();
                    reportPanel.Size = new Size(940, 26 + reportComment.Size.Height);
                    reportPanel.Location = new Point(20, height);

                    height += reportPanel.Size.Height + 20;

                    reportPanel.Controls.Add(reportType);
                    reportPanel.Controls.Add(reportComment);
                    reportsPanel.Controls.Add(reportPanel);
                }

                if (height > 150)
                {
                    height = 150;
                }

                reportsPanel.Size = new Size(reportsPanel.Size.Width, height);
            }

            // Comments panel
            commentsPanel.Location = new Point(commentsPanel.Location.X, separatorPanel4.Location.Y + 10 + height + 10 * (height > 0 ? 1 : 0));

            // New comment
            chatMessageTextBox.Location = new Point(0, 0);

            // Submit new comment
            sendMessageButton.Location = new Point(sendMessageButton.Location.X, chatMessageTextBox.Location.Y + chatMessageTextBox.Size.Height + 6);

            // Chat panel
            chatPanel.Location = new Point(chatPanel.Location.X, sendMessageButton.Location.Y + sendMessageButton.Size.Height + 6);

            // Load comments
            List<Backend.Message> messages = Program.Client.SelectEventComments(@event.Id);
            messages.Reverse();
            /*
            messages.Add(new Backend.Message()
            {
                Sender = 0,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi" +
                "lietuva hujon eina o algos tai irgi po jevrejo nebekyla, o vat maisto kainos tai ojojoj" +
                "kaip i virsu skuodzia ir va kaip man uz minimuma pragyvent blyat kai reika nauja telef" +
                "ona pirk kiekviena meta nu blet negerai cia",
                SendTime = DateTime.Now
            });
            messages.Add(new Backend.Message()
            {
                Sender = 0,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi",
                SendTime = DateTime.Now
            });
            messages.Add(new Backend.Message()
            {
                Sender = 1,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi",
                SendTime = DateTime.Now
            });
            messages.Add(new Backend.Message()
            {
                Sender = 2,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi",
                SendTime = DateTime.Now
            });
            messages.Add(new Backend.Message()
            {
                Sender = 3,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi",
                SendTime = DateTime.Now
            });
            messages.Add(new Backend.Message()
            {
                Sender = 0,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi",
                SendTime = DateTime.Now
            });
            messages.Add(new Backend.Message()
            {
                Sender = 0,
                Content = "Gražulis blet sake kad ne gejus tai kuo ,man dabar tiket nx pasaulis ritasi",
                SendTime = DateTime.Now
            });
            */

            height = 0;
            if (messages.Count > 0)
            {
                chatPanel.Controls.Clear();

                height = 20;

                foreach (var msg in messages)
                {
                    string username = Program.Client.SelectAccountUsername(msg.Sender);

                    Label senderInfoLabel = new Label();
                    senderInfoLabel.Text = $"By {username} at {msg.SendTime:yyyy-MM-dd HH:mm}";
                    senderInfoLabel.Font = new Font("Arial", 10, FontStyle.Italic);
                    senderInfoLabel.ForeColor = Color.Gray;
                    senderInfoLabel.Location = new Point(0, 0);
                    senderInfoLabel.AutoSize = false;
                    senderInfoLabel.Size = new Size(920, 20);
                    senderInfoLabel.TextAlign = ContentAlignment.MiddleLeft;

                    Label commentLabel = new Label();
                    commentLabel.Text = msg.Content;
                    commentLabel.Font = new Font("Arial", 12);
                    commentLabel.ForeColor = Color.FromArgb(64, 64, 64);
                    commentLabel.BackColor = Color.White;
                    commentLabel.Location = new Point(0, 20);
                    commentLabel.Padding = new Padding(10);
                    commentLabel.AutoSize = false;
                    Size reportSize = Helper.CalculateLabelSize(commentLabel, 920);
                    commentLabel.Size = new Size(920, reportSize.Height + 20);
                    commentLabel.TextAlign = ContentAlignment.MiddleLeft;

                    Panel commentPanel = new Panel();
                    commentPanel.Size = new Size(920, 20 + commentLabel.Size.Height);
                    commentPanel.Location = new Point(20, height);

                    height += commentPanel.Size.Height + 20;

                    commentPanel.Controls.Add(senderInfoLabel);
                    commentPanel.Controls.Add(commentLabel);
                    chatPanel.Controls.Add(commentPanel);
                }

                chatPanel.Size = new Size(chatPanel.Size.Width, height);
            }
            commentsPanel.Size = new Size(commentsPanel.Size.Width, chatPanel.Location.Y + chatPanel.Size.Height);

            mainPanel.Size = new Size(1000, commentsPanel.Location.Y + commentsPanel.Size.Height + 20);

            // Chat
            chatMessageTextBox.KeyPress += new KeyPressEventHandler(Key_Press);

            // Start chat
            //chatManager = new ChatManager();
            //chatManager.Connect(@event.Id, chatPanel);

            // Links
            //List<string> links = @event.Links;
            //for (int i = 0; i < links.Count; i++)
            //{
            //    string[] linkSplit = links[i].Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            //    if (linkSplit.Length != 2) continue;

            //    LinkLabel linkText = new LinkLabel();
            //    linkText.Text = linkSplit[1];
            //    linkText.LinkClicked += (sender, e) =>
            //    {
            //        Process.Start(new ProcessStartInfo("cmd", $"/c start {linkSplit[0]}"));
            //    };
            //    linkText.Location = new Point(426, 370 + (i * 20));

            //    Controls.Add(linkText);
            //}
        }

        private void ShowAddressButton_Click(object sender, EventArgs e)
        {
            AddressData data = LocationInformation.AddressFromLatLong(@event.Latitude, @event.Longitude);
            LocationInformation.OpenAdressInBrowser(data.Address);
        }

        private void Key_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (chatMessageTextBox.Text.Length == 0) return;

                SendMessage(chatMessageTextBox.Text);
                chatMessageTextBox.Text = "";
                //e.SuppressKeyPress = true;
            }
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            if (chatMessageTextBox.Text.Length == 0) return;

            SendMessage(chatMessageTextBox.Text);
            chatMessageTextBox.Text = "";
        }

        private void SendMessage(string message)
        {
            //chatManager.SendMessage(new Backend.Message { Content = message });
            Program.Client.SendComment(new Backend.Message { Content = message }, @event.Id);
            Thread.Sleep(500);
            mainForm.ShowPanel(new UiEventDisplayPanel(@event.Id, caller));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Properly disconnect and close chat manager
            chatManager.Disconnect();
        }

        private void chatMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void returnButton_MouseEnter(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreenHover;
        }

        private void returnButton_MouseLeave(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.BackButtonGreen;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(caller);
        }

        private void reportButton_MouseEnter(object sender, EventArgs e)
        {
            reportButton.BackgroundImage = Properties.Resources.ReportButtonHover;
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(new CreateReportPanel(@event.Id, this));
        }

        private void reportButton_MouseLeave(object sender, EventArgs e)
        {
            reportButton.BackgroundImage = Properties.Resources.ReportButton;
        }

        private void showMapsButton_MouseEnter(object sender, EventArgs e)
        {
            showMapsButton.BackgroundImage = Properties.Resources.MapsButtonHover;
        }

        private void showMapsButton_MouseLeave(object sender, EventArgs e)
        {
            showMapsButton.BackgroundImage = Properties.Resources.MapsButton;
        }

        private void setVisibilityButton_Click(object sender, EventArgs e)
        {
            if (!@event.Visible)
            {
                setVisibilityButton.BackColor = Color.FromArgb(109, 168, 135);
                setVisibilityButton.Text = "Make visible";
                Program.Client.SetEventVisible(@event.Id);
            }
            else
            {
                setVisibilityButton.BackColor = Color.Tomato;
                setVisibilityButton.Text = "Make invisible";
                Program.Client.SetEventInvisible(@event.Id);
            }
            mainForm.ShowPanel(new UiEventDisplayPanel(@event.Id, caller));
        }
    }
}
