package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import java.util.Arrays;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);

				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();
				java.io.File external0 = android.os.Environment.getExternalStorageDirectory ();
				String externalDir = new java.io.File (
							external0,
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();
				String externalLegacyDir = new java.io.File (
							external0,
							"../legacy/Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();

				System.loadLibrary("monodroid");

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new String[] {
							externalDir,
							externalLegacyDir
						},
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName (),
						android.os.Build.VERSION.SDK_INT,
						mono.android.app.XamarinAndroidEnvironmentVariables.Variables);
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "Student_Analyser.Android.dll" comes first in this list. */
		"Student_Analyser.Android.dll",
		"Dapper.dll",
		"FluentValidation.dll",
		"FormsViewGroup.dll",
		"ImageCircle.Forms.Plugin.dll",
		"Microcharts.dll",
		"Microcharts.Droid.dll",
		"Microcharts.Forms.dll",
		"Microsoft.Bcl.AsyncInterfaces.dll",
		"Microsoft.Bcl.HashCode.dll",
		"Microsoft.Data.Sqlite.dll",
		"Microsoft.DotNet.PlatformAbstractions.dll",
		"Microsoft.EntityFrameworkCore.Abstractions.dll",
		"Microsoft.EntityFrameworkCore.dll",
		"Microsoft.EntityFrameworkCore.Relational.dll",
		"Microsoft.EntityFrameworkCore.Sqlite.dll",
		"Microsoft.Extensions.Caching.Abstractions.dll",
		"Microsoft.Extensions.Caching.Memory.dll",
		"Microsoft.Extensions.Configuration.Abstractions.dll",
		"Microsoft.Extensions.Configuration.Binder.dll",
		"Microsoft.Extensions.Configuration.dll",
		"Microsoft.Extensions.DependencyInjection.Abstractions.dll",
		"Microsoft.Extensions.DependencyInjection.dll",
		"Microsoft.Extensions.DependencyModel.dll",
		"Microsoft.Extensions.Logging.Abstractions.dll",
		"Microsoft.Extensions.Logging.dll",
		"Microsoft.Extensions.Options.dll",
		"Microsoft.Extensions.Primitives.dll",
		"PCLStorage.Abstractions.dll",
		"PCLStorage.dll",
		"SkiaSharp.dll",
		"SkiaSharp.Views.Android.dll",
		"SkiaSharp.Views.Forms.dll",
		"SQLite-net.dll",
		"SQLite.Net.dll",
		"SQLite.Net.Platform.XamarinAndroid.dll",
		"SQLitePCLRaw.batteries_v2.dll",
		"SQLitePCLRaw.core.dll",
		"SQLitePCLRaw.lib.e_sqlite3.android.dll",
		"SQLitePCLRaw.provider.e_sqlite3.dll",
		"Student_Analyser.dll",
		"Syncfusion.Core.XForms.Android.dll",
		"Syncfusion.Core.XForms.dll",
		"Syncfusion.Licensing.dll",
		"Syncfusion.SfChart.XForms.Android.dll",
		"Syncfusion.SfChart.XForms.dll",
		"System.Collections.Immutable.dll",
		"System.Data.SQLite.dll",
		"System.Diagnostics.DiagnosticSource.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"System.Text.Encodings.Web.dll",
		"System.Text.Json.dll",
		"Xamarin.Android.Arch.Core.Common.dll",
		"Xamarin.Android.Arch.Core.Runtime.dll",
		"Xamarin.Android.Arch.Lifecycle.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll",
		"Xamarin.Android.Arch.Lifecycle.LiveData.dll",
		"Xamarin.Android.Arch.Lifecycle.Runtime.dll",
		"Xamarin.Android.Arch.Lifecycle.ViewModel.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.Annotations.dll",
		"Xamarin.Android.Support.AsyncLayoutInflater.dll",
		"Xamarin.Android.Support.Collections.dll",
		"Xamarin.Android.Support.Compat.dll",
		"Xamarin.Android.Support.CoordinaterLayout.dll",
		"Xamarin.Android.Support.Core.UI.dll",
		"Xamarin.Android.Support.Core.Utils.dll",
		"Xamarin.Android.Support.CursorAdapter.dll",
		"Xamarin.Android.Support.CustomTabs.dll",
		"Xamarin.Android.Support.CustomView.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.DocumentFile.dll",
		"Xamarin.Android.Support.DrawerLayout.dll",
		"Xamarin.Android.Support.Fragment.dll",
		"Xamarin.Android.Support.Interpolator.dll",
		"Xamarin.Android.Support.Loader.dll",
		"Xamarin.Android.Support.LocalBroadcastManager.dll",
		"Xamarin.Android.Support.Media.Compat.dll",
		"Xamarin.Android.Support.Print.dll",
		"Xamarin.Android.Support.SlidingPaneLayout.dll",
		"Xamarin.Android.Support.SwipeRefreshLayout.dll",
		"Xamarin.Android.Support.Transition.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Android.Support.v7.Palette.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.Android.Support.VersionedParcelable.dll",
		"Xamarin.Android.Support.ViewPager.dll",
		"Xamarin.Essentials.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_28";
}
