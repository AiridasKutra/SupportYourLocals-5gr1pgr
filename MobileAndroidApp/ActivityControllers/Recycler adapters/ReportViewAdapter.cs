using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Classes;

namespace localhost.ActivityControllers.Recycler_adapters
{
    class ReportListAdapterHolder : RecyclerView.ViewHolder
    {
        public TextView ReportCardReportType { get; set; }
        public TextView ReportCardReportText { get; set; }
        public ReportListAdapterHolder(View itemView) : base(itemView)
        {
            ReportCardReportType = itemView.FindViewById<TextView>(Resource.Id.reportCardReportType);
            ReportCardReportText = itemView.FindViewById<TextView>(Resource.Id.reportCardReportText);
        }
    }

    class ReportViewAdapter : RecyclerView.Adapter
    {
        List<Report> reports;
        public ReportViewAdapter(List<Report> reports)
        {
            this.reports = reports;
        }

        public override int ItemCount => reports.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ReportListAdapterHolder viewHolder = holder as ReportListAdapterHolder;

            viewHolder.ReportCardReportType.Text = reports[position].Type;
            viewHolder.ReportCardReportText.Text = reports[position].Comment;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.view_reports_card, parent, false);
            return new ReportListAdapterHolder(itemView);
        }
    }
}