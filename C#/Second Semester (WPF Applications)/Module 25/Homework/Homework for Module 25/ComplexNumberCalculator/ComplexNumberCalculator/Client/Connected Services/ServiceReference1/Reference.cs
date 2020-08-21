﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Complex", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class Complex : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ImField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ReField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Im {
            get {
                return this.ImField;
            }
            set {
                if ((this.ImField.Equals(value) != true)) {
                    this.ImField = value;
                    this.RaisePropertyChanged("Im");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Re {
            get {
                return this.ReField;
            }
            set {
                if ((this.ReField.Equals(value) != true)) {
                    this.ReField = value;
                    this.RaisePropertyChanged("Re");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Add", ReplyAction="http://tempuri.org/IService/AddResponse")]
        Client.ServiceReference1.Complex Add(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Add", ReplyAction="http://tempuri.org/IService/AddResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.Complex> AddAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Substract", ReplyAction="http://tempuri.org/IService/SubstractResponse")]
        Client.ServiceReference1.Complex Substract(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Substract", ReplyAction="http://tempuri.org/IService/SubstractResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.Complex> SubstractAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Multiply", ReplyAction="http://tempuri.org/IService/MultiplyResponse")]
        Client.ServiceReference1.Complex Multiply(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Multiply", ReplyAction="http://tempuri.org/IService/MultiplyResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.Complex> MultiplyAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Divide", ReplyAction="http://tempuri.org/IService/DivideResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.DivideByZeroException), Action="http://tempuri.org/IService/DivideDivideByZeroExceptionFault", Name="DivideByZeroException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        Client.ServiceReference1.Complex Divide(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Divide", ReplyAction="http://tempuri.org/IService/DivideResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.Complex> DivideAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IService>, Client.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.ServiceReference1.Complex Add(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.Add(a, b);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.Complex> AddAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.AddAsync(a, b);
        }
        
        public Client.ServiceReference1.Complex Substract(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.Substract(a, b);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.Complex> SubstractAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.SubstractAsync(a, b);
        }
        
        public Client.ServiceReference1.Complex Multiply(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.Multiply(a, b);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.Complex> MultiplyAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.MultiplyAsync(a, b);
        }
        
        public Client.ServiceReference1.Complex Divide(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.Divide(a, b);
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.Complex> DivideAsync(Client.ServiceReference1.Complex a, Client.ServiceReference1.Complex b) {
            return base.Channel.DivideAsync(a, b);
        }
    }
}