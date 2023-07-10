﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.0.30319.1.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="GreeterServiceSoap", Namespace="http://adsd.met.edu/2011/BasicWinApp")]
public partial class GreeterService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback MeetOperationCompleted;
    
    private System.Threading.SendOrPostCallback LeaveOperationCompleted;
    
    /// <remarks/>
    public GreeterService() {
        this.Url = "http://localhost/BasicWinApp/websvctest.asmx";
    }
    
    /// <remarks/>
    public event MeetCompletedEventHandler MeetCompleted;
    
    /// <remarks/>
    public event LeaveCompletedEventHandler LeaveCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://adsd.met.edu/2011/BasicWinApp/Meet", RequestNamespace="http://adsd.met.edu/2011/BasicWinApp", ResponseNamespace="http://adsd.met.edu/2011/BasicWinApp", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public GreetInfo Meet(string name, int age) {
        object[] results = this.Invoke("Meet", new object[] {
                    name,
                    age});
        return ((GreetInfo)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginMeet(string name, int age, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Meet", new object[] {
                    name,
                    age}, callback, asyncState);
    }
    
    /// <remarks/>
    public GreetInfo EndMeet(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((GreetInfo)(results[0]));
    }
    
    /// <remarks/>
    public void MeetAsync(string name, int age) {
        this.MeetAsync(name, age, null);
    }
    
    /// <remarks/>
    public void MeetAsync(string name, int age, object userState) {
        if ((this.MeetOperationCompleted == null)) {
            this.MeetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMeetOperationCompleted);
        }
        this.InvokeAsync("Meet", new object[] {
                    name,
                    age}, this.MeetOperationCompleted, userState);
    }
    
    private void OnMeetOperationCompleted(object arg) {
        if ((this.MeetCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.MeetCompleted(this, new MeetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://adsd.met.edu/2011/BasicWinApp/Leave", RequestNamespace="http://adsd.met.edu/2011/BasicWinApp", ResponseNamespace="http://adsd.met.edu/2011/BasicWinApp", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string Leave(string name) {
        object[] results = this.Invoke("Leave", new object[] {
                    name});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginLeave(string name, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Leave", new object[] {
                    name}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndLeave(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void LeaveAsync(string name) {
        this.LeaveAsync(name, null);
    }
    
    /// <remarks/>
    public void LeaveAsync(string name, object userState) {
        if ((this.LeaveOperationCompleted == null)) {
            this.LeaveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLeaveOperationCompleted);
        }
        this.InvokeAsync("Leave", new object[] {
                    name}, this.LeaveOperationCompleted, userState);
    }
    
    private void OnLeaveOperationCompleted(object arg) {
        if ((this.LeaveCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.LeaveCompleted(this, new LeaveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adsd.met.edu/2011/BasicWinApp")]
public partial class GreetInfo {
    
    private string messageField;
    
    private string timeField;
    
    /// <remarks/>
    public string Message {
        get {
            return this.messageField;
        }
        set {
            this.messageField = value;
        }
    }
    
    /// <remarks/>
    public string Time {
        get {
            return this.timeField;
        }
        set {
            this.timeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
public delegate void MeetCompletedEventHandler(object sender, MeetCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class MeetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal MeetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public GreetInfo Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((GreetInfo)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
public delegate void LeaveCompletedEventHandler(object sender, LeaveCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class LeaveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal LeaveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}
