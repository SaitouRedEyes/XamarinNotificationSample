package md55f371832577a9e9d55de4ad5d156afcd;


public class ReceiveNotification
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("NotificationSample.ReceiveNotification, NotificationSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ReceiveNotification.class, __md_methods);
	}


	public ReceiveNotification ()
	{
		super ();
		if (getClass () == ReceiveNotification.class)
			mono.android.TypeManager.Activate ("NotificationSample.ReceiveNotification, NotificationSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}