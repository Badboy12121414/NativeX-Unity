using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;




public class NativeXCore : MonoBehaviour {
	
	public static bool isDebugLogEnabled = true;
	
#if UNITY_ANDROID
	private static AndroidJavaObject instance;
	
	//Create link to our SDK
	private static AndroidJavaClass publisherPlug = new AndroidJavaClass("com.nativex.NativeXMonetizationUnity");
	//Create link to Unity Player
	public static AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	//Ge t the current activity to use as context
	public static AndroidJavaObject currentAct = jc.GetStatic<AndroidJavaObject>("currentActivity");
#endif
	
	static NativeXCore()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			Debug.Log("NativeX - Android Inititialization called");
			instance = publisherPlug.CallStatic<AndroidJavaObject>("getInstance");
		}
#endif
	}
#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uStartWithNameAndApplicationId(string name, string applicationId, string publisherId);
#endif
	public static void intitialization(NativeXAndroid android, NativeXiOS iOS)
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			Debug.Log("W3i - Initialization called");
			instance.Call("init", currentAct, android.appId, android.displayName, android.packageName, android.publisherUserId);	
		}
#elif UNITY_IPHONE	
		if(Application.platform == RuntimePlatform.IPhonePlayer){
				uStartWithNameAndApplicationId(iOS.appName, iOS.appId, iOS.publisherUserId);	
				if(isDebugLogEnabled){
					Debug.Log("initialization has been hit");
				}
			}
#endif
		return;		
	}
#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowOfferWall();
#endif
	public static void showRewardOfferWall()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showOfferWall", currentAct);
		}
#endif
	
#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
				uShowOfferWall();
				if(isDebugLogEnabled){
					Debug.Log("showOfferWall has been hit");
				}
		}
#endif
		return;
	}
		
#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowIncentOfferWall();
#endif
	
	public static void showRewardWebOfferwall()
	{
#if UNITY_ANDROID
			if(Application.platform == RuntimePlatform.Android){
				instance.Call("showWebOfferWall", currentAct);
			}
#endif
	
#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowIncentOfferWall();	
			if(isDebugLogEnabled){
				Debug.Log("showWebOfferWall has been hit");
			}
		}
#endif
		return;
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowNonIncentOfferWall();
#endif

	public static void showNonRewardWebOfferwall()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showNonRewardWebOfferWall", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowNonIncentOfferWall();	
			if(isDebugLogEnabled){
				Debug.Log("showNonIncentWebOfferWall has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uGetAndCacheFeaturedOffer();
#endif

	public static void getAndCacheFeaturedOffer()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("getFeaturedOffer", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uGetAndCacheFeaturedOffer();
			if(isDebugLogEnabled){
				Debug.Log("getAndCacheFeaturedOffer has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowCachedFeaturedOffer();
#endif

	public static void showCachedFeaturedOffer()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showCachedFeaturedOffer", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowCachedFeaturedOffer();	
			if(isDebugLogEnabled){
				Debug.Log("iOS - showCachedFeaturedOffer has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowFeaturedOffer();
#endif

	public static void showFeaturedOffer()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showFeaturedOffer", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowFeaturedOffer();
			if(isDebugLogEnabled){
				Debug.Log("showFeaturedOffer has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uGetAndCacheInterstitial();
#endif

	public static void getAndCacheInterstitial()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("getAndCacheInterstitial", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uGetAndCacheInterstitial();
			if(isDebugLogEnabled){
				Debug.Log("showInterstitial has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowCachedInterstitial();
#endif

	public static void showCachedInterstitial()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showCachedInterstitial", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowCachedInterstitial();
			if(isDebugLogEnabled){
				Debug.Log("showInterstitial has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowInterstitial();
#endif

	public static void showInterstitial()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showNonRewardInterstitial", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowInterstitial();
			if(isDebugLogEnabled){
				Debug.Log("showInterstitial has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uShowBanner(float x, float y, float width, float height);
#endif
	public static void showBanner()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("showNonRewardBanner", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uShowBanner(0,0,Screen.width,Screen.height/20);
			if(isDebugLogEnabled){
				Debug.Log("showBanner has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uRemoveBanner();
#endif
	public static void removeBanner()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("removeBanner", currentAct);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uRemoveBanner();
			if(isDebugLogEnabled){
				Debug.Log("removeBanner has been hit");
			}
		}
#endif
	}

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uRedeemCurrency();
#endif
	public static void redeemCurrency()
	{
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("redeemCurrency", currentAct, true);
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uRedeemCurrency();	
			if(isDebugLogEnabled){
				Debug.Log("redeemCurrency has been hit");
			}
		}
#endif
	}

//These methods were added as a request from a specific client and should not be used in typical integrations!
//	public static void checkBalances(){
//#if UNITY_ANDROID
//		if(Application.platform == RuntimePlatform.Android){
//			instance.Call("checkBalances", currentAct);
//		}
//#endif
//		return;
//	}
//
//	public static void transferBalances(bool show){
//		#if UNITY_ANDROID
//		if(Application.platform == RuntimePlatform.Android){
//			if(balance != null){balance.Clear();}
//			instance.Call("transferBalances", currentAct, show);
//		}
//#endif
//		return;
//	}


#if UNITY_IPHONE
	[DllImport ("__Internal")]	
	public static extern void uConnectWithAppId(string appId);
#endif
	public static void appWasRun(int androidAppId, int iOSAppId)
	{
#if UNITY_ANDROID
		if(androidAppId!=null)
		{
			if(Application.platform == RuntimePlatform.Android){
				instance.Call("appWasRun", androidAppId);
			}
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			if(null!=iOSAppId)
			{
				uConnectWithAppId(iOSAppId.ToString());
				if(isDebugLogEnabled){
					Debug.Log("appWasRun has been hit");
				}
			}
		}
#endif
	}

	//This Call this to perform an Action Taken call.
#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uActionTakenWithActionId(string actionId);
#endif
	public static void actionTaken(int androidActionId, int iOSActionId)
	{
#if UNITY_ANDROID
		if(androidActionId!=null)
		{
			if(Application.platform == RuntimePlatform.Android){
				instance.Call("actionTaken", androidActionId);
			}
		}
#elif UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			if(iOSActionId!=null)
			{
				uActionTakenWithActionId(iOSActionId.ToString());
				if(isDebugLogEnabled){
					Debug.Log("actionTaken has been hit");
				}
			}
		}
#endif
	}

	//This is an Android only function used to aler the consumer to turn on Auto-matic updates
	public static void upgradeAndroidApp(string currency, int amount){
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("upgradeApp", currentAct, currency, amount);
		}
#endif
		return;
	}

	//This is an Android only function to alert the consumer to rate your app
	public static void rateAndroidApp(string currency, int amount){
#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			instance.Call("rateApp", currentAct, currency, amount);
		}
#endif
		return;
	}


#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void uTrackInAppPurchase(string storeProductId, string storeTransactionId,
	                                              float costPerItem, int quantity, string productTitle);
#endif

	//Called to track an In-App-Purchase
	//Raises event Action<bool> W3iHandler.e_didTrackInAppPurchaseSucceed on completion
	public static void trackInAppPurchase(string storeProductId, string storeTransactionId,
	                                      float costPerItem, int quantity, string productTitle)
	{
#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			uTrackInAppPurchase(storeProductId, storeTransactionId, costPerItem,quantity,productTitle);	
		}
#endif
		return;
	}



	
}
