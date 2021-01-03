using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using localhost.Backend;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using WebApi;
using WebApi.Classes;
using localhost.Backend.Location;
using GoogleMaps.LocationServices;

namespace localhost.ActivityControllers
{
    [Activity(Label = "EventEditorActivity")]
    public class EventEditorActivity : Activity
    {
        EditText nameInput;
        EditText dateInput;
        EditText timeInput;
        AutoCompleteTextView sportInput;
        EditText priceInput;
        EditText addressInput;
        EditText tagInput;
        EditText imageLinkInput;
        LinearLayout eventImages;
        EditText descriptionInput;

        Bitmap defaultImage;
        Bitmap brokenImage;
        ImageButton addImageButton;

        ImageButton leftFinishButton;
        ImageButton rightFinishButton;

        decimal verifiedPrice;
        AddressInfo verifiedAddress;
        MapPoint verifiedCoordinates;

        private static Event _event = null;
        private static bool _draft = false;
        private static bool _paramsSet = false;
        private static EventManagerActivity _managerReference = null;

        public static void SetParams(Event @event, bool draft)
        {
            _event = @event;
            _draft = draft;
            _paramsSet = true;
            _managerReference = null;
        }

        public static void SetManagerReference(EventManagerActivity reference)
        {
            _managerReference = reference;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.event_editor);

            nameInput = FindViewById<EditText>(Resource.Id.createEventNameTextBox);
            dateInput = FindViewById<EditText>(Resource.Id.createEventDateSelect);
            timeInput = FindViewById<EditText>(Resource.Id.createEventTimeSelect);
            sportInput = FindViewById<AutoCompleteTextView>(Resource.Id.createEventSportTextBox);
            priceInput = FindViewById<EditText>(Resource.Id.createEventPriceSet);
            addressInput = FindViewById<EditText>(Resource.Id.createEventAddressTextBox);
            tagInput = FindViewById<EditText>(Resource.Id.createEventTagsTextBox);
            imageLinkInput = FindViewById<EditText>(Resource.Id.createEventImageLinkTextBox);
            eventImages = FindViewById<LinearLayout>(Resource.Id.createEventImageLayout);
            descriptionInput = FindViewById<EditText>(Resource.Id.createEventDescriptionTextBox);

