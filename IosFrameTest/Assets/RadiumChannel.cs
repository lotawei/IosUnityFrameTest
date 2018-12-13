using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System;


[System.Serializable]
public class PassInfo
{
    private string acc_type;
    private string passport;
    private string timestamp;
    private string sign;
    private string token;
    private string email;
    private int expire_in;
    private string bind_list;

    public string Acc_type
    {
        get
        {
            return acc_type;
        }

        set
        {
            acc_type = value;
        }
    }

    public string Passport
    {
        get
        {
            return passport;
        }

        set
        {
            passport = value;
        }
    }

    public string Timestamp
    {
        get
        {
            return timestamp;
        }

        set
        {
            timestamp = value;
        }
    }

    public string Sign
    {
        get
        {
            return sign;
        }

        set
        {
            sign = value;
        }
    }

    public string Token
    {
        get
        {
            return token;
        }

        set
        {
            token = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public int Expire_in
    {
        get
        {
            return expire_in;
        }

        set
        {
            expire_in = value;
        }
    }

    public string Bind_list
    {
        get
        {
            return bind_list;
        }

        set
        {
            bind_list = value;
        }
    }

    public PassInfo(AndroidJavaObject obj)
    {

        if (obj == null)
        {
            this.Acc_type = obj.Call<string>("getAcc_type");
            this.Passport = obj.Call<string>("getPassport");
            this.Timestamp = obj.Call<string>("getTimestamp");
            this.Sign = obj.Call<string>("getSign");
            this.Token = obj.Call<string>("getToken");
            this.Email = obj.Call<string>("getEmail");
            this.Expire_in = obj.Call<int>("getExpire_in");
            this.Bind_list = obj.Call<string>("getBind_list");
        }



    }

    //public PassInfo()
    //{
    //    this.Acc_type = "aaaaaaaa";
    //    this.Passport = "xx";
    //    this.Email = "kiql";
    //    this.Token = "TEST_TOKEN";
    //}

    public override string ToString()
    {
        return string.Format("acce_type:{0},passport:{1},timestamp:{2},sign:{3},token:{4},email:{5},expire_in:{6},bind_list:{7}",
            Acc_type, Passport, Timestamp, Sign, Token, Email, Expire_in, Bind_list);
    }


}

public sealed class MonoPInvokeCallbackAttributte: System.Attribute
{
    
    public   MonoPInvokeCallbackAttributte(Type type){
           
    }


}
public class RadiumChannel : MonoBehaviour
{
    public GameObject btn;

 

  
    public delegate void MsgCall(string msg,int errcode);
    public delegate void nomsgCallback();
    //public delegate void MsgstrCall(string msg);
    [AOT.MonoPInvokeCallback(typeof(MsgCall))]
    static void recievemsg(string msg,int errcode){

        Debug.Log(msg.ToString()+errcode.ToString());
        RadiumChannel.instance.gameObject.transform.Find("Button/Text").GetComponent<Text>().text = "退出";
    }
    [AOT.MonoPInvokeCallback(typeof(nomsgCallback))]
    static void callback()
    {

        RadiumChannel.instance.gameObject.transform.Find("Button/Text").GetComponent<Text>().text = "登录";
    }
   
    
    [DllImport("__Internal")]
    private static extern void start();
    [DllImport("__Internal")]
    private static extern void enabledebug(bool open);


    [DllImport("__Internal")]
    private static extern void logout(nomsgCallback callback);
    [DllImport("__Internal")]
    private static extern void setcallback(string  msgjson);
    [DllImport("__Internal")]
   
    private static extern void setcallbackmsg(MsgCall callback);

    public static RadiumChannel instance;

    void Awake()
    {
        if (instance == null)
        {
            // 判定 null 是保证场景跳转时不会出现重复的 GlobalScript 实例 (主要是跳转回上一个场景)
            // 在没有 GlobalScript 实例时才创建 GlobalScript 实例
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            // 保证场景中只有唯一的 GlobalScript 实例，如果有多余的则销毁
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start()
    {

        //string data = "{ \"Acc_type\":\"radium\", \"Passport\":\"adjjja\", \"Timestamp\":\"1299319293\", \"Sign\":\"1992212\", \"Token\":\"ajdjajdsj\", \"Email\":\"kald\", \"Expire_in\":3921, \"Bind_list\":\"1,2,31\"}";


        //PassInfo  info =   JsonUtility.FromJson<PassInfo>(data);
        //Debug.Log(info.ToString());
    }
    public void clickGologin()
    {

        Debug.Log("go login");
        string nametext = gameObject.transform.Find("Button/Text").GetComponent<Text>().text;

        if (nametext == "登录")
        {
            enabledebug(true);
            setcallback("我有毒");

            //MsgCall call = vlue => { Debug.Log(vlue); };
            setcallbackmsg(RadiumChannel.recievemsg);
            //setcallmsgStr(RadiumChannel.recievestr);
            //start();

        }
        else{

            logout(RadiumChannel.callback);
            
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
