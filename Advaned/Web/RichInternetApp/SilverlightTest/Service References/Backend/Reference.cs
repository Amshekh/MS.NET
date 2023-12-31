﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace SilverlightTest.Backend {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://adsd.met.edu/2011/SilverlightTest", ConfigurationName="Backend.ToDService")]
    public interface ToDService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://adsd.met.edu/2011/SilverlightTest/ToDService/GetServerTime", ReplyAction="http://adsd.met.edu/2011/SilverlightTest/ToDService/GetServerTimeResponse")]
        System.IAsyncResult BeginGetServerTime(string format, System.AsyncCallback callback, object asyncState);
        
        string EndGetServerTime(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ToDServiceChannel : SilverlightTest.Backend.ToDService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetServerTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetServerTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ToDServiceClient : System.ServiceModel.ClientBase<SilverlightTest.Backend.ToDService>, SilverlightTest.Backend.ToDService {
        
        private BeginOperationDelegate onBeginGetServerTimeDelegate;
        
        private EndOperationDelegate onEndGetServerTimeDelegate;
        
        private System.Threading.SendOrPostCallback onGetServerTimeCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ToDServiceClient() {
        }
        
        public ToDServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ToDServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ToDServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ToDServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetServerTimeCompletedEventArgs> GetServerTimeCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SilverlightTest.Backend.ToDService.BeginGetServerTime(string format, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetServerTime(format, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string SilverlightTest.Backend.ToDService.EndGetServerTime(System.IAsyncResult result) {
            return base.Channel.EndGetServerTime(result);
        }
        
        private System.IAsyncResult OnBeginGetServerTime(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string format = ((string)(inValues[0]));
            return ((SilverlightTest.Backend.ToDService)(this)).BeginGetServerTime(format, callback, asyncState);
        }
        
        private object[] OnEndGetServerTime(System.IAsyncResult result) {
            string retVal = ((SilverlightTest.Backend.ToDService)(this)).EndGetServerTime(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetServerTimeCompleted(object state) {
            if ((this.GetServerTimeCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetServerTimeCompleted(this, new GetServerTimeCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetServerTimeAsync(string format) {
            this.GetServerTimeAsync(format, null);
        }
        
        public void GetServerTimeAsync(string format, object userState) {
            if ((this.onBeginGetServerTimeDelegate == null)) {
                this.onBeginGetServerTimeDelegate = new BeginOperationDelegate(this.OnBeginGetServerTime);
            }
            if ((this.onEndGetServerTimeDelegate == null)) {
                this.onEndGetServerTimeDelegate = new EndOperationDelegate(this.OnEndGetServerTime);
            }
            if ((this.onGetServerTimeCompletedDelegate == null)) {
                this.onGetServerTimeCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetServerTimeCompleted);
            }
            base.InvokeAsync(this.onBeginGetServerTimeDelegate, new object[] {
                        format}, this.onEndGetServerTimeDelegate, this.onGetServerTimeCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override SilverlightTest.Backend.ToDService CreateChannel() {
            return new ToDServiceClientChannel(this);
        }
        
        private class ToDServiceClientChannel : ChannelBase<SilverlightTest.Backend.ToDService>, SilverlightTest.Backend.ToDService {
            
            public ToDServiceClientChannel(System.ServiceModel.ClientBase<SilverlightTest.Backend.ToDService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetServerTime(string format, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = format;
                System.IAsyncResult _result = base.BeginInvoke("GetServerTime", _args, callback, asyncState);
                return _result;
            }
            
            public string EndGetServerTime(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("GetServerTime", _args, result)));
                return _result;
            }
        }
    }
}
