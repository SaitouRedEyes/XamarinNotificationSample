using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace NotificationSample
{
    [Activity(Label = "ReceiveNotification")]
    public class ReceiveNotification : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.receive_notification_layout);

            // Get the count value passed to us from MainActivity:
            int count = Intent.Extras.GetInt("count", -1);

            // No count was passed? Then just return.
            if (count < 0)
                return;

            Toast.MakeText(this, count.ToString() + " Notifications", ToastLength.Short).Show();
        }
    }
}