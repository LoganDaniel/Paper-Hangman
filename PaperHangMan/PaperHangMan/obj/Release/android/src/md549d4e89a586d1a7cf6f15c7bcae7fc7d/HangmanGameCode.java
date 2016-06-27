package md549d4e89a586d1a7cf6f15c7bcae7fc7d;


public class HangmanGameCode
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PaperHangMan.HangmanGameCode, PaperHangMan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HangmanGameCode.class, __md_methods);
	}


	public HangmanGameCode () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HangmanGameCode.class)
			mono.android.TypeManager.Activate ("PaperHangMan.HangmanGameCode, PaperHangMan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
