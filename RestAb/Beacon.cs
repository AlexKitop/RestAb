﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://beacon.nist.gov/record/0.1/")]
[System.Xml.Serialization.XmlRootAttribute("record", Namespace="http://beacon.nist.gov/record/0.1/", IsNullable=false)]
public partial class recordType {
    
    private string versionField;
    
    private int frequencyField;
    
    private long timeStampField;
    
    private string seedValueField;
    
    private string previousOutputValueField;
    
    private string signatureValueField;
    
    private string outputValueField;
    
    private string statusCodeField;
    
    /// <remarks/>
    public string version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
    
    /// <remarks/>
    public int frequency {
        get {
            return this.frequencyField;
        }
        set {
            this.frequencyField = value;
        }
    }
    
    /// <remarks/>
    public long timeStamp {
        get {
            return this.timeStampField;
        }
        set {
            this.timeStampField = value;
        }
    }
    
    /// <remarks/>
    public string seedValue {
        get {
            return this.seedValueField;
        }
        set {
            this.seedValueField = value;
        }
    }
    
    /// <remarks/>
    public string previousOutputValue {
        get {
            return this.previousOutputValueField;
        }
        set {
            this.previousOutputValueField = value;
        }
    }
    
    /// <remarks/>
    public string signatureValue {
        get {
            return this.signatureValueField;
        }
        set {
            this.signatureValueField = value;
        }
    }
    
    /// <remarks/>
    public string outputValue {
        get {
            return this.outputValueField;
        }
        set {
            this.outputValueField = value;
        }
    }
    
    /// <remarks/>
    public string statusCode {
        get {
            return this.statusCodeField;
        }
        set {
            this.statusCodeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://beacon.nist.gov/record/0.1/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://beacon.nist.gov/record/0.1/", IsNullable=false)]
public partial class NewDataSet {
    
    private recordType[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("record")]
    public recordType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}
