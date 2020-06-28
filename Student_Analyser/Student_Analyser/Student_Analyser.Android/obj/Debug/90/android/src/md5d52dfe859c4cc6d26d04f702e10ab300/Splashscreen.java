package md5d52dfe859c4cc6d26d04f702e10ab300;


public class Splashscreen
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
		mono.android.Runtime.register ("Student_Analyser.Droid.Splashscreen, Student_Analyser.Android", Splashscreen.class, __md_methods);
	}


	public Splashscreen ()
	{
		super ();
		if (getClass () == Splashscreen.class)
			mono.android.TypeManager.Activate ("Student_Analyser.Droid.Splashscreen, Student_Analyser.Android", "", this, new java.lang.Object[] {  });
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