            defaultImage = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.image_none), 450, 450, true);
            brokenImage = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.image_broken), 450, 450, true);
            addImageButton = FindViewById<ImageButton>(Resource.Id.createEventAddImageButton);
            addImageButton.Click += AddImage;

            leftFinishButton = FindViewById<ImageButton>(Resource.Id.createEventFinishLeftImageButton);
            rightFinishButton = FindViewById<ImageButton>(Resource.Id.createEventFinishRightImageButton);

            if (_event == null)
            {
                _event = new Event();
                _event.StartDate = DateTime.Now;
                leftFinishButton.Click += CreateEvent;
                leftFinishButton.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.upload_button_round));
                rightFinishButton.Click += SaveDraft;
                rightFinishButton.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.save_button_round));
            }
            else
            {
                if (_draft)
                {
                    leftFinishButton.Click += CreateEvent;
                    leftFinishButton.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.upload_button_round));
                    rightFinishButton.Click += SaveDraft;
                    rightFinishButton.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.save_button_round));
                }
                else
                {
                    leftFinishButton.Click += EditEvent;
                    leftFinishButton.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.done_button_round));
                    rightFinishButton.Click += DeleteEvent;
                    rightFinishButton.SetImageBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.delete_button_round));
                }
            }

            nameInput.Text = _event.Name;
            FormatDateAndTimeFields();
            sportInput.Text = _event.Sports.FirstOrDefault();
            priceInput.Text = _event.Price.ToString();
            addressInput.Text = _event.Address.ToStringNormal();
            tagInput.Text = _event.Tags;
            imageLinkInput.Text = "";
            descriptionInput.Text = _event.Description;

            // Date picker
            dateInput.Focusable = false;
            dateInput.Click += (sender, e) =>
            {
                DateTime today = DateTime.Today.Date;
                DatePickerDialog dialog = new DatePickerDialog(this, OnStartDateSet, today.Year, today.Month - 1, today.Day);
                //dialog.DatePicker.DateTime
                dialog.DatePicker.MinDate = (long)(today - new DateTime(1970, 1, 1)).TotalMilliseconds;
                dialog.DatePicker.MaxDate = DateTime.MaxValue.Ticks;
                dialog.Show();
            };

            // Time picker
            timeInput.Focusable = false;
            timeInput.Click += (sender, e) =>
            {
                DateTime now = DateTime.Now;
                TimePickerDialog dialog = new TimePickerDialog(this, OnStartTimeSet, now.Hour, now.Minute, true);
                dialog.Show();
            };

            // Add sport selections
            var sportList = RequestSender.GetSports().Select(item => item.Name).ToArray();
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, sportList);
            sportInput.Adapter = adapter;

            LoadImages();
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (_paramsSet == false)
            {
                throw new InvalidOperationException("SetParams() must be called before creating EventEditorActivity");
            }
            _paramsSet = false;
        }

        private void AddImage(object sernder, EventArgs e)
        {
            string link = imageLinkInput.Text;
            if (link.Length == 0) return;
            if (_event.Images.IndexOf(link) >= 0) return;
            _event.Images.Add(link);
            imageLinkInput.Text = "";
            imageLinkInput.Enabled = false;
            imageLinkInput.Enabled = true;
            LoadImages();
        }

        private void LoadImages()
        {
            eventImages.RemoveAllViews();

            int imageWidth = 700;
            int imageHeight = 450;
            foreach (var item in _event.Images)
            {
                Bitmap img;
                Bitmap scaledImg = Bitmap.CreateBitmap(imageWidth, imageHeight, Bitmap.Config.Argb8888);

                ImageView imgView = new ImageView(this);
                imgView.SetImageBitmap(scaledImg);
                LinearLayout.LayoutParams imgViewParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent, 0.0f);
                imgViewParams.SetMargins(16, 16, 16, 16);
                imgView.LayoutParameters = imgViewParams;
                imgView.LongClick += (o, e) =>
                {
                    PopupMenu menu = new PopupMenu(this, imgView);
                    menu.MenuInflater.Inflate(Resource.Menu.event_editor_image_menu, menu.Menu);
                    menu.MenuItemClick += (o, args) =>
                    {
                        string selection = args.Item.TitleFormatted.ToString();
                        if (selection == "Remove")
                        {
                            _event.Images.Remove(item);
                            LoadImages();
                        }
                        else if (selection == "Set as thumbnail")
                        {
                            _event.Images.Remove(item);
                            _event.Images.Insert(0, item);
                            LoadImages();
                        }
                    };
                    menu.Show();
                };
                eventImages.AddView(imgView);

                RunOnUiThread(() =>
                {
                    try
                    {
                        using var webClient = new WebClient();

                        var imageBytes = webClient.DownloadData(item);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            img = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                            scaledImg = Helper.ScaleBitmap(img, imageWidth, imageHeight);
                            imgView.Alpha = 0.0f;
                            imgView.SetImageBitmap(scaledImg);
                            imgView.Animate().Alpha(1.0f);
                        }
                    }
                    catch (Exception e)
                    {
                        Toast.MakeText(this, "Unable to load image", ToastLength.Long).Show();
                        imgView.SetImageBitmap(brokenImage);
                    }
                });
            }

            if (_event.Images.Count == 0)
            {
                ImageView imgView = new ImageView(this);
                imgView.SetImageBitmap(defaultImage);
                LinearLayout.LayoutParams imgViewParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent, 0.0f);
                imgViewParams.SetMargins(16, 16, 16, 16);
                imgView.LayoutParameters = imgViewParams;
                eventImages.AddView(imgView);
            }
        }

        private void OnStartDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            _event.StartDate = new DateTime(e.Date.Year, e.Date.Month, e.Date.Day, _event.StartDate.Hour, _event.StartDate.Minute, 0);
            FormatDateAndTimeFields();
            VerifyEnteredData();
        }

        private void OnStartTimeSet(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            _event.StartDate = new DateTime(_event.StartDate.Year, _event.StartDate.Month, _event.StartDate.Day, e.HourOfDay, e.Minute, 0);
            FormatDateAndTimeFields();
        }

        private void FormatDateAndTimeFields()
        {
            dateInput.Text = _event.StartDate.ToString("yyyy-MM-dd");
            timeInput.Text = _event.StartDate.ToString("HH:mm");
        }

        private bool VerifyEnteredData()
        {
            // Name
            bool valid = true;
            if (nameInput.Text.Length == 0)
            {
                nameInput.Error = Html.FromHtml("<font color='red'>A name is required</font>").ToString();
                valid = false;
            }
            // Price
            if (priceInput.Text.Length == 0)
            {
                verifiedPrice = 0.0m;
            }
            else if (!decimal.TryParse(priceInput.Text, out verifiedPrice))
            {
                priceInput.Error = Html.FromHtml("<font color='red'>Invalid price</font>").ToString();
                valid = false;
            }
            else if (verifiedPrice < 0.0m)
            {
                priceInput.Error = Html.FromHtml("<font color='red'>Invalid price</font>").ToString();
                valid = false;
            }
            // Address
            if (addressInput.Text.Length == 0)
            {
                addressInput.Error = Html.FromHtml("<font color='red'>You must specify an address</font>").ToString();
                valid = false;
            }
            else
            {
                try
                {
                    verifiedAddress = addressInput.Text.FormatAddressInfo();
                    verifiedCoordinates = verifiedAddress.ToStringNormal().LatLongFromString();
                }
                catch
                {
                    addressInput.Error = Html.FromHtml("<font color='red'>Invalid address</font>").ToString();
                    valid = false;
                }
            }
            // Sport
            if (sportInput.Text.Length == 0)
            {
                sportInput.Error = Html.FromHtml("<font color='red'>Please enter a sport</font>").ToString();
                valid = false;
            }

            return valid;
        }

        private bool FillEventData()
        {
            if (!VerifyEnteredData()) return false;

            _event.Name = nameInput.Text;
            _event.StartDate = DateTime.Parse($"{dateInput.Text} {timeInput.Text}");
            _event.Price = verifiedPrice;
            _event.Address = verifiedAddress;
            _event.Latitude = verifiedCoordinates.Latitude;
            _event.Longitude = verifiedCoordinates.Longitude;
            _event.Tags = tagInput.Text;
            _event.Sports.Clear();
            _event.Sports.Add(sportInput.Text);
            _event.Description = descriptionInput.Text;

            return true;
        }

        private void CreateEvent(object o, EventArgs e)
        {
            if (!FillEventData()) return;
            RequestSender.CreateEvent(_event);
            Finish();

            if (_managerReference != null)
            {
                _managerReference.LoadEvents();
            }
        }

        private void EditEvent(object o, EventArgs e)
        {
            if (!FillEventData()) return;
            RequestSender.EditEvent(_event);
            Finish();

            if (_managerReference != null)
            {
                _managerReference.LoadEvents();
            }
        }

        private void DeleteEvent(object o, EventArgs e)
        {
            RequestSender.DeleteEvent(_event.Id);
            Finish();

            if (_managerReference != null)
            {
                _managerReference.LoadEvents();
            }
        }

        private void SaveDraft(object o, EventArgs e)
        {
            //if (!FillEventData()) return;
            // TODO
            Finish();

            if (_managerReference != null)
            {
                _managerReference.LoadEvents();
            }
        }

        private void DeleteDraft(object o, EventArgs e)
        {
            Finish();

            if (_managerReference != null)
            {
                _managerReference.LoadEvents();
            }
        }
    }
}