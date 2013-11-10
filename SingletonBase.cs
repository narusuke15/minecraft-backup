
using System;

namespace MCback{

	public abstract class SingletonBase<T> where T : class
	{
	  #region Members
	
	 
	  private static readonly Lazy<T> sInstance = new Lazy<T>(() => CreateInstanceOfT());
	
	  #endregion
	
	  #region Properties
	

	  public static T instance { get { return sInstance.Value; } }
	
	  #endregion
	
	  #region Methods
	
	  /// <summary>
	  /// Creates an instance of T via reflection since T's constructor is expected to be private.
	  /// </summary>
	  /// <returns></returns>
	  private static T CreateInstanceOfT()
	  {
	    return Activator.CreateInstance(typeof(T), true) as T;
	  }
	
	  #endregion
	}

}