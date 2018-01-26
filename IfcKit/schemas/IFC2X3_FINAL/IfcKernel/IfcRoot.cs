// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("573a9f55-5906-4592-af57-a0b4b630765d")]
	public abstract partial class IfcRoot
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcGloballyUniqueId _GlobalId;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcOwnerHistory _OwnerHistory;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		public IfcRoot()
		{
		}
	
		public IfcRoot(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
		{
			this._GlobalId = __GlobalId;
			this._OwnerHistory = __OwnerHistory;
			this._Name = __Name;
			this._Description = __Description;
		}
	
		[Description("Assignment of a globally unique identifier within the entire software world.\r\n")]
		public IfcGloballyUniqueId GlobalId { get { return this._GlobalId; } set { this._GlobalId = value;} }
	
		[Description("Assignment of the information about the current ownership of that object, includi" +
	    "ng owning actor, application, local identification and information captured abou" +
	    "t the recent changes of the object, NOTE: only the last modification in stored.\r" +
	    "\n")]
		public IfcOwnerHistory OwnerHistory { get { return this._OwnerHistory; } set { this._OwnerHistory = value;} }
	
		[Description("Optional name for use by the participating software systems or users. For some su" +
	    "btypes of IfcRoot the insertion of the Name attribute may be required. This woul" +
	    "d be enforced by a where rule.\r\n")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Optional description, provided for exchanging informative comments.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
	
	}
	
}
