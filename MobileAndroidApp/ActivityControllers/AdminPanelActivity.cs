using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Classes;
using WebApi;
using Android.Support.V7.Widget;
using localhost.ActivityControllers.Recycler_adapters;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    public class AdminPanelActivity : Activity
    {
        private List<Account> list = new List<Account>();

        private EditText searchInput;
        private ImageButton searchButton;

        private static Button silenceButton;
        private Button deleteButton;
        private static Button banButton;
        public static TextView accountLabel;
        
        private RecyclerView accountList;
        private AccountListAdapter accountListAdapter;
        private RecyclerView.LayoutManager accountListLayout;

        public static ImageView WhichSilencedIcon { get;  set; }
        public static ImageView WhichBannedIcon { get; set; }

        private static int whichSelected = -1;
        public static int WhichSelected 
        {
            get { return whichSelected; } 
            set { 
                whichSelected = value; 
                selectedAccount = new Account { Permissions = RequestSender.GetAccountPermissions(value) };
                if (selectedAccount.Can((uint)Permissions.BANNED)) banButton.Text = "Unban"; else banButton.Text = "Ban";
                if (selectedAccount.Can((uint)Permissions.SEND_CHAT_MESSAGES)) silenceButton.Text = "Silence"; else silenceButton.Text = "Unsilence";
            } 
        }
        private static Account selectedAccount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.admin_panel);

            searchInput = FindViewById<EditText>(Resource.Id.adminPanelSearch);
            searchButton = FindViewById<ImageButton>(Resource.Id.adminPanelSearchButton);
            searchButton.Click += Search;

            silenceButton = FindViewById<Button>(Resource.Id.silenceButton);
            silenceButton.Click += SilenceClick;
            deleteButton = FindViewById<Button>(Resource.Id.deleteButton);
            deleteButton.Click += DeleteClick;
            banButton = FindViewById<Button>(Resource.Id.banButton);
            banButton.Click += BanClick;

            accountList = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            accountLabel = FindViewById<TextView>(Resource.Id.selectedAccount);

            list = RequestSender.GetAccounts();

            accountList.HasFixedSize = true;
            accountList.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            accountListLayout = new LinearLayoutManager(this);
            accountList.SetLayoutManager(accountListLayout);
            accountListAdapter = new AccountListAdapter(list);
            accountList.SetAdapter(accountListAdapter);
        }

        private void Search(object o, EventArgs e)
        {
            string input = searchInput.Text.ToLower();
            list = RequestSender.GetAccounts().Where(item => item.Username.ToLower().Contains(input)).ToList();
            accountListAdapter.SetData(list);
            accountListAdapter.NotifyDataSetChanged();
        }

        private void SilenceClick(object o, EventArgs e)
        {
            if (WhichSelected == -1) return;

            if (selectedAccount.Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                RequestSender.SilenceAccount(WhichSelected);
                silenceButton.Text = "Unsilence";
                Toast.MakeText(this, $"Silenced {selectedAccount.Username}", ToastLength.Long).Show();
                selectedAccount.RemovePermission(Permissions.SEND_CHAT_MESSAGES);
                WhichSilencedIcon.Visibility = ViewStates.Visible;
            }
            else
            {
                RequestSender.UnsilenceAccount(WhichSelected);
                silenceButton.Text = "Silence";
                Toast.MakeText(this, $"Unsilenced {selectedAccount.Username}", ToastLength.Long).Show();
                selectedAccount.AddPermission(Permissions.SEND_CHAT_MESSAGES);
                WhichSilencedIcon.Visibility = ViewStates.Gone;
            }
        }

        private void DeleteClick(object o, EventArgs e)
        {
            if (WhichSelected == -1) return;
            RequestSender.DeleteAccount(WhichSelected);
            list.Remove(list.Find(x => x.Id == whichSelected));
            accountListAdapter.NotifyDataSetChanged();
        }

        private void BanClick(object o, EventArgs e)
        {
            if (WhichSelected == -1) return;

            if (selectedAccount.Can((uint)Permissions.BANNED))
            {
                banButton.Text = "Ban";
                Toast.MakeText(this, $"Unbanned {selectedAccount.Username}", ToastLength.Long).Show();
                RequestSender.UnbanAccount(WhichSelected);
                selectedAccount.RemovePermission(Permissions.BANNED);
                WhichBannedIcon.Visibility = ViewStates.Gone;
            }
            else
            {
                banButton.Text = "Unban";
                Toast.MakeText(this, $"Banned {selectedAccount.Username}", ToastLength.Long).Show();
                RequestSender.BanAccount(WhichSelected);
                selectedAccount.AddPermission(Permissions.BANNED);
                WhichBannedIcon.Visibility = ViewStates.Visible;
            }
        }
    }

}