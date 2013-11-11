/// <summary>
/// http://www.codeproject.com/Articles/572263/A-Reusable-Base-Class-for-the-Singleton-Pattern-in
/// </summary>

using System;

namespace MCback{
	
	/* USE EXAMPLE-----------------------------------------------
	class SingletonExample : SingletonBase<SingletonExample>{
	 
	  public string SomeString {get; set; }
	
	  private SingletonExample()  {}
	}
	-------------------------------------------------------------*/
	
	public abstract class SingletonBase<T> where T : class{

	  private static readonly Lazy<T> _instance = new Lazy<T>(() => CreateInstanceOfT());
	
	  public static T instance { get { return _instance.Value; } }
	
	  private static T CreateInstanceOfT(){
	    return Activator.CreateInstance(typeof(T), true) as T;
	  }
	

	}

}