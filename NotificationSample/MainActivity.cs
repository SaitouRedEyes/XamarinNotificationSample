using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;

namespace NotificationSample
{
    [Activity(Label = "NotificationSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private int count;
        private NotificationChannel nc;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            count = 1;

            Button buttonSendNotification = FindViewById<Button>(Resource.Id.buttonSendNotification);

            buttonSendNotification.Click += OnButtonSendNotificationClicked;
        }

        private void OnButtonSendNotificationClicked(object sender, System.EventArgs e)
        {
            // When the user clicks the notification, SecondActivity will start up.
            Intent resultIntent = new Intent(this, typeof(ReceiveNotification));

            Bundle myParameters = new Bundle();
            myParameters.PutInt("count", count);

            // Pass some values to SecondActivity:
            resultIntent.PutExtras(myParameters);

            // Construct a back stack for cross-task navigation:
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(ReceiveNotification)));
            stackBuilder.AddNextIntent(resultIntent);

            // Create the PendingIntent with the back stack:            
            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
            
            //Build Notification
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, "location_notification")
                .SetAutoCancel(true)
                .SetContentIntent(resultPendingIntent)
                .SetContentTitle("Button Clicked")
                .SetNumber(count)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                .SetContentText(string.Format("The button has been clicked {0} times.", count));

            NotificationManager nf = (NotificationManager)GetSystemService(NotificationService);

            //Creating a Channel
            if (Build.VERSION.SdkInt > BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                string channelName = "Meu Canal de Notificação";
                string channelDescription = "Minha descrição do canal";
                nc = new NotificationChannel("location_notification", channelName, NotificationImportance.Default)
                {
                    Description = channelDescription
                };

                nf.CreateNotificationChannel(nc);
            }

            //Send Notification
            NotificationManagerCompat nmc = NotificationManagerCompat.From(this);
            nmc.Notify(1000, builder.Build());

            count++;
        }
    }
}

