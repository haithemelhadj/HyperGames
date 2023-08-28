using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;

public class AndroidNotificationsController : MonoBehaviour
{
    private void Start()
    {
        RequestAuthorization();
        RegisterNotificationChannel();
        SendNotification("Welcome", "Welcome to the game", 1);
    }

    //ask for permission to send notifications in android phones after version 13
    public void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }
    //register the notfications channel, can be used to create other channels like ads notifications 
    public void RegisterNotificationChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notification"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
    //send the notfication intended after any time needed
    public void SendNotification(string title, string text, int fireTimeInSeconds)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = System.DateTime.Now.AddSeconds(fireTimeInSeconds);
        AndroidNotificationCenter.SendNotification(notification, channelId: "default_channel");
    }

    
    public void SendNotificationOnCommand()
    {
        //create a random string of 10 charachters

        SendNotification("30% off promo code!", "Code: 7N3Y6BR3W75NR5R", 2);
    }


}
