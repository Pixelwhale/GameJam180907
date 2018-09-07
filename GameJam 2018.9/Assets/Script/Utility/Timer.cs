//------------------------------------------------------
// 作成日：2018.8.18
// 作成者：林 佳叡
// 内容：Timer
//------------------------------------------------------
using UnityEngine;

public class Timer
{
	private bool isScaled;				//Time Scaleを適用するか
	private float currentTime;			//current
	private float limitTime;			//max

	public Timer(float limitTime = 1.0f, bool isScaled = true)
	{
		this.isScaled = isScaled;
		this.limitTime = limitTime;
		Initialize();
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize()
	{
		currentTime = 0.0f;
	}

	public void Update()
	{
		currentTime += isScaled ? Time.deltaTime : Time.unscaledDeltaTime;		//TimeScale適用するかにより加算
		if(currentTime >= limitTime)											//Overの場合
			currentTime = limitTime;
	}
	
	/// <summary>
	/// 時間が来たか
	/// </summary>
	/// <returns></returns>
	public bool IsTime()
	{
		return currentTime >= limitTime;
	}
	
	/// <summary>
	/// 割合
	/// </summary>
	/// <returns></returns>
	public float Rate()
	{
		return currentTime / limitTime;
	}
	
	/// <summary>
	/// Time Scaleを適用するか
	/// </summary>
	/// <value></value>
	public bool IsScaled
	{
		get{ return isScaled; }
		set{ isScaled = value; }
	}

	/// <summary>
	/// 長さを変える
	/// </summary>
	/// <value></value>
	public float LimitTime
	{
		set{ limitTime = value; }
	}
}
